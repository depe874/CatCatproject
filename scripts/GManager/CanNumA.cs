using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CanNumA : MonoBehaviour
{
    private Text canText = null;
    private int oldCanNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        canText = GetComponent<Text>();
        if (GManager.instance != null)
        {

            canText.text = "���Ί� " + GManager.instance.CanNumA;
            canText.text = GManager.instance.CanNumA.ToString();
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă����");
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldCanNum != GManager.instance.CanNumA)
        {
            canText.text = "���Ί� " + GManager.instance.CanNumA;
            canText.text = GManager.instance.CanNumA.ToString();
            oldCanNum = GManager.instance.CanNumA;
        }
    }
}
