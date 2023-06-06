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

            heartText.text = "�c�胉�C�t " + GManager.instance.HeartNumB;
            heartText.text = GManager.instance.HeartNumB.ToString();
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă����");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldHeartNum != GManager.instance.HeartNumB)
        {
            heartText.text = "�c�胉�C�t " + GManager.instance.HeartNumB;
            //heartText.text = "�c�胉�C�t " + GManager.instance.HeartNumB;
            heartText.text = GManager.instance.HeartNumB.ToString();
            oldHeartNum = GManager.instance.HeartNumB;
        }
    }
}

