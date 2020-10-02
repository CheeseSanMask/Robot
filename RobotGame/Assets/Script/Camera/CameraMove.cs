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

    // カメラ
    private Camera camera_;

    // 破壊可能オブジェクト
    private GameObject[] destructibleObjects_;

    // 描画されている破壊可能オブジェクト
    List<GameObject> viewedObjects_ = new List<GameObject>();

    // 敵
    private GameObject enemy_;

    // ロックオンした対象
    private GameObject lockOnTarget_;
    public GameObject LockOnTarget
    {
        get
        {
            return lockOnTarget_;
        }
    }


    // コンストラクタ
    private void Awake()
    {
        rigidBody_ = GetComponent<Rigidbody>();

        camera_ = GetComponent<Camera>();

        destructibleObjects_ = GameObject.FindGameObjectsWithTag( "Destructible" );

        enemy_ = GameObject.FindGameObjectWithTag( "PL2" );

        lockOnTarget_ = null;
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
        Vector3 cameraInput = inputManager_.CameraInput();

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


    // ロックオン
    public bool LockOn()
    {
        lockOnTarget_ = null;

        if( 0 < viewedObjects_.Count )
        {
            viewedObjects_.Clear();
        }

        ChoiceViewedObject();

        return DecideLockOnTarget();

    }


    // 描画されている破壊可能オブジェクトの抽出
    private void ChoiceViewedObject()
    {
        RaycastHit hitObject;

        for( int number = 0; number < destructibleObjects_.Length; number++ )
        {
            Vector3 viewPosition = camera_.ViewportToWorldPoint( destructibleObjects_[number].transform.position );

            if( (   0                 < viewPosition.x      ) 
            &&  (   viewPosition.x    < 1.0f                )
            &&  (   0                 < viewPosition.y      )
            &&  (   viewPosition.y    < 1.0f                )
            ){
                Vector3 direction = destructibleObjects_[number].transform.position-this.transform.position;

                Ray cameraRay = new Ray( this.transform.position, direction.normalized );

                if( ( Physics.Raycast( cameraRay, out hitObject, 20.0f ) )
                &&  ( hitObject.transform.gameObject == destructibleObjects_[number] )
                ){
                    viewedObjects_.Add( destructibleObjects_[number] );
                }
            }
        }
    }


    // 敵が描画されているか
    private bool IsEnemyViewed()
    {
        Vector3 viewPosition = camera_.WorldToViewportPoint( enemy_.transform.position );

        if( (   0                 < viewPosition.x      ) 
        &&  (   viewPosition.x    < 1.0f                )
        &&  (   0                 < viewPosition.y      )
        &&  (   viewPosition.y    < 1.0f                )
        ){
            Vector3 direction = enemy_.transform.position-this.transform.position;

            Ray cameraRay = new Ray( this.transform.position, direction.normalized );

            RaycastHit hitObject;

            if ( ( Physics.Raycast( cameraRay, out hitObject, 20.0f ) )
            &&   ( hitObject.transform.gameObject == enemy_ )
            ){
                return true;
            }
        }

        return false;
    }


    // ロックオンする対象の確定
    private bool DecideLockOnTarget()
    {
        if (IsEnemyViewed())
        {
            lockOnTarget_ = enemy_;
        }
        else
        {
            for( int number = 0; number < viewedObjects_.Count; number++ )
            {
                if( lockOnTarget_ == null )
                {
                    lockOnTarget_ = viewedObjects_[number];
                }
                else
                {
                    Vector3 targetDistance = lockOnTarget_.transform.position-this.transform.position;
                    Vector3 objectDistance = viewedObjects_[number].transform.position-this.transform.position;

                    if( objectDistance.magnitude < targetDistance.magnitude )
                    {
                        lockOnTarget_ = viewedObjects_[number];
                    }
                }
            }
        }

        return ( lockOnTarget_ != null );

    }
}
