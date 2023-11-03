using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusOfWaitingForSpawn : MonoBehaviour
{
    public Slider slider;

    public void setMaxFill(float value)
    {
        slider.maxValue = value;
    }

    public void setFill(float value)
    {
        slider.value = value;
    }
}
