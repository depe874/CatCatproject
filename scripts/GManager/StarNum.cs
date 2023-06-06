using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class StarNum : MonoBehaviour
{
    private Text starText = null;
    private int oldStarNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            starText.text = "�X�^�[ " + GManager.instance.StarNum;
            starText.text = GManager.instance.StarNum.ToString();
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă����");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldStarNum != GManager.instance.StarNum)
        {
            starText.text = "�X�^�[ " + GManager.instance.StarNum;
            starText.text = GManager.instance.StarNum.ToString();
            oldStarNum = GManager.instance.StarNum;
        }
    }
}
