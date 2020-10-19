using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class StatusLoader : MonoBehaviour
{
    // 武器データリスト
    private WeaponStatusData weaponStatusData_;

    // 装備データリスト
    private ArmorStatusData armorStatusData_;

    // プレイヤーデータリスト
    private PlayerStatusData playerStatusData_;


    private void LoadData()
    {
        Func<string, string> LoadDataToJson = ( string statusDataName ) =>
        {
            string jsonData = null;

            Addressables.LoadAssetAsync<string>( statusDataName ).Completed += json =>
            {
                jsonData = json.Result;
            };

            return jsonData;
        };

        weaponStatusData_   = JsonUtility.FromJson<WeaponStatusData>( LoadDataToJson( "WeaponStatusData" ) );
        armorStatusData_    = JsonUtility.FromJson<ArmorStatusData>( LoadDataToJson( "ArmorStatusData" ) );
        playerStatusData_   = JsonUtility.FromJson<PlayerStatusData>( LoadDataToJson( "PlayerStatusData" ) );
    }
}
