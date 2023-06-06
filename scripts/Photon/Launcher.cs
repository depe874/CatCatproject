using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class Launcher: MonoBehaviourPunCallbacks {

    [SerializeField]
    private RoomlistManager roomListManager = default;
    public GameObject nameUI;
    public InputField playerName1;
    public InputField playerName2;
    public Button NameButton;
    public Button CreateButton;
    public InputField roomName;
    public GameObject roomListUI;
    public GameObject readyUI;
    public Text readymyname;
    public Text readyopname;
    public Button ReadyButton;
    public Text readyoptext;

    private void JoinLobby() {
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.JoinLobby();
        }
    }

    void Start() {
        PhotonNetwork.ConnectUsingSettings();
        NameButton.onClick.AddListener(OnNameButtonClick);
        CreateButton.onClick.AddListener(OnCreateButtonClick);
        ReadyButton.onClick.AddListener(OnReadyButtonClick);
        OnRoomNameInputFieldValueChanged(roomName.text);
        roomName.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        roomListManager.Init(this);
    }

    public override void OnConnected() {
        Debug.Log("Connected");
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.Log("Disconnected");
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to the Master");
        nameUI.SetActive(true);
        JoinLobby();
    }

    public override void OnJoinedLobby() {
        base.OnJoinedLobby();
        nameUI.SetActive(true);
    }

    public void OnNameButtonClick() {

        nameUI.SetActive(false);
        PhotonNetwork.NickName = playerName1.text + "   &   " + playerName2.text;
        GManager.instance.PlayernameA = playerName1.text;
        GManager.instance.PlayernameB = playerName2.text;

        if (PhotonNetwork.InLobby) {
            roomListUI.SetActive(true);
        }
        roomName.interactable = true;
    }

    public void OnCreateButtonClick() {

        roomName.interactable = false;
        RoomOptions options = new RoomOptions {
            MaxPlayers = 2
        };
        PhotonNetwork.CreateRoom(roomName.text, options,
            default);
        Debug.Log("create room " + roomName.text);

    }

    private void OnRoomNameInputFieldValueChanged(string value) {

        CreateButton.interactable = (value.Length > 0);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) {

        roomName.text = string.Empty;
        roomName.interactable = true;
    }

    public void OnJoiningRoom() {

        Debug.Log("joininggg...");

        roomName.interactable = false;
    }

    public override void OnJoinedRoom() {

        foreach (var p in PhotonNetwork.PlayerListOthers)
        {
          if( PhotonNetwork.NickName == p.NickName )
          {
              PhotonNetwork.LeaveRoom();
              PhotonNetwork.LoadLevel(2);
          }
        }

        Debug.Log("you joined room " + roomName.text);
        roomListUI.SetActive(false);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1) {
            readyUI.SetActive(true);
            readymyname.text = PhotonNetwork.NickName;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2) {

            readyUI.SetActive(true);
            readymyname.text = PhotonNetwork.NickName;

            foreach(var player in PhotonNetwork.PlayerListOthers) {
                readyopname.text = player.NickName;
                GManager.instance.Enemyname = readyopname.text;
            }

        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {

        foreach(var player in PhotonNetwork.PlayerListOthers) {
            readyopname.text = player.NickName;
            GManager.instance.Enemyname = readyopname.text;
        }

    }

    public void LeaveRoom() {

         PhotonNetwork.LeaveRoom();

    }

    public void OnReadyButtonClick() {

           ReadyButton.interactable = false;
           photonView.RPC(nameof(UpdateReady), RpcTarget.OthersBuffered);

        if (readyoptext.text == "Ready!") {
            photonView.RPC(nameof(StartGame), RpcTarget.All);
        }

    }

    [PunRPC]
    public void UpdateReady() {

        readyoptext.text = "Ready!";

    }

    [PunRPC]
    public void StartGame() {

        PhotonNetwork.LoadLevel(3);

    }

}