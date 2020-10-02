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

        float inputNumSize = Mathf.Abs( horizontal )+Mathf.Abs( vertical );

        if( inputNumSize < 0.3f )
        {
            return Vector3.zero;
        }

        return new Vector3( horizontal, 0, vertical );
    }


    // カメラ入力
    public Vector3 CameraInput()
    {
        float horizontal = Input.GetAxis(  "CameraHorizontal"    );
        float vertical   = Input.GetAxis(  "CameraVertical"      );

        float inputNumSize = Mathf.Abs( horizontal )+Mathf.Abs( vertical );

        if( inputNumSize < 0.3f )
        {
            return Vector3.zero;
        }

        return new Vector3( horizontal, 0, -vertical );
    }


    // ジャンプ入力
    public bool JumpInput()
    {
        return Input.GetButtonDown( "Jump" );
    }


    // 武器切り替え入力
    public int WeaponChangeInput()
    {
        if( Input.GetButtonDown( "ChangeLeft" ) )
        {
            return -1;
        }

        if( Input.GetButtonDown( "ChangeRight" ) )
        {
            return +1;
        }

        return 0;
    }


    // 射撃入力
    public bool ShotInput()
    {
        return Input.GetButtonDown( "Shot" );
    }
}
