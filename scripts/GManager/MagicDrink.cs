using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDrink : MonoBehaviour
{
    public PlayerATriggerCheck playerACheck;
    public PlayerBTriggerCheck playerBCheck;
    ChangeCharacter ccscript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacter ccscript = GameObject.Find("ChangeCharacter").GetComponent<ChangeCharacter>();

        if (playerACheck.isOnA)
        {
            if (GManager.instance != null)
            {
                ccscript.isChange1 = true;
                Destroy(this.gameObject);
            }
        }

        if (playerBCheck.isOnB)
        {
            if (GManager.instance != null)
            {
                ccscript.isChange2 = true;
                Destroy(this.gameObject);
            }
        }
    }
}
