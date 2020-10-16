using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] public class WeaponData
{
    // 火力
    public float attackPower_;

    // リロード時間
    public float reloadTime_;

    // 総弾数
    public float allBulletCount_;

    // 装填数
    public float ownedBulletCount_;
}


[Serializable] public class ArmorData
{
    // 体力バフ
    public float lifePointBuff_;

    // 防御力
    public float guardPower_;

    // 移動速度デバフ
    public float moveSpeedDebuff_;
}


[Serializable] public class PlayerData
{
    // 体力
    public float lifePoint_;

    // 移動速度
    public float moveSpeed_;

    // スラスター
    public float thruster_;
}


public class StatusLoader : MonoBehaviour
{
    private void Start()
    {
        WeaponData weapon           = new WeaponData();
        weapon.attackPower_         = 20;
        weapon.reloadTime_          = 10;
        weapon.allBulletCount_      = 105;
        weapon.ownedBulletCount_    = 30;

        ArmorData armor         = new ArmorData();
        armor.lifePointBuff_    = 10;
        armor.guardPower_       = 10;
        armor.moveSpeedDebuff_  = 5;

        PlayerData player   = new PlayerData();
        player.lifePoint_   = 100;
        player.moveSpeed_   = 30;
        player.thruster_    = 100;

        string weaponJson   = JsonUtility.ToJson( weapon    );
        string armorJson    = JsonUtility.ToJson( armor     );
        string playerJson   = JsonUtility.ToJson( player    );

        string path = Application.dataPath+"/EquipmentData/";

        StreamWriter weaponWriter   = new StreamWriter( path+"WeaponData.json",  false );
        StreamWriter armorWriter    = new StreamWriter( path+"ArmorData.json",   false );
        StreamWriter playerWriter   = new StreamWriter( path+"PlayerData.json",  false );
        
        weaponWriter.WriteLine( weaponJson );
        armorWriter.WriteLine( armorJson );
        playerWriter.WriteLine( playerJson );

        weaponWriter.Flush();
        armorWriter.Flush();
        playerWriter.Flush();

        weaponWriter.Close();
        armorWriter.Close();
        playerWriter.Close();
    }
}
