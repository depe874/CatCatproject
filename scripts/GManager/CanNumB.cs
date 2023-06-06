using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CanNumB : MonoBehaviour
{
    private Text canText = null;
    private int oldCanNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        canText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            canText.text = "���Ί� " + GManager.instance.CanNumB;
            canText.text = GManager.instance.CanNumB.ToString();
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă����");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldCanNum != GManager.instance.CanNumB)
        {
            canText.text = "���Ί� " + GManager.instance.CanNumB;
            canText.text = GManager.instance.CanNumB.ToString();
            oldCanNum = GManager.instance.CanNumB;
        }
    }
}
