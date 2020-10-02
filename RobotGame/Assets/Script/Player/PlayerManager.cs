using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 入力管理
    [SerializeField] private InputManager inputManager_;

    // カメラ
    [SerializeField] private Camera camera_;

    // 移動速度
    private static readonly float Move_Velocity_ = 15.0f;

    // ジャンプ速度
    private static readonly float Jump_Velocity_ = 10.0f;

    // リジッドボディ
    private Rigidbody rigidBody_;

    // ジャンプ中か
    private bool isJump_;

    // 移動量
    private Vector3 moveDistance_;

    public Vector3 MoveDistance
    {
        get
        {
            return moveDistance_;
        }
    }


    // コンストラクタ
    private void Awake()
    {
        rigidBody_  = GetComponent<Rigidbody>();
        isJump_     = false;
        moveDistance_ = Vector3.zero;
    }


    // 更新
    private void Update()
    {
        Move();

        ForwardRotation();

        Jump();
    }


    // プレイヤーの移動
    private void Move()
    {
        Vector3 inputVector = inputManager_.MoveInput();

        Vector3 cameraForward = Vector3.Scale( camera_.transform.forward , new Vector3( 1, 0, 1 ) ).normalized;
        Vector3 moveForward = cameraForward*inputVector.z+camera_.transform.right*inputVector.x;

        moveDistance_ = moveForward*Move_Velocity_;

        rigidBody_.velocity = moveDistance_;
    }


    // プレイヤー回転
    private void ForwardRotation()
    {
        if( inputManager_.MoveInput() == Vector3.zero )
        {
            return;
        }

        Vector3 nowPosition = new Vector3( this.transform.position.x, 0, this.transform.position.z );
        Vector3 cameraPosition = new Vector3( camera_.transform.position.x, 0, camera_.transform.position.z );
        Vector3 forward = nowPosition-cameraPosition;

        this.transform.rotation = Quaternion.LookRotation( forward );
    }


    // ジャンプ
    private void Jump()
    {
        float jumpVelocity = 0.0f;

        if( isJump_ )
        {
            jumpVelocity = Jump_Velocity_;

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
                jumpVelocity = -Jump_Velocity_;
            }
        }

        rigidBody_.velocity = new Vector3( rigidBody_.velocity.x, jumpVelocity, rigidBody_.velocity.z );

        moveDistance_ = new Vector3( moveDistance_.x, jumpVelocity, moveDistance_.z );
    }
}