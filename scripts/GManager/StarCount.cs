using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCount : MonoBehaviour
{
    [Header("?v???C???[A?????")] public PlayerATriggerCheck playerACheck;
    [Header("?v???C???[B?????")] public PlayerBTriggerCheck playerBCheck;

    public Sound sound; //’Ç‰Á

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //?v???C???[????????????????
        if ((playerACheck.isOnA) || (playerBCheck.isOnB))
        {
            if (GManager.instance != null)
            {
                sound.isKeySound = true;    //’Ç‰Á
                GManager.instance.StarNum += 1;
                Destroy(this.gameObject);
            }
        }
    }
}