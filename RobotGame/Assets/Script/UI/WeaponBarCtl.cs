using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBarCtl : MonoBehaviour
{
    [SerializeField]
    private Slider[] _bar;

    [SerializeField]
    private Text[] _remain;

    [SerializeField]
    private Image[] _reloAnim;

    [SerializeField]
    private PlayerManager _playerManager;

    [SerializeField]
    private PlayerStatus _playerStatus;

    [SerializeField]
    private InputManager _inputManager;
    

    // Update is called once per frame
    void Update()
    {
        for( int number = 0; number < (int)WeaponType.Max; ++number )
        {
            _remain[number].text = _playerStatus.OwnedBulletCount[number].ToString("000");
            
            float percentage = _playerStatus.OwnedBulletCount[number]/_playerStatus.OwnedBulletCountMax[number];
            _bar[number].value = percentage;
        }

        if( _playerManager.IsReload )
        {
            float percentage = 1-_playerStatus.ReloadTime[_playerManager.CurrentWeapon]/_playerStatus.ReloadTimeMax[_playerManager.CurrentWeapon];
            
            _reloAnim[_playerManager.CurrentWeapon].fillAmount = percentage;
            _bar[_playerManager.CurrentWeapon].value = percentage;
        }
        else
        {
            _reloAnim[_playerManager.CurrentWeapon].fillAmount = 0;
        }
    }
}
