using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReloadAnimCtl : MonoBehaviour
{
    [SerializeField]
    private Image _ReloAnim;

    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private PlayerManager _playerManager;

    // ｱﾆﾒｰｼｮﾝ再生用ｶｳﾝﾄ
    float animCnt = 0f;
    bool reloadFlag = false;

    // Update is called once per frame
    void Update()
    {
        // ﾘﾛｰﾄﾞをする
        if( _inputManager.ReloadInput( _playerManager.PlayerNumber ) )
        {
            reloadFlag = true;
        }
        // ﾘﾛｰﾄﾞ中のｱﾆﾒｰｼｮﾝをする
        if(reloadFlag)
        {
            // 毎ﾌﾚｰﾑ加算
            animCnt += 0.0005f;

            // 1周したら最初に戻す
            if (animCnt >= 1)
            {
                animCnt = 0;
                reloadFlag = false;
            }
        }

        // ｲﾒｰｼﾞｵﾌﾞｼﾞｪｸﾄに再生値を渡す
        _ReloAnim.fillAmount = animCnt;
    }
}
