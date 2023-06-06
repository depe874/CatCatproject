using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HeartNumB : MonoBehaviour
{
    private Text heartText = null;
    private int oldHeartNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        heartText = GetComponent<Text>();
        if (GManager.instance != null)
        {

            heartText.text = "残りライフ " + GManager.instance.HeartNumB;
            heartText.text = GManager.instance.HeartNumB.ToString();
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れているよ");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldHeartNum != GManager.instance.HeartNumB)
        {
            heartText.text = "残りライフ " + GManager.instance.HeartNumB;
            //heartText.text = "残りライフ " + GManager.instance.HeartNumB;
            heartText.text = GManager.instance.HeartNumB.ToString();
            oldHeartNum = GManager.instance.HeartNumB;
        }
    }
}

