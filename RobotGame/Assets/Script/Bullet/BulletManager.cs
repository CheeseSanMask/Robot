using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // リジッドボディ
    private Rigidbody rigidBody_;

    // 弾速
    [SerializeField] private float bulletSpeed_;

    // 火力
    [SerializeField] private float attackPower_;
    public float AttackPower
    {
        get
        {
            return attackPower_;
        }
    }

    // 進行方向
    private Vector3 moveDirection_;
    public Vector3 MoveDirection
    {
        get
        {
            return moveDirection_;
        }

        set
        {
            moveDirection_ = value;
        }
    }

    // 当たったか
    private bool isCollision_;

    // 親
    private int parentNumber_;
    public int ParentNumber
    {
        set
        {
            parentNumber_ = value;
        }
    }


    // コンストラクタ
    private void Awake()
    {
        rigidBody_ = GetComponent<Rigidbody>();

        isCollision_ = false;
    }


    // 更新
    private void Update()
    {
        Move();

        WaitDestroy();
    }


    // 移動
    private void Move()
    {
        rigidBody_.velocity = moveDirection_*bulletSpeed_;
    }


    // 5秒後に破壊
    private void WaitDestroy()
    {
        Destroy( this.gameObject, 5.0f );
    }


    // 着弾
    private void OnTriggerEnter( Collider collider )
    {
        if( isCollision_ )
        {
            return;
        }

        if( ( collider.name != "PL"+parentNumber_   )
        &&  ( collider.gameObject.layer == 8        )
        ){
            if( collider.tag == "PL"+( parentNumber_ == 2 ? 0 : 1 ) )
            {
                collider.GetComponent<PlayerManager>().HitDamege( attackPower_ );
            }
            else
            {
                
            }

            Destroy( this.gameObject, 0.1f );

            isCollision_ = true;
        }
    }
}
