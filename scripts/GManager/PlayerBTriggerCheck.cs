using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBTriggerCheck : MonoBehaviour
{
    // ”»’è“à‚ÉƒvƒŒƒCƒ„[‚ª‚¢‚é
    [HideInInspector] public bool isOnB = false;

    #region//ÚG”»’è
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
    #endregion//Á‚µ‚Ä‚Í‚¢‚¯‚È‚¢
}