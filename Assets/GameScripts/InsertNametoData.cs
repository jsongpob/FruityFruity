using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertNametoData : MonoBehaviour
{
    public InputField insertNameField;
    public static string playerNameData; 

    public void ReadPlayerNameData()
    {
        playerNameData = insertNameField.text;
        Debug.Log(playerNameData);
    }
}
