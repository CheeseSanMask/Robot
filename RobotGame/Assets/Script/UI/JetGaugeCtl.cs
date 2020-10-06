using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JetGaugeCtl : MonoBehaviour
{
    Image _jetGauge;

    // Start is called before the first frame update
    void Start()
    {
        // ｽﾌﾟﾗｲﾄを取得する
        _jetGauge = GameObject.Find("JetGauge").GetComponent<Image>();
    }

    bool restFlag = false;      // 強制停止ﾌﾗｸﾞ

    // Update is called once per frame
    void Update()
    {
        // ﾛｰｶﾙ残量に現在の量を代入
        float remainJet = _jetGauge.fillAmount;

        // 残量がなくなったらｼﾞｪｯﾄ不可
        if(remainJet <= 0)
        {
            restFlag = true;
            _jetGauge.color = new Color(255, 0, 0, 255);
        }

        // ｼﾞｪｯﾄ可能のとき
        if (restFlag == false)
        {
            // ｽﾍﾟｰｽｷｰ入力でｹﾞｰｼﾞを消費する
            if (Input.GetKey("space"))
            {
                remainJet -= 0.001f;
                _jetGauge.color = new Color(0, 218, 231, 255);
            }
            else
            {
                // 最大値まで回復する
                if (remainJet < 1)
                {
                    remainJet += 0.00025f;
                }
            }
        }
        else
        {
            // 通常時よりゆっくり回復する
            remainJet += 0.0001f;
            if (remainJet >= 1)
            {
                restFlag = false;
            }
        }

        // 通常は非表示
        if (remainJet >= 1)
        {
            _jetGauge.color = new Color(0, 218, 231, 0);
        }
        // ﾛｰｶﾙ残量値をｽﾌﾟﾗｲﾄに渡す
        _jetGauge.fillAmount = remainJet;
    }
}
