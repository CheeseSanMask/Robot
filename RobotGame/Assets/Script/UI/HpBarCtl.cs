using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtl : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus _playerStatus;

    [SerializeField]
    private Slider _slider;


    // Update is called once per frame
    void Update()
    {
        float percentage = _playerStatus.LifePoint/_playerStatus.HitPointMax;

        _slider.value = percentage;
    }
}
