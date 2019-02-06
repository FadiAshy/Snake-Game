using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class MovementController : MonoBehaviour {

    MoveState State = MoveState.None;
    public bool AbleToChange = true;

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (State != MoveState.down && AbleToChange)
            {
                State = MoveState.up;
                AbleToChange = false;
            }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
            if (State != MoveState.up && AbleToChange)
            {
                State = MoveState.down;
                AbleToChange = false;
            }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            if (State != MoveState.right && AbleToChange)
            {
                State = MoveState.left;
                AbleToChange = false;
            }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            if (State != MoveState.left && AbleToChange)
            {
                State = MoveState.right;
                AbleToChange = false;
            }

	}

    public MoveState getMoveState()
    {
        return State;
    }

    public void setMoveState(MoveState MS)
    {
        State=MS;
    }
}
