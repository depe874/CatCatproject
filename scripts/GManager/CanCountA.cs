using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCountA : MonoBehaviour
{
    [Header("�v���C���[A�̔���")] public PlayerATriggerCheck playerACheck;
    
    public Sound sound; //追加

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��������ɓ�������
        if (playerACheck.isOnA)
        {
            if (GManager.instance != null)
            {
                sound.isKeySound = true;    //追加
                GManager.instance.CanNumA += 1;
                Destroy(this.gameObject);
            }
        }
    }
}