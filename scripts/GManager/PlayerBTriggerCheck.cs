using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBTriggerCheck : MonoBehaviour
{
    // 判定内にプレイヤーがいる
    [HideInInspector] public bool isOnB = false;

    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(" PlayerB in area");
        if (collision.tag == "PlayerB")
        {
            isOnB = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(" PlayerB out area");
        if (collision.tag == "PlayerB")
        {
            isOnB = false;
        }
    }
    #endregion//消してはいけない
}