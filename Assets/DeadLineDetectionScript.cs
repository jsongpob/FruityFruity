using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineDetectionScript : MonoBehaviour
{
    public float timerDetectTime;
    public float DeadLinePOS;

    public static bool onDead = false;

    float timerDetect = 0f;
    bool startDetect = false;

    void onDetection(Vector3 ObjectPOS, float Detection)
    {
        if (ObjectPOS.y > Detection)
        {
            //Debug.Log($"Im at {ObjectPOS.y}");
            startDetect = true;
        }
        else
        {
            startDetect = false;
        }
    }

    private void FixedUpdate()
    {
        onDetection(this.gameObject.transform.position, DeadLinePOS);

        if (startDetect)
        {
            timerDetect += Time.deltaTime;
            if(timerDetect >= timerDetectTime)
            {
                //Debug.Log("Your Dead");
                onDead = true;
            }
        }
    }
}
