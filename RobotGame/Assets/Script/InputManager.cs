using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 移動入力
    public Vector3 MoveInput()
    {
        float horizontal = Input.GetAxis(  "Horizontal"    );
        float vertical   = Input.GetAxis(  "Vertical"      );

        return new Vector3( horizontal, 0, vertical );
    }


    // カメラ入力
    public Vector3 CameraInput()
    {
        float horizontal = Input.GetAxis(  "CameraHorizontal"    );
        float vertical   = Input.GetAxis(  "CameraVertical"      );

        return new Vector3( horizontal, 0, -vertical );
    }


    // ジャンプ入力
    public bool JumpInput()
    {
        if( Input.GetButtonDown(      "Jump"     ) )
        {
            return true;
        }

        return false;
    }
}
