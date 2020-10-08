using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBarCtl : MonoBehaviour
{
    [SerializeField]
    private Slider _mainBar;

    [SerializeField]
    private Slider _subBar;

    [SerializeField]
    private Text _mainRemain;

    [SerializeField]
    private Text _subRemain;

    [SerializeField]
    private Image _mainReloAnim;

    [SerializeField]
    private Image _subReloAnim;

    float mainAnimCnt = 0f;
    float subAnimCnt = 0f;
    bool mainReloFlag = false;
    bool subReloFlag = false;

    // Update is called once per frame
    void Update()
    {
        float mainOwn = _mainBar.value;
        float subOwn = _subBar.value;

        
        // ﾒｲﾝ武器使用
        if(!mainReloFlag)
        {
            _mainRemain.text = ((int)_mainBar.value).ToString("000");
            //if (Input.GetMouseButtonDown(0))
            {
                mainOwn--;
            }
        }
        else
        {
            // 毎ﾌﾚｰﾑ加算
            mainAnimCnt += 0.0015f;
            mainOwn += 0.001f;
            // 1周したら最初に戻す
            if (mainAnimCnt >= 1)
            {
                mainAnimCnt = 0;
            }
            // ﾘﾛｰﾄﾞ完了で状態解除
            if (mainOwn >= _mainBar.maxValue)
            {
                mainReloFlag = false;
                mainAnimCnt = 0;
            }
        }

        // ｻﾌﾞ武器使用
        if(!subReloFlag)
        {
            _subRemain.text = ((int)_subBar.value).ToString("000");
            //if (Input.GetMouseButtonDown(1))
            {
                subOwn--;
            }
        }
        else
        {
            // 毎ﾌﾚｰﾑ加算
            subAnimCnt += 0.0015f;
            subOwn += 0.001f;
            // 1周したら最初に戻す
            if (subAnimCnt >= 1)
            {
                subAnimCnt = 0;
            }
            // ﾘﾛｰﾄﾞ完了で状態解除
            if (subOwn >= _subBar.maxValue)
            {
                subReloFlag = false;
                subAnimCnt = 0;
            }
        }


        // ｲﾒｰｼﾞｵﾌﾞｼﾞｪｸﾄに再生値を渡す
        _mainReloAnim.fillAmount = mainAnimCnt;
        _subReloAnim.fillAmount = subAnimCnt;

        // ｵﾌﾞｼﾞｪｸﾄの値にﾛｰｶﾙ変数を代入
        _mainBar.value = mainOwn;
        _subBar.value = subOwn;

        // 残弾切れでﾘﾛｰﾄﾞ状態に変化
        if(_mainBar.value <= 0)
        {
            _mainRemain.text = ((int)_mainBar.value).ToString("000");
            mainReloFlag = true;
        }
        if(_subBar.value <= 0)
        {
            _subRemain.text = ((int)_subBar.value).ToString("000");
            subReloFlag = true;
        }
    }
}
