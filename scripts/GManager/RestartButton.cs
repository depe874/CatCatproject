using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private bool firstPush = false;


    public void PressStart()
    {
        Debug.Log("Press retry");
        if (!firstPush)
        {
            Debug.Log("retry");
            //���l��ێ����鉽��
            GManager.instance.RetryGame();
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
            firstPush = true;
        }
    }
}
