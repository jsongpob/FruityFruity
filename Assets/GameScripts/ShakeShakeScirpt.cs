using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakeShakeScirpt : MonoBehaviour
{
    public Animator Animate;
    public float TimeToShake = 0f;

    float timerSensor = 0f;
    bool canShake = true;

    EffectPlayer effectplayerscript;


    void Start()
    {
        effectplayerscript = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<EffectPlayer>();
        effectplayerscript.runShakeVoice();
    }

    void Update()
    {
        if (Arduino_Initial.vib_Value2 == 1 && canShake)
        {
            Animate.SetBool("StartShake", true);
            timerSensor += Time.deltaTime;
            if (timerSensor >= 1)
            {
                canShake = false;
                StartCoroutine(UseSensor());
            }
        }
    }

    IEnumerator ShakeTime()
    {
        Animate.SetBool("StartShake", true);
        yield return new WaitForSeconds(3f);
        Animate.SetBool("StartShake", false);
    }

    IEnumerator TestShakeTime()
    {
        Animate.SetBool("StartShake", true);
        yield return new WaitForSeconds(3f);
        Animate.SetBool("StartShake", false);
        SceneManager.LoadScene("Fruit_Funfact");
    }

    IEnumerator UseSensor()
    {
        canShake = false;
        Animate.SetBool("StartShake", true);
        yield return new WaitForSeconds(1f);
        Animate.SetBool("StartShake", false);
        SceneManager.LoadScene("Fruit_Funfact");
        canShake = true;
    }
}
