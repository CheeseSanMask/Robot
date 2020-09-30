using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("PlayerHpBar").GetComponent<Slider>();
    }

    float damage = 10;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            _slider.value -= damage;
            Debug.Log("ダメージ！");
        }
    }
}
