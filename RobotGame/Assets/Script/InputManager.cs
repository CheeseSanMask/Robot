using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool JumpInput()
    {
        if( Input.GetButtonDown(      "Jump"     ) )
        {
            return true;
        }

        return false;
    }
}
