using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeFakeObject : MonoBehaviour
{
    Vector2 startPosistion;
    public GameObject ShakeObject;

    public float ShakeSpeed = 0.1f;

    //bool EventShake = false;

    void Start()
    {
        startPosistion = transform.position;
        print(startPosistion);
    }

    void Update()
    {
        bool EventSpawn = Input.GetKeyDown(KeyCode.Alpha1);
        if (EventSpawn)
        {
            Instantiate(ShakeObject, this.transform.position, this.transform.rotation);
        }
    }
}
