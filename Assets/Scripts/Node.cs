using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Node : MonoBehaviour {

    //The Array Node Class

    int IndexX;
    int IndexY;

    NodeState NS;

    //Set the Node Statue (Node Builder)
    public void SetNode(int IndexX, int IndexY, NodeState NS)
    {
        this.IndexX = IndexX;
        this.IndexY = IndexY;
        this.NS = NS;
        UpdateState();
    }

    public void SetNode(int IndexX, int IndexY)
    {
        this.IndexX = IndexX;
        this.IndexY = IndexY;
    }

    public void setIndexX(int IndexX)
    {
        this.IndexX = IndexX;
    }

    public int getIndexX()
    {
        return IndexX;
    }

    public void setIndexY(int IndexY)
    {
        this.IndexY = IndexY;
    }

    public int getIndexY()
    {
        return IndexY;
    }

    //Set the Node Statue
    public void setNS(NodeState NS)
    {
        this.NS = NS;
        UpdateState();
    }

    public NodeState getNS()
    {
        return NS;
    }

    //Update the color based on the Statue
    void UpdateState()
    {
        switch (NS)
        {
            case NodeState.None :
                /*this.GetComponent<SpriteRenderer>().color*/ newColor= new Color32(0, 0, 0, 255); //Black
                break;
            case NodeState.Snake:
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //White
                newColor = new Color32(255, 255, 255, 255);
                break;
            case NodeState.Food:
                /*this.GetComponent<SpriteRenderer>().color*/ newColor= new Color32(0, 214, 0, 255); //Green
                break;
        }
    }

    Color32 newColor;

    void Update()
    {
        //Change the color Dynamically 
        this.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(this.GetComponent<SpriteRenderer>().color,
                                                                          newColor,
                                                                          4 * Time.deltaTime
                                                                         );
    }

}
