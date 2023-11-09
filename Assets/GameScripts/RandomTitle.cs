using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTitle : MonoBehaviour
{
    public Sprite[] RandomPicture;
    int randomNumber = 0;
    public bool startEndTitle = false;

    private void Start()
    {
        randomtitle();
    }

    public void randomtitle()
    {
        randomNumber = Random.Range(0, RandomPicture.Length);
        GetComponent<Image>().sprite = RandomPicture[randomNumber];
    }
}
