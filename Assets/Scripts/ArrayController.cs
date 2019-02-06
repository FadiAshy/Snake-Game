using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enums;

public class ArrayController : MonoBehaviour {

    public GameObject ArrayNode;
    public GameObject ArrayNodeParent;

    public Snake snake;
    MovementController MC;
    UIController UC;

    public int Width;
    public int Height;

    bool FoodEaten;
    bool FoodAvi;

    bool GameOver = true;

    //List<GameObject> Array;
    GameObject[,] Array;

	// Use this for initialization
	void Start () {
        MC = FindObjectOfType<MovementController>();
        UC = FindObjectOfType<UIController>();

        FoodEaten = false;
        FoodAvi = false;
        Array = new GameObject[Height,Width];

        //Set up the Array
        for (int i = 0, Ai=0; i > -Height && Ai<Height ; i--, Ai++)
            for (int j = 0; j < Width; j++)
            {
                GameObject AN = Instantiate(ArrayNode,new Vector3(j,i,0),new Quaternion(0,0,0,0)) as GameObject;
                AN.transform.parent = ArrayNodeParent.transform;
                Array[Ai, j] = AN;
                Array[Ai, j].GetComponent<Node>().SetNode(Ai, j, NodeState.None);
            }
        startGame();
	}

    void Update()
    {
        if (!GameOver)
            if (Input.GetKeyDown(KeyCode.R))
                Reset();
    }

    void startGame()
    {
        Array[Height / 2, Width / 2].GetComponent<Node>().setNS(NodeState.Snake);
        snake.AddNode(Array[Height / 2, Width / 2].GetComponent<Node>());

        FoodEaten = true;

        StartCoroutine(UpdateArray());
    }

    IEnumerator UpdateArray()
    {
        // wait a bit to move
        while (MC.getMoveState() == MoveState.None)
        {
            yield return new WaitForSeconds(0.3f);
        }

        GameOver = true;

        while (GameOver)
        {
            //if there is no food put one
            if (!FoodAvi)
                putFood();

            //click the move
            Node N = CheckAviMove();

            if(checkNodeInsideArray(N.getIndexX(),N.getIndexY()))
            {
                N = Array[N.getIndexX(), N.getIndexY()].GetComponent<Node>();

                //if the node is food eat it
                if (N.getNS() == NodeState.Food)
                {
                    UC.AddScore(1);
                    FoodEaten = true;
                    FoodAvi = false;
                }

                //Update Snake and add a body piece
                snake.UpdateSnake(N, FoodEaten);

                MC.AbleToChange = true;

                if (FoodEaten)
                    FoodEaten = false;
            }
            else
            {
                // the game ended
                UC.GameOver();
                Debug.Log("GameOver");
                GameOver = false;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    //reset all the array nodes back to black
    void Reset()
    {
        FoodAvi = false;
        for (int Ai = 0;Ai < Height; Ai++)
            for (int j = 0; j < Width; j++)
            {
                Array[Ai, j].GetComponent<Node>().SetNode(Ai, j, NodeState.None);
            }
        UC.Reset();
        MC.setMoveState(MoveState.None);
        MC.AbleToChange = true;
        snake.Reset();
        startGame();
    }

    //put new food on the array
    public void putFood()
    {
        bool foodDone=true;
        while (foodDone)
        {
            //pick a random node
            int X = Random.Range(0, Height);
            int Y = Random.Range(0, Width);

            //check if the node is empty
            if (Array[X, Y].GetComponent<Node>().getNS() == NodeState.None)
            {
                Array[X, Y].GetComponent<Node>().setNS(NodeState.Food);
                foodDone = false;
                FoodAvi = true;
            }
        }
    }

    //change the node state
    public void changeNode(int x,int y,NodeState NS)
    {
        Array[x, y].GetComponent<Node>().setNS(NS);
    }

    //Check if the next move is good
    Node CheckAviMove()
    {
        //get the Head of the snake
        SnakeNode SN = snake.GetHead();

        int x=0, y=0;
        switch (MC.getMoveState())
        {
            case MoveState.up: x = -1; y = 0;
                break;
            case MoveState.down: x = 1; y = 0;
                break;
            case MoveState.left: x = 0; y = -1;
                break;
            case MoveState.right: x = 0; y = 1;
                break;
        }

        Node N = new Node();

        //make the move and trasfer it to the snake
        N.SetNode(SN.getIndexX() + x, SN.getIndexY() + y);

        if (N.getIndexX() < 0)
            N.setIndexX(Height-1);

        if (N.getIndexY() < 0)
            N.setIndexY(Width-1);

        if (N.getIndexX() == Height)
            N.setIndexX(0);

        if (N.getIndexY() == Width)
            N.setIndexY(0);

        return N;
    }

    //check if the node is empty or a snake
    bool checkNodeInsideArray(int x , int y)
    {
        if (Array[x, y].GetComponent<Node>().getNS() != NodeState.Snake)// || Array[x, y].GetComponent<Node>().getNS() == NodeState.Food)
                return true;
            else
                return false;
    }

}
