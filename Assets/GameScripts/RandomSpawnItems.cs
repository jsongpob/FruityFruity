using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItems : MonoBehaviour
{
    public GameObject[] RandomItems;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(RandomItems[0], this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            int RandomObjectItems = Random.Range(0, RandomItems.Length);
            Vector2 posToSpawn = new Vector2(transform.position.x, transform.position.y);

            Instantiate(RandomItems[RandomObjectItems], posToSpawn, Quaternion.identity);
        }
    }
}
