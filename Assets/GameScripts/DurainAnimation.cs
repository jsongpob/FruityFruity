using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurainAnimation : MonoBehaviour
{
    public static DurainAnimation animate;

    [Header("Animation")]
    public Animator Title;

    private void Update()
    {
        if (ScoreCalulateScript.canDurainTime)
        {
            StartCoroutine(CallAnimate());
        }
    }

    IEnumerator CallAnimate()
    {
        Title.SetBool("StartDurainTitle", true);
        yield return new WaitForSeconds(10);
        Title.SetBool("StartDurainTitle", false);
    }
}
