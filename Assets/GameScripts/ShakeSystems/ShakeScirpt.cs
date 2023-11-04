using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScirpt : MonoBehaviour
{

    public AnimationCurve curve;
    public float ShakeTime = 1f;

    public IEnumerator Shake()
    {
        Vector3 StartPosition = new Vector3(0,-3,0);
        Quaternion StartRotation = transform.rotation;
        //Vector3 YPosition = new Vector3(0, transform.position.y, 0);
        float TimeUsed = 0f;

        while(TimeUsed < ShakeTime)
        {
            TimeUsed += Time.deltaTime;

            float Strength = curve.Evaluate(TimeUsed / ShakeTime);

            Vector3 Position = StartPosition + Random.insideUnitSphere * Strength;
            Position = new Vector3(Position.x/1.2f, Position.y, 0);

            transform.position = Position;

            yield return null;
        }

        transform.position = StartPosition;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Arduino_Initial.vib_Value2 == 1)
        {
            StartCoroutine(Shake());
            //Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * ShakeTime);
            //newPos.y = transform.position.y;

            //transform.position = newPos;
        }
    }
}
