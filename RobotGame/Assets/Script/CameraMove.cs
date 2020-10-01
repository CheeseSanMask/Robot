using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // 入力管理
    [SerializeField] private InputManager inputManager_;

    // プレイヤー管理
    [SerializeField] private PlayerManager playerManager_;

    // カメラ速度
    private static readonly float Camera_Horizontal_Velocity_ = 0.5f;

    // カメラ速度
    private static readonly float Camera_Vertical_Velocity_ = 0.05f;

    // リジッドボディ
    private Rigidbody rigidBody_;


    // コンストラクタ
    private void Awake()
    {
        rigidBody_ = GetComponent<Rigidbody>();
    }


    // 更新
    private void Update()
    {
        Move();

        CameraRotate();
    }


    // カメラ移動
    private void Move()
    {
        rigidBody_.velocity = playerManager_.MoveDistance;
    }


    // カメラ回転
    private void CameraRotate()
    {
        Vector3 cameraInput = inputManager_.CameraInput();

        this.transform.RotateAround( playerManager_.transform.position, Vector3.up, cameraInput.x*Camera_Horizontal_Velocity_ );
    }
}
