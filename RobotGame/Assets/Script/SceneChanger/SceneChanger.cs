using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad( this.gameObject );
    }


    // シーンの遷移
    public void ChangeScene( string sceneName )
    {
        SceneManager.LoadScene( sceneName );
    }
}