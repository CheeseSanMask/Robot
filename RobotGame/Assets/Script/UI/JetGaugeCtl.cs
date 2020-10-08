using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JetGaugeCtl : MonoBehaviour
{
    [SerializeField]
    private Image _jetGauge;

    [SerializeField]
    private PlayerStatus _playerStatus;

    bool restFlag = false;      // 強制停止ﾌﾗｸﾞ

    // Update is called once per frame
    void Update()
    {
        // 残量がなくなったらｼﾞｪｯﾄ不可
        if(_playerStatus.Thruster <= 0)
        {
            restFlag = true;
            _jetGauge.color = new Color(255, 0, 0, 255);
        }

        // ｼﾞｪｯﾄ可能のとき
        //if (restFlag == false)
        //{
        //    // ｽﾍﾟｰｽｷｰ入力でｹﾞｰｼﾞを消費する
        //    if(  )
        //    {
        //        _jetGauge.color = new Color(0, 218, 231, 255);
        //    }
        //    //else
        //    {
        //        // 最大値まで回復する
        //        if (remainJet < 1)
        //        {
        //            remainJet += 0.00025f;
        //        }
        //    }
        //}
        //else
        //{
        //    // 通常時よりゆっくり回復する
        //    remainJet += 0.0001f;
        //    if (remainJet >= 1)
        //    {
        //        restFlag = false;
        //    }
        //}

        // 通常は非表示
        if (_playerStatus.Thruster >= 100)
        {
            _jetGauge.color = new Color(0, 218, 231, 0);
        }
        else
        {
            _jetGauge.color = new Color(0, 218, 231, 255);
        }

        float percentage = _playerStatus.Thruster/_playerStatus.ThrusterMax;

        // ﾛｰｶﾙ残量値をｽﾌﾟﾗｲﾄに渡す
        _jetGauge.fillAmount = percentage;
    }
}
