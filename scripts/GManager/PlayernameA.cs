using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayernameA : MonoBehaviour
{
    private Text playernameText = null;

    // Start is called before the first frame update
    void Start()
    {
        playernameText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            playernameText.text = GManager.instance.PlayernameA;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れているよ");
            Destroy(this);
        }
    }
}