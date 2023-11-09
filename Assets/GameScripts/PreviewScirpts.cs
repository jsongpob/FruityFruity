using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewScirpts : MonoBehaviour
{

    public Sprite[] ObjectPlayablePicture;
    Vector3 Size;
    SpriteRenderer ColorMask;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Size = SpawnItemScript.gameObjectSize.transform.localScale;
        GetComponent<SpriteRenderer>().sprite = ObjectPlayablePicture[SpawnItemScript.RandomObjectItems];
        transform.localScale = new Vector3(Size.x, Size.y, Size.z);
        ColorMask = GetComponent<SpriteRenderer>();
    }
}
