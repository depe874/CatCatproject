using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListViewElement : MonoBehaviour
{
    [SerializeField]
    private Text nameLabel;

    [SerializeField]
    private Text playerCounter;
    private Button button;
    private Launcher launcher;

    public void Init(Launcher parentView) {
        launcher = parentView;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("clicked");
        launcher.OnJoiningRoom();
        PhotonNetwork.JoinRoom(nameLabel.text);
    }

    public void Show(RoomInfo room) {
        Debug.Log("show");
        nameLabel.text = room.Name;
        playerCounter.text = string.Format("{0} / {1}", room.PlayerCount, room.MaxPlayers);
        button.interactable = (room.PlayerCount < room.MaxPlayers);
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}