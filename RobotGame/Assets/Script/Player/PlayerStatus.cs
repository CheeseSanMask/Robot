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
    [SerializeField] private float attackPower_;
    public float AttackPower
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

    // リロード速度
    [SerializeField] private float reloadSpeed_;
    public float ReloadSpeed
    {
        get
        {
            return reloadSpeed_;
        }

        set
        {
            reloadSpeed_ = value;
        }
    }

    // 合計段数
    [SerializeField] private float allBulletNumber_;
    public float AllBulletNumber
    {
        get
        {
            return allBulletNumber_;
        }

        set
        {
            allBulletNumber_ = value;
        }
    }

    // 装弾数
    [SerializeField] private float ownedBulletNumber_;
    public float OwnedBulletNumber
    {
        get
        {
            return ownedBulletNumber_;
        }

        set
        {
            ownedBulletNumber_ = value;
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
    private float attackPowerMax_;
    public float AttackPowerMax
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

    // 最大リロード速度
    private float reloadSpeedMax_;
    public float ReloadSpeedMax
    {
        get
        {
            return reloadSpeedMax_;
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
        hitPointMax_    = hitPoint_;
        attackPowerMax_ = attackPower_;
        guardPowerMax_  = guardPower_;
        moveSpeedMax_   = moveSpeed_;
        reloadSpeedMax_ = reloadSpeed_;
        thrusterMax_    = thruster_;
    }
}