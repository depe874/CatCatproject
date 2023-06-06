using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Enemyname : MonoBehaviour
{
    private Text enemynameText = null;

    // Start is called before the first frame update
    void Start()
    {
        enemynameText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            enemynameText.text = "VS " + GManager.instance.Enemyname;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れているよ");
            Destroy(this);
        }
    }
}