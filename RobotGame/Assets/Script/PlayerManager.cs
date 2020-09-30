using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 入力管理
    [SerializeField] private InputManager inputManager_;

    // 移動速度
    private static readonly float Move_Velocity_ = 5.0f;

    // リジッドボディ
    Rigidbody rigidBody_;

    // 前回更新時の座標
    Vector3 lastPosition_;

    // ジャンプ中か
    bool isJump_;


    // コンストラクタ
    private void Awake()
    {
        lastPosition_ = Vector3.zero;
        rigidBody_  = GetComponent<Rigidbody>();
        isJump_     = false;
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
        
    }


    // 移動方向を向く
    private void FacingForward()
    {
        Vector3 nowPosition = new Vector3( this.transform.position.x, 0, this.transform.position.z );

        Vector3 difference = nowPosition-lastPosition_;

        if( difference.magnitude >= 0.01f )
        {
            this.transform.rotation = Quaternion.LookRotation( difference );
        }
    }


    // ジャンプ
    private void Jump()
    {
        float jumpVelocity = 0.0f;

        if( isJump_ )
        {
            jumpVelocity = 5.5f;

            if( 5.0f <= this.transform.position.y )
            {
                isJump_ = false;
            }
        }
        else
        {
            if( this.transform.position.y <= 0.1f )
            {
                if( inputManager_.JumpInput() )
                {
                    isJump_ = true;
                }

                this.transform.position = new Vector3( this.transform.position.x, 0.1f, this.transform.position.z );
            }

            if( this.transform.position.y <= 0.1f )
            {
                jumpVelocity = 0.0f;
            }
            else
            {
                jumpVelocity = -5.5f;
            }
        }

        rigidBody_.velocity = new Vector3( rigidBody_.velocity.x, jumpVelocity, rigidBody_.velocity.z );
    }
}