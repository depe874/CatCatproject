using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject shadow1;
    public GameObject shadow2;
    private int index1 = 0;
    private int index2 = 1;
    static public int p1choose;
    static public int p2choose;
    private bool p1ok = false;
    private bool p2ok = false;
    private Animator anim1;
    private Animator anim2;

    // Start is called before the first frame update
    void Start()
    {
        anim1 = arrow1.GetComponent<Animator>();
        anim2 = arrow2.GetComponent<Animator>();
        shadow1.SetActive(false);
        shadow2.SetActive(false);
        anim1.SetBool("Selected", false);
        anim2.SetBool("Selected", false);

    }

    // Update is called once per frame
    void Update()
    {
        anim1 = arrow1.GetComponent<Animator>();
        anim2 = arrow2.GetComponent<Animator>();
        MoveArrow(index1, arrow1, shadow1);
        MoveArrow(index2, arrow2, shadow2);

        if (Input.GetKeyDown(KeyCode.D))
        {
            index1 ++;
            if(index1 > 2)  index1 = 0;
            if(index1 == index2){
                index1 ++;
                if(index1 > 2)  index1 = 0;
            }
            //Debug.Log(index1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            index1 --;
            if (index1 < 0) index1 = 2;
            if(index1 == index2){
                index1 --;
                if (index1 < 0) index1 = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index2 ++;
            if(index2 > 2)  index2 = 0;
            if(index2 == index1){
                index2 ++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index2 --;
            if (index2 < 0) index2 = 2;
            if(index2 == index1){
                index2 --;
                if (index2 < 0) index2 = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.S)){
            p1choose = index1;
            p1ok = true;
            shadow1.SetActive(true);
            anim1.SetBool("Selected", true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            p2choose = index2;
            p2ok = true;
            shadow2.SetActive(true);
            anim2.SetBool("Selected", true);
        }
        if(p1ok && p2ok){
            //Debug.Log("go to stage scene");
            switch(GManager.instance.StageNum){
                case 1:
                    SceneManager.LoadScene("Stage1");
                    break;
                case 2:
                    SceneManager.LoadScene("Stage2");
                    break;
                case 3:
                    SceneManager.LoadScene("Stage3");
                    break;
                default:
                    Debug.Log("Stagenum error");
                    break;
                }
        }
    }

    void MoveArrow(int recentnum, GameObject arrow, GameObject shadow){
        Vector3 v0 = new Vector3(-4.2f, 2f, 0f);
        Vector3 v1 = new Vector3(0f, 2f, 0f);
        Vector3 v2 = new Vector3(4.5f, 2f, 0f);
        Vector3 v3 = new Vector3(0f, -2.2f, 0f);
        switch(recentnum){
            case 0:
                arrow.transform.position = v0;
                break;
            case 1:
                arrow.transform.position = v1;
                break;
            case 2:
                arrow.transform.position = v2;
                break;
            default:
                break;
        }
        shadow.transform.position = arrow.transform.position + v3;
    }

    public static int getP1choose(){
        return p1choose;
    }
    public static int getP2choose(){
        return p2choose;
    }

}
