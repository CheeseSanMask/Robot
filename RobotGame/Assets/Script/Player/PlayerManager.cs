using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 入力管理
    [SerializeField] private InputManager inputManager_;

    // カメラ
    [SerializeField] private CameraMove camera_;

    // プレイヤー番号
    [SerializeField] private int playerNumber_;
    public int PlayerNumber
    {
        get
        {
            return playerNumber_;
        }
    }

    // ジャンプ速度
    private static readonly float Jump_Velocity_ = 10.0f;

    // リジッドボディ
    private Rigidbody rigidBody_;

    // ステータス
    private PlayerStatus playerStatus_;

    // 最大装弾数
    private float owned_Bullet_Max_Number_;

    // ジャンプ中か
    private bool isJump_;

    // 武器リスト
    [SerializeField] private List<GameObject> weapons;

    //  現在の武器種類
    private WeaponType currentWeapon_;

    // サーチ対象オブジェクト
    List<GameObject> searchTargetObjects_ = new List<GameObject>();

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

        playerStatus_ = GetComponent<PlayerStatus>();

        owned_Bullet_Max_Number_ = playerStatus_.OwnedBulletNumber;

        isJump_     = false;

        currentWeapon_ = WeaponType.MainWeapon;

        moveDistance_ = Vector3.zero;
    }


    // 
    private void Start()
    {
        owned_Bullet_Max_Number_ = playerStatus_.AllBulletNumber/3;
        playerStatus_.AllBulletNumber -= owned_Bullet_Max_Number_;
        playerStatus_.OwnedBulletNumber = owned_Bullet_Max_Number_;
    }


    // 更新
    private void Update()
    {
        Move();

        Shot();

        Reload();

        ForwardRotation();

        Jump();

        WeaponChange();
    }


    // プレイヤーの移動
    private void Move()
    {
        Vector3 inputVector = inputManager_.MoveInput( playerNumber_ );

        Vector3 cameraForward = Vector3.Scale( camera_.transform.forward , new Vector3( 1, 0, 1 ) ).normalized;
        Vector3 moveForward = cameraForward*inputVector.z+camera_.transform.right*inputVector.x;

        moveDistance_ = moveForward*playerStatus_.MoveSpeed;

        rigidBody_.velocity = moveDistance_;
    }


    // 撃つ
    private void Shot()
    {
        if( inputManager_.ShotInput( playerNumber_ ) )
        {
            if( playerStatus_.OwnedBulletNumber <= 0 )
            {
                return;
            }

            BulletManager bullet = Instantiate( weapons[(int)currentWeapon_] ).GetComponent<BulletManager>();
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.LookRotation( this.transform.forward );
            bullet.AttackPower = playerStatus_.AttackPower;
            bullet.ParentNumber = playerNumber_;

            if( LockOn() != null )
            {
                bullet.MoveDirection = ( LockOn().transform.position-this.transform.position ).normalized;
            }
            else
            {
                bullet.MoveDirection = this.transform.forward;
            }

            --playerStatus_.OwnedBulletNumber;
        }
    }


    // プレイヤー回転
    private void ForwardRotation()
    {
        if( inputManager_.MoveInput( playerNumber_ ) == Vector3.zero )
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
                if( inputManager_.JumpInput( playerNumber_ ) )
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


    private void Reload()
    {
        if( ( !inputManager_.ReloadInput( playerNumber_ ) )
        ||  (  playerStatus_.OwnedBulletNumber == owned_Bullet_Max_Number_ )
        ){
            return;
        }

        float addBulletNumber = owned_Bullet_Max_Number_-playerStatus_.OwnedBulletNumber;

        if( playerStatus_.AllBulletNumber < addBulletNumber )
        {
            addBulletNumber = playerStatus_.AllBulletNumber;
            owned_Bullet_Max_Number_ = playerStatus_.AllBulletNumber;
        }

        playerStatus_.AllBulletNumber -= addBulletNumber;
        playerStatus_.OwnedBulletNumber = owned_Bullet_Max_Number_;
    }


    private void WeaponChange()
    {
        int moveNumber = inputManager_.WeaponChangeInput( playerNumber_ );

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


    // ロックオン
    private GameObject LockOn()
    {
        if( searchTargetObjects_.Count == 0 )
        {
            return null;
        }

        GameObject lockOnTarget_ = null;

        for( int number = 0; number < searchTargetObjects_.Count; number++ )
        {
            Vector3 direction = ( searchTargetObjects_[number].transform.position-camera_.transform.position ).normalized;

            Ray cameraToObject = new Ray( camera_.transform.position, direction );

            if( Physics.Raycast( cameraToObject ) )
            {
                if( searchTargetObjects_[number].tag == "PL2" )
                {
                    return searchTargetObjects_[number];
                }

                if( !lockOnTarget_ )
                {
                    lockOnTarget_ = searchTargetObjects_[number];
                }
                else
                {
                    Vector3 lockOnTargetDistance = lockOnTarget_.transform.position-camera_.transform.position;
                    Vector3 searchTargetDistance = searchTargetObjects_[number].transform.position-camera_.transform.position;

                    if( searchTargetDistance.magnitude < lockOnTargetDistance.magnitude )
                    {
                        lockOnTarget_ = searchTargetObjects_[number];
                    }
                }
            }
        }

        return lockOnTarget_;
    }


    // ダメージを受けた
    public void HitDamege( float damage )
    {
        float actuallyDamage = Mathf.Clamp( damage-playerStatus_.DefencePower, 5, damage );

        playerStatus_.HitPoint -= actuallyDamage;
    }


    // ロックオン圏内に入った
    private void OnTriggerEnter( Collider collider )
    {
        if( collider.gameObject.layer == 8 )
        {
            searchTargetObjects_.Add( collider.gameObject );
        }
    }


    // ロックオン圏内から出た
    private void OnTriggerExit( Collider collider )
    {
        for( int number = 0; number < searchTargetObjects_.Count; number++ )
        {
            if( searchTargetObjects_[number] == collider.gameObject )
            {
                searchTargetObjects_.Remove( collider.gameObject );

                return;
            }
        }
    }
}