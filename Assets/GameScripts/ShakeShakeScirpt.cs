using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakeShakeScirpt : MonoBehaviour
{
    public Animator Animate;
    float timer = 0f;
    public float TimeToShake = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(TestShakeTime());
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

    void UseSensor()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ShakeTime());
            timer += Time.deltaTime;
            if (timer >= TimeToShake)
            {
                SceneManager.LoadScene("Fruit_Funfact");
            }
        }
    }
}
