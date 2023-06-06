using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraCtrl: MonoBehaviour {
    [SerializeField] public CinemachineVirtualCamera[] vCamList;

    [SerializeField] public int unselectedPriority = 0;
    [SerializeField] public int selectedPriority = 10;
    private void Start() {
        vCamList[0].Priority = selectedPriority;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (vCamList[0].Priority == selectedPriority) {
                vCamList[0].Priority = unselectedPriority;
                vCamList[1].Priority = selectedPriority;
            } else {
                vCamList[1].Priority = unselectedPriority;
                vCamList[0].Priority = selectedPriority;
            }
        }
    }
}