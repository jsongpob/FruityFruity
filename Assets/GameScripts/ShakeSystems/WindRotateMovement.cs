using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRotateMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 2f);
    }
}
