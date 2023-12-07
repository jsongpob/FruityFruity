using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurainManger : MonoBehaviour
{
    [Header("Bonus")]
    public GameObject DurainObject;

    float timer = 0;

    EffectPlayer effectplayerscript;

    private void Start()
    {
        effectplayerscript = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<EffectPlayer>();
        effectplayerscript.runCountDownSound();
    }

    private void Update()
    {
        if (ScoreCalulateScript.canDurainTime)
        {
            if (timer == 0)
            {
                Instantiate(DurainObject, transform.position, Quaternion.identity);
                timer++;
                effectplayerscript.runPlayDurainVoice();
            }
        }
        else
        {
            timer = 0;
        }
    }
}
