using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText = null;
    public Text keyTimeText = null;
    private float elapsedTime;
    private float keyTime;
    public int minute = 0;
    public int second = 0;
    public int kminute = 0;
    public int ksecond = 0;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = GManager.instance.Goaltime;
        keyTime = 0;
        
        if (GManager.instance != null)
        {
            
        }
        else
        {
            Debug.Log("miss game manager");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkEnd();
        checkKey();
    }

    void countTime(){
        elapsedTime += Time.deltaTime;
        minute = ((int)(elapsedTime))/60;
        second = ((int)(elapsedTime))%60;
        if(second < 10){
            timeText.text = minute.ToString() + ":0" + second.ToString();
        }else{
            timeText.text = minute.ToString() + ":" + second.ToString();
        }
    }
    void countKeyTime(){
        keyTime += Time.deltaTime;
        kminute = ((int)(keyTime))/60;
        ksecond = ((int)(keyTime))%60;
        if(ksecond < 10){
            keyTimeText.text = minute.ToString() + ":0" + second.ToString();
        }else{
            keyTimeText.text = minute.ToString() + ":" + second.ToString();
        }
    }

    void checkEnd(){
        if(!GManager.instance.StageClear){
            countTime();
        }else{
            GManager.instance.Goaltime = elapsedTime;
        }

    }

    void checkKey(){
        if(!GManager.instance.keyGet){
            countKeyTime();
        }else{
            GManager.instance.Keytime = keyTime;
        }

    }
}
