using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class GManager : MonoBehaviourPunCallbacks
{
    public static GManager instance = null;
    private PhotonView photonView = null;

    [Header("?��X?��R?��A")] public int score;
    [Header("?��?��?��݂̃X?��e?��[?��W")] public int StageNum;
    [Header("?��?��?��݂�A?��̎c?��@")] public int HeartNumA;
    [Header("?��?��?��݂�B?��̎c?��@")] public int HeartNumB;
    [Header("?��f?��t?��H?��?��?��g?��̎c?��@")] public int defaultHeartNum;
    public int CanNumA;
    public int CanNumB;
    public int StarNum;
    public float Keytime;
    public float Goaltime;
    public string PlayernameA;
    public string PlayernameB;
    public string Enemyname;
    [Header("?��?��?��݂̕�?��A?��ʒuA")] public int continueNumA;
    [Header("?��?��?��݂̕�?��A?��ʒuB")] public int continueNumB;
    [HideInInspector] public bool isGameOver = false;
    public bool StageClear = false;
    public bool keyGet = false;
    public float continueTimeA = 0.0f;
    public float continueTimeB = 0.0f;
    public int WinStage = 0;
    public int isWin = -2;
    public bool bgmMuteFlag = false;    //追加


    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //?��K?��?��?��P?���?��?��?��C?��?��?��X?��^?��?��?��X?��?��?��?��?��݂�?��Ȃ�?��悤?��ɂ�?��Ă�?��?��B?��?��?��?��?��Q?��[?��?��?��I?��u?��W?��F?��N?��g?��ɕ�?��?��?��t?��?��?��Ȃ�
    }

    //?��?��?��C?��t?��?��?��P?���?��炷(2?��C?��?��?��ꂼ?��?���??��?��\?��b?��h?��?��p?��?��)
    public void SubHeartNumA()
    {
        if (HeartNumA > 1)
        {
            --HeartNumA;
        }
        else
        {
            --HeartNumA;
            isGameOver = true;
        }
    }

    public void SubHeartNumB()
    {
        if (HeartNumB > 1)
        {
            --HeartNumB;
        }
        else
        {
            --HeartNumB;
            isGameOver = true;
        }
    }

    //?��ŏ�?��?��?��?��n?��߂鎞?��̏�?��?��?��F?��v?��ҏW
    public void RetryGame()
    {
        CanNumA = 0;
        CanNumB = 0;
        StarNum = 0;
        score = 0;
        Keytime = 0;
        keyGet = false;
        if(HeartNumA >= HeartNumB){
            HeartNumA--;
            if(HeartNumA == 0){
                isGameOver = true;
            }
        }else{
            HeartNumB--;
            if(HeartNumB == 0){
                isGameOver = true;
            }
        }
    }

    private void RequestOwner()
    {
        if (this.photonView.IsMine == false)
        {
            if (this.photonView.OwnershipTransfer != OwnershipOption.Request)
                Debug.LogError("Change OwnershipTransfer to Request");
            else
                this.photonView.RequestOwnership();
        }
    }

    public void LeaveRoom() {

        PhotonNetwork.LeaveRoom();

    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {

        PhotonNetwork.LoadLevel(5);
        Debug.Log("opponent left the room");

    }

    public void GoNextStage(){
        SceneManager.LoadScene("CharacterSelect");
        StageNum++;
        CanNumA = 0;
        CanNumB = 0;
        StarNum = 0;
        score = 0;
        Keytime = 0;
        Goaltime = 0;
        HeartNumA = 3;
        HeartNumB = 3;
        StageClear = false;
        keyGet = false;
        isGameOver = false;
    }
}
