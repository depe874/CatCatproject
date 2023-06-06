using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomlistManager : MonoBehaviourPunCallbacks
{
    private const int MaxElements = 20;
    [SerializeField] private RoomListViewElement roomNamePrefab = default;
    private RoomList roomList = new RoomList();
    private List<RoomListViewElement> elementList = new List<RoomListViewElement>(MaxElements);
    private ScrollRect scrollRect;

    public void Init(Launcher parentView) {

        scrollRect = GetComponent<ScrollRect>();

        for (int i = 0; i < MaxElements; i++) {
            var element = Instantiate(roomNamePrefab, scrollRect.content);
            element.Init(parentView);
            element.Hide();
            elementList.Add(element);
        }
    }
    public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    {
        roomList.Update(changedRoomList);

        int index = 0;
        foreach (var room in roomList) {
            elementList[index++].Show(room);
        }


        for (int i = index; i < MaxElements; i++) {
            elementList[i].Hide();
        }
    }

}
