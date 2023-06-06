using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject SStage;
    public GameObject SChara;
    public float limitTime;
    private float elapsedTime;
    public Text timerText = null;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        //timerText = GetComponent<Text>();
        SStage.SetActive(true);
        SChara.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = ((int)(limitTime-elapsedTime)).ToString();
        if(elapsedTime >= limitTime){
            SStage.SetActive(false);
            SChara.SetActive(true);
        }
    }
}
