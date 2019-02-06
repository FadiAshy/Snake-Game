using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    /*
     * The Snake Class
     * 
     * */

    List<SnakeNode> SnakeBody;

    ArrayController AC;

	void Start () {
        SnakeBody = new List<SnakeNode>();
        AC = FindObjectOfType<ArrayController>();
	}

    //Adding a Node to the snake
    public void AddNode(Node N)
    {
        //Create new Snake node
        SnakeNode S = new SnakeNode();

        //set the node in the snake body
        S.SetSnakeNode(N.getIndexX(), N.getIndexY());

        //Add the Node
        SnakeBody.Add(S);

        //Change the ArrayNode Statue in the Main Array
        AC.changeNode(N.getIndexX(), N.getIndexY(), Enums.NodeState.Snake);
    }

    //Reset the Snake Size
    public void Reset()
    {
        SnakeBody.Clear();
    }

    //Return the first snake node
    public SnakeNode GetHead()
    {
        return SnakeBody[0];
    }

    //Return the last Sanke node
    public SnakeNode GetTail()
    {
        return SnakeBody[SnakeBody.Count-1];
    }


    public void UpdateSnake(Node N , bool PutTail)
    {
        int HoldIndexX, HoldIndexY;
        int DesIndexX = N.getIndexX(), DesIndexY = N.getIndexY();

        foreach (SnakeNode SN in SnakeBody)
        {
            HoldIndexX = SN.getIndexX();
            HoldIndexY = SN.getIndexY();

            SN.setIndexX(DesIndexX);
            SN.setIndexY(DesIndexY);

            AC.changeNode(DesIndexX, DesIndexY, Enums.NodeState.Snake);

            DesIndexX = HoldIndexX;
            DesIndexY = HoldIndexY;
        }

        if (PutTail)
        {
            SnakeNode S = new SnakeNode();
            S.SetSnakeNode(DesIndexX, DesIndexY);
            SnakeBody.Add(S);
            AC.changeNode(DesIndexX, DesIndexY, Enums.NodeState.Snake);
        }
        else
            AC.changeNode(DesIndexX, DesIndexY, Enums.NodeState.None);
    }
	
}
