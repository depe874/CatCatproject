using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class Goal: MonoBehaviour {
    private PhotonView photonView = null;
    [Header("�v���C���[A����")] public PlayerATriggerCheck triggerA;
    [Header("�v���C���[B����")] public PlayerBTriggerCheck triggerB;

    public AudioSource audio; //追加
    public AudioClip goalSound; //追加
    //public GameObject Congraturationsimg;
    private bool soundflag = false;
    private bool sendflag = false;

    void Awake() {
        photonView = GetComponent < PhotonView > ();
    }

    void Start() {
        this.audio = GetComponent < AudioSource > (); //追加
        //Congraturationsimg.SetActive(false);
    }

    void Update() {
        if (GManager.instance.isGameOver) {
            GManager.instance.Keytime = 0;
            GManager.instance.Goaltime = 0;
            Invoke("GameOver", 3.5f);

        }
        if (triggerA.isOnA && triggerB.isOnB) {
            if (Input.GetKey(KeyCode.Return)) {
                if (GManager.instance.keyGet) {
                    if (!soundflag) {
                        audio.PlayOneShot(goalSound); //追加, 音鳴らす
                        soundflag = true;
                        Debug.Log("goal!");
                    }
                    //Congraturationsimg.SetActive(true);
                    GManager.instance.StageClear = true;
                    Invoke("GameOver", 4f);
                }
            }
        }
    }

    [PunRPC]
    public void FinishGame() {
        PhotonNetwork.LoadLevel(5);
    }

    public void GameOver() {
        if(!sendflag){
            photonView.RPC(nameof(FinishGame), RpcTarget.All);
            sendflag = true;
        }
    }
}