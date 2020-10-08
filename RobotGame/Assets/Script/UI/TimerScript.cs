using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private float remainTime;   // 残り秒数
    [SerializeField]
    private Text[] timerTexts;     // ﾀｲﾏｰ表示用ﾃｷｽﾄ

    // Start is called before the first frame update
    void Start()
    {
        remainTime = 155f;
    }

    // Update is called once per frame
    void Update()
    {
        // 制限時間が0以下は処理をしない
        if(remainTime <= 0)
        {
            return;
        }

        // 時間を経過させる
        remainTime -= Time.deltaTime;

        // ﾀｲﾏｰ表示用UIﾃｷｽﾄに時間を表示する
        for( int n = 0; n < timerTexts.Length; n++ )
        {
            timerTexts[n].text = remainTime.ToString("f2");
        }
        
        // 制限時間終了ﾛｸﾞ(ﾃｽﾄ@@@)
        if (remainTime <= 0f)
        {
            Debug.Log("制限時間終了");
        }
    }
}
