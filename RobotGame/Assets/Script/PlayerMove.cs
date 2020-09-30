using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private enum JumpState
    {
        Rise,
        Fall,
        Ground
    }

    // 移動速度
    private static readonly float Move_Velocity_ = 5.0f;

    // リジッドボディ
    Rigidbody rigidBody_;

    // 前回更新時の座標
    Vector3 lastPosition_;

    // ジャンプ中か
    JumpState jumpState_;


    // コンストラクタ
    private void Awake()
    {
        lastPosition_ = Vector3.zero;
        rigidBody_ = GetComponent<Rigidbody>();
        jumpState_ = JumpState.Ground;
    }


    // 更新
    private void Update()
    {
        Move();

        FacingForward();

        Jump();

        lastPosition_ = new Vector3( this.transform.position.x, 0, this.transform.position.z );
    }


    // プレイヤーの移動
    private void Move()
    {
        float horizontal    =   Input.GetAxis(  "Horizontal"    );
        float vertical      =   Input.GetAxis(  "Vertical"      );

        rigidBody_.velocity = new Vector3( horizontal, 0, vertical )*Move_Velocity_;
    }


    // 移動方向を向く
    private void FacingForward()
    {
        Vector3 nowPosition = new Vector3( this.transform.position.x, 0, this.transform.position.z );

        Vector3 difference = nowPosition-lastPosition_;

        if( difference.magnitude >= 0.01f )
        {
            transform.rotation = Quaternion.LookRotation( difference );
        }
    }


    // ジャンプ
    private void Jump()
    {
        
    }
}