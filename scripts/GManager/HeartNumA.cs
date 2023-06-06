using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HeartNumA : MonoBehaviour
{
    private Text heartText = null;
    private int oldHeartNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        heartText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            heartText.text = "残りライフ " + GManager.instance.HeartNumA;
            //heartText.text = "残りライフ " + GManager.instance.HeartNumA;
            heartText.text = GManager.instance.HeartNumA.ToString();
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れているよ");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldHeartNum != GManager.instance.HeartNumA)
        {
            heartText.text = "残りライフ " + GManager.instance.HeartNumA;
            heartText.text = GManager.instance.HeartNumA.ToString();
            oldHeartNum = GManager.instance.HeartNumA;
        }
    }
}

