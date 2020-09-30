using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReloadAnimCtl : MonoBehaviour
{
    Image _ReloAnim;

    // Start is called before the first frame update
    void Start()
    {
        // ｲﾒｰｼﾞを取得する
        _ReloAnim = GameObject.Find("ReloadGauge").GetComponent<Image>();
    }

    // ｱﾆﾒｰｼｮﾝ再生用ｶｳﾝﾄ
    float animCnt = 0f;

    // Update is called once per frame
    void Update()
    {
        // 毎ﾌﾚｰﾑ加算
        animCnt += 0.0005f;

        // 1周したら最初に戻す
        if(animCnt >= 1)
        {
            animCnt = 0;
        }

        // ｲﾒｰｼﾞｵﾌﾞｼﾞｪｸﾄに再生値を渡す
        _ReloAnim.fillAmount = animCnt;
    }
}
