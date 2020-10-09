using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 体力
    [SerializeField] private float hitPoint_;
    public float HitPoint
    {
        get
        {
            return hitPoint_;
        }

        set
        {
            hitPoint_ = value;
        }
    }

    // 攻撃力
    [SerializeField] private float[] attackPower_;
    public float[] AttackPower
    {
        get
        {
            return attackPower_;
        }

        set
        {
            attackPower_ = value;
        }
    }

    // 防御力
    [SerializeField] private float guardPower_;
    public float GuardPower
    {
        get
        {
            return guardPower_;
        }

        set
        {
            guardPower_ = value;
        }
    }

    // 移動速度
    [SerializeField] private float moveSpeed_;
    public float MoveSpeed
    {
        get
        {
            return moveSpeed_;
        }

        set
        {
            moveSpeed_ = value;
        }
    }

    // リロード時間
    [SerializeField] private float[] reloadTime_;
    public float[] ReloadTime
    {
        get
        {
            return reloadTime_;
        }

        set
        {
            reloadTime_ = value;
        }
    }

    // 総弾数
    [SerializeField] private float[] allBulletCount_;
    public float[] AllBulletCount
    {
        get
        {
            return allBulletCount_;
        }

        set
        {
            allBulletCount_ = value;
        }
    }

    // 装弾数
    [SerializeField] private float[] ownedBulletCount_;
    public float[] OwnedBulletCount
    {
        get
        {
            return ownedBulletCount_;
        }

        set
        {
            ownedBulletCount_ = value;
        }
    }

    // スラスター
    [SerializeField] private float thruster_;
    public float Thruster
    {
        get
        {
            return thruster_;
        }

        set
        {
            thruster_ = value;
        }
    }

    // 最大体力
    private float hitPointMax_;
    public float HitPointMax
    {
        get
        {
            return hitPointMax_;
        }
    }

    // 最大攻撃力
    private float[] attackPowerMax_ = new float[(int)WeaponType.Max];
    public float[] AttackPowerMax
    {
        get
        {
            return attackPowerMax_;
        }
    }

    // 最大防御力
    private float guardPowerMax_;
    public float GuardPowerMax
    {
        get
        {
            return guardPowerMax_;
        }
    }

    // 最大移動速度
    private float moveSpeedMax_;
    public float MoveSpeedMax
    {
        get
        {
            return moveSpeedMax_;
        }
    }

    // 最大リロード時間
    [SerializeField]private float[] reloadTimeMax_ = new float[(int)WeaponType.Max];
    public float[] ReloadTimeMax
    {
        get
        {
            return reloadTimeMax_;
        }
    }

    // 最大総弾数
    private float[] allBulletCountMax_ = new float[(int)WeaponType.Max];
    public float[] AllBulletCounterMax
    {
        get
        {
            return allBulletCountMax_;
        }
    }

    // 最大装填数
    private float[] ownedBulletCountMax_ = new float[(int)WeaponType.Max];
    public float[] OwnedBulletCountMax
    {
        get
        {
            return ownedBulletCountMax_;
        }
    }

    // 最大スラスター容量
    private float thrusterMax_;
    public float ThrusterMax
    {
        get
        {
            return thrusterMax_;
        }
    }


    // 最大初期化
    private void Start()
    {
        hitPointMax_        = hitPoint_;
        guardPowerMax_      = guardPower_;
        moveSpeedMax_       = moveSpeed_;
        thrusterMax_        = thruster_;
       
        for( int number = 0; number < (int)WeaponType.Max; number++ )
        {
            attackPowerMax_[number]     = attackPower_[number];
            reloadTimeMax_[number]      = reloadTime_[number];
            allBulletCountMax_[number]  = allBulletCount_[number];

            int bulletCount = (int)allBulletCountMax_[number]/3;

            ownedBulletCountMax_[number] = bulletCount;
            ownedBulletCount_[number]    = ownedBulletCountMax_[number];
            allBulletCount_[number]     -= OwnedBulletCountMax[number];
        }
    }
}