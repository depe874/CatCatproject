using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBTriggerCheck : MonoBehaviour
{
    // ������Ƀv���C���[������
    [HideInInspector] public bool isOnB = false;

    #region//�ڐG����
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
    #endregion//�����Ă͂����Ȃ�
}