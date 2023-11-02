using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewScirpts : MonoBehaviour
{

    public Sprite[] ObjectPlayablePicture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = ObjectPlayablePicture[SpawnItemScript.RandomObjectItems];
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
