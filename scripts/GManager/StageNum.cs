using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class StageNum : MonoBehaviour
{
    public Text stageText = null;
    private int oldStageNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        //stageText = GetComponent<Text>();
        if(GManager.instance != null)
        {
            stageText.text = "Stage " + GManager.instance.StageNum;
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă����");
            Destroy(this);
        }
    }

    void Update()
    {
        if(oldStageNum != GManager.instance.StageNum)
        {
            stageText.text = "Stage" + GManager.instance.StageNum;
            oldStageNum = GManager.instance.StageNum;
        }
    }
}
