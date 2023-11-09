using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurainManger : MonoBehaviour
{
    [Header("Bonus")]
    public GameObject DurainObject;

    float timer = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (ScoreCalulateScript.canDurainTime)
        {
            if (timer == 0)
            {
                Instantiate(DurainObject, transform.position, Quaternion.identity);
                timer++;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
