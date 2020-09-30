using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private float remainTime;   // 残り秒数
    private Text timerText;     // ﾀｲﾏｰ表示用ﾃｷｽﾄ

    // Start is called before the first frame update
    void Start()
    {
        remainTime = 155f;
        timerText = GameObject.Find("Text").GetComponentInChildren<Text>();
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
        timerText.text = remainTime.ToString("f2");


        if(remainTime <= 0f)
        {
            Debug.Log("制限時間終了");
        }
    }
}
