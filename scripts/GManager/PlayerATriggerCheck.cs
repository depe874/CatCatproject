using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATriggerCheck : MonoBehaviour
{
    // 判定内にプレイヤーがいる
    [HideInInspector] public bool isOnA = false;

    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(" PlayerA in area");
        if (collision.tag == "PlayerA")
        {
            isOnA = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(" PlayerA out area");
        if (collision.tag == "PlayerA")
        {
            isOnA = false;
        }
    }
    #endregion//消してはいけない
}