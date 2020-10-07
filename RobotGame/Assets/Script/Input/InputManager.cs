using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerManager[] players_;

    // AIモード
    [SerializeField] private bool isAI_;


    // 移動入力
    public Vector3 MoveInput( int number )
    {
        float horizontal = Input.GetAxis(  "Horizontal_"+number    );
        float vertical   = Input.GetAxis(  "Vertical_"+number      );

        float inputNumSize = Mathf.Abs( horizontal )+Mathf.Abs( vertical );

        if( inputNumSize < 0.3f )
        {
            return Vector3.zero;
        }

        return new Vector3( horizontal, 0, vertical );
    }


    // カメラ入力
    public Vector3 CameraInput( int number )
    {
        float horizontal = Input.GetAxis(  "CameraHorizontal_"+number    );
        float vertical   = Input.GetAxis(  "CameraVertical_"+number      );

        float inputNumSize = Mathf.Abs( horizontal )+Mathf.Abs( vertical );

        if( inputNumSize < 0.3f )
        {
            return Vector3.zero;
        }

        return new Vector3( horizontal, 0, -vertical );
    }


    // ジャンプ入力
    public bool JumpInput( int number )
    {
        return Input.GetButtonDown( "Jump_"+number );
    }


    // 武器切り替え入力
    public int WeaponChangeInput( int number )
    {
        if( Input.GetButtonDown( "ChangeLeft_"+number ) )
        {
            return -1;
        }

        if( Input.GetButtonDown( "ChangeRight_"+number ) )
        {
            return +1;
        }

        return 0;
    }


    // 射撃入力
    public bool ShotInput( int number )
    {
        return Input.GetButtonDown( "Shot_"+number );
    }


    // リロード入力
    public bool ReloadInput( int number )
    {
        return Input.GetButtonDown( "Reload_"+number );
    }
}
