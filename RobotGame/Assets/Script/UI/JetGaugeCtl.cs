using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JetGaugeCtl : MonoBehaviour
{
    [SerializeField]
    private Image _jetGauge;

    [SerializeField]
    private PlayerStatus _playerStatus;

    [SerializeField]
    private PlayerManager _playerManager;

    [SerializeField]
    private InputManager _inputManager;

    // Update is called once per frame
    void Update()
    {
        // 残量がなくなったらｼﾞｪｯﾄ不可
        if(_playerStatus.Thruster <= 0)
        {
            _jetGauge.color = new Color(255, 0, 0, 255);
        }

        // ｼﾞｪｯﾄ可能のとき
        if (!_playerManager.IsThrusterEmpty)
        {
            // ｽﾍﾟｰｽｷｰ入力でｹﾞｰｼﾞを消費する
            if ( _inputManager.ThrusterInput( _playerManager.PlayerNumber ) )
            {
                _jetGauge.color = new Color(0, 218, 231, 255);
            }
        }

        // 通常は非表示
        if (_playerStatus.Thruster >= 100)
        {
            _jetGauge.color = new Color(0, 218, 231, 0);
        }   
        else
        {
            _jetGauge.color = new Color(0, 218, 231, 255);
        }

        float percentage = _playerStatus.Thruster/_playerStatus.ThrusterMax;

        // ﾛｰｶﾙ残量値をｽﾌﾟﾗｲﾄに渡す
        _jetGauge.fillAmount = percentage;
    }
}
