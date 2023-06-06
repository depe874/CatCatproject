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
            heartText.text = "�c�胉�C�t " + GManager.instance.HeartNumA;
            //heartText.text = "�c�胉�C�t " + GManager.instance.HeartNumA;
            heartText.text = GManager.instance.HeartNumA.ToString();
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă����");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldHeartNum != GManager.instance.HeartNumA)
        {
            heartText.text = "�c�胉�C�t " + GManager.instance.HeartNumA;
            heartText.text = GManager.instance.HeartNumA.ToString();
            oldHeartNum = GManager.instance.HeartNumA;
        }
    }
}

