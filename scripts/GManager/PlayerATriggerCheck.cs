using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATriggerCheck : MonoBehaviour
{
    // ������Ƀv���C���[������
    [HideInInspector] public bool isOnA = false;

    #region//�ڐG����
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
    #endregion//�����Ă͂����Ȃ�
}