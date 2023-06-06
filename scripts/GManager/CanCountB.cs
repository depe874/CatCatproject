using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCountB : MonoBehaviour
{
    [Header("�v���C���[B�̔���")] public PlayerBTriggerCheck playerBCheck;

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��������ɓ�������
        if (playerBCheck.isOnB)
        {
            if (GManager.instance != null)
            {
                GManager.instance.CanNumB += 1;
                Destroy(this.gameObject);
            }
        }
    }
}