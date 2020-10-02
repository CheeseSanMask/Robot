using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 入力管理
    [SerializeField] private InputManager inputManager_;

    // カメラ
    [SerializeField] private CameraMove camera_;

    // 移動速度
    private static readonly float Move_Velocity_ = 15.0f;

    // ジャンプ速度
    private static readonly float Jump_Velocity_ = 10.0f;

    // リジッドボディ
    private Rigidbody rigidBody_;

    // ジャンプ中か
    private bool isJump_;

    // 武器リスト
    [SerializeField] private List<GameObject> weapons;

    //  現在の武器種類
    private WeaponType currentWeapon_;

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

        currentWeapon_ = WeaponType.MainWeapon;

        moveDistance_ = Vector3.zero;
    }


    // 更新
    private void Update()
    {
        Move();

        Shot();

        ForwardRotation();

        Jump();

        WeaponChange();
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


    // 撃つ
    private void Shot()
    {
        if( inputManager_.ShotInput() )
        {
            BulletManager bullet = Instantiate( weapons[(int)currentWeapon_] ).GetComponent<BulletManager>();
            bullet.transform.position = this.transform.position+this.transform.forward*2;
            bullet.transform.rotation = Quaternion.LookRotation( this.transform.forward );

            if( camera_.LockOn() )
            {
                if( camera_.LockOnTarget != null )
                {
                    bullet.MoveDirection = ( camera_.LockOnTarget.transform.position-this.transform.position ).normalized;
                }
            }
            else
            {
                bullet.MoveDirection = this.transform.forward;
            }
        }
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


    private void WeaponChange()
    {
        int moveNumber = inputManager_.WeaponChangeInput();

        if ( moveNumber == 0 )
        {
            return;
        }

        int nextWeaponNumber = (int)currentWeapon_+moveNumber;

        if( nextWeaponNumber < 0 )
        {
            nextWeaponNumber = (int)WeaponType.Max-1;
        }

        if( (int)WeaponType.Max-1 < nextWeaponNumber )
        {
            nextWeaponNumber = 0;
        }

        currentWeapon_ = (WeaponType)nextWeaponNumber;
    }
}