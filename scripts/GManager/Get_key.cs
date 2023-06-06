using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_key : MonoBehaviour
{
    [Header("�v���C���[A�̔���")] public PlayerATriggerCheck playerACheck;
    [Header("�v���C���[B�̔���")] public PlayerBTriggerCheck playerBCheck;
    [Header("Canvas�̌��I�u�W�F�N�g")] public GameObject keyObj;

    public Sound sound; //追加

    void Start()
    {
        keyObj.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��������ɓ�������
        if ((playerACheck.isOnA) || (playerBCheck.isOnB))
        {
            keyObj.GetComponent<SpriteRenderer>().enabled = true;
            sound.isKeySound = true;    //追加
            Destroy(this.gameObject);
            GManager.instance.keyGet = true;

        }
    }
}
