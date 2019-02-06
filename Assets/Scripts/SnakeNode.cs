using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode : MonoBehaviour {

    //The Snake Node Class

    //The Nodes Index
    int IndexX;
    int IndexY;

    public void SetSnakeNode(int IndexX, int IndexY)
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

}
