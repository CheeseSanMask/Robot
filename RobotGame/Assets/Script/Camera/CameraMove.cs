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
    private static readonly float Camera_Vertical_Velocity_ = 0.1f;

    // カメラ最大画角
    private static readonly float Camera_Max_Angle_ = 45;

    // カメラ最低画角
    private static readonly float Camera_Min_Angle_ = 360-Camera_Max_Angle_;

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
        CameraRotate();

        Move();
    }


    // カメラ移動
    private void Move()
    {
        this.rigidBody_.velocity = playerManager_.MoveDistance;
    }


    // カメラ回転
    private void CameraRotate()
    {
        Vector3 cameraInput = inputManager_.CameraInput( playerManager_.PlayerNumber );

        if( cameraInput == Vector3.zero )
        {
            return;
        }

        RotateAngleX( cameraInput );

        RotateAroundPlayer( cameraInput );
    }


    // 制限ありで縦に回転
    private void RotateAngleX( Vector3 cameraVector )
    {
        Vector3 rotateAngle = new Vector3( cameraVector.z*Camera_Vertical_Velocity_, 0, 0 );
        Vector3 rotateCameraAngle = this.transform.eulerAngles+rotateAngle;

        if( ( ( 0                       <=  rotateCameraAngle.x     )
        &&    ( rotateCameraAngle.x     <   Camera_Max_Angle_       ) )
        ||  ( ( Camera_Min_Angle_       <   rotateCameraAngle.x     )
        &&    ( rotateCameraAngle.x     <=  360                     ) )
        ){
            this.transform.eulerAngles = rotateCameraAngle;
        }
    }


    // プレイヤーの周囲を回転
    private void RotateAroundPlayer( Vector3 cameraVector )
    {
        this.transform.RotateAround( playerManager_.transform.position, Vector3.up, cameraVector.x*Camera_Horizontal_Velocity_ );
    }
}
