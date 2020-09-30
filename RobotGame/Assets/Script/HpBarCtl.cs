using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtl : MonoBehaviour
{
    Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        // ｽﾗｲﾀﾞｰを取得する
        _slider = GameObject.Find("PlayerHpBar").GetComponent<Slider>();
    }


    // Update is called once per frame
    void Update()
    {
        float _hp = _slider.value;      // 現在の_sliderの値

        _hp += 0.05f;

        if(_hp > _slider.maxValue)
        {
            _hp = 0;
        }
        if(_hp < 0)
        {
            _hp = 0;
        }

        // HPｹﾞｰｼﾞに代替変数を設定
        _slider.value = _hp;
    }
}
