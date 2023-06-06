using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramTriggerCheck : MonoBehaviour
{
    [HideInInspector] public bool isOnTA = false;
    [HideInInspector] public bool isOnTB = false;

    #region//ê⁄êGîªíË
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trampoline")
        {
            if (collision.name == "WhiteMagic1") {
                isOnTA = true;
            }
            else if(collision.name == "WhiteMagic2")
            {
                isOnTB = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trampoline")
        {
            if (collision.name == "WhiteMagic1")
            {
                isOnTA = false;
            }
            else if (collision.name == "WhiteMagic2")
            {
                isOnTB = false;
            }
        }
    }
    #endregion//è¡ÇµÇƒÇÕÇ¢ÇØÇ»Ç¢
}
