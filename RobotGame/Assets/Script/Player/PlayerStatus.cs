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
    [SerializeField] private float defencePower_;
    public float DefencePower
    {
        get
        {
            return defencePower_;
        }

        set
        {
            defencePower_ = value;
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
}