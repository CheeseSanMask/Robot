using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // リジッドボディ
    private Rigidbody rigidBody_;

    [SerializeField] private float bulletSpeed_;

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


    // コンストラクタ
        private void Awake()
    {
        rigidBody_ = GetComponent<Rigidbody>();
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
}
