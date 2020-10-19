using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] public class StatusData : MonoBehaviour
{
    // 名前
    public string[] name_;
}


public class WeaponStatusData : StatusData
{
    // 火力
    public float[] attackPower_;

    // リロード時間
    public float[] reloadTime_;

    // 総弾数
    public float[] allBulletCount_;

    // 装填数
    public float[] ownedBulletCount_;
}



public class ArmorStatusData : StatusData
{
    // 体力バフ
    public float[] lifePointBuff_;

    // 防御力
    public float[] guardPower_;

    // 移動速度デバフ
    public float[] moveSpeedDebuff_;
}


public class PlayerStatusData : StatusData
{
    // 体力
    public float[] lifePoint_;

    // 移動速度
    public float[] moveSpeed_;

    // スラスター
    public float[] thruster_;
}