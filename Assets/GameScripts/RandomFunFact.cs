using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFunFact : MonoBehaviour
{
    public Sprite[] funFactImage;
    public Image ImageUI;
    int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(0, funFactImage.Length);
        ImageUI.GetComponent<Image>().sprite = funFactImage[randomNumber];
    }

    void Update()
    {
        
    }
}
