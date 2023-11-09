using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtPositionDelete : MonoBehaviour
{

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(this.gameObject.transform.position.y <= -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
