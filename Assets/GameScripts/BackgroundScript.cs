using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Sprite[] Background;
    public int NumberOfBackground = 0;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Background[0];
    }

    private void Update()
    {
        if (ScoreCalulateScript.canDurainTime)
        {
            GetComponent<SpriteRenderer>().sprite = Background[NumberOfBackground];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Background[0];
        }
    }
}
