using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSpawnShowcase : MonoBehaviour
{
    [Header("Settings")]
    public GameObject[] Items;
    public float MaxRangeForSpawn;
    public float MinRangeForSpawn;

    float RandomRangeX;
    int RandomItems;

    void Start()
    {
        InvokeRepeating("SpawnItems", 1f, 1f);
    }

    void SpawnItems()
    {
        RandomRangeX = Random.Range(MinRangeForSpawn, MaxRangeForSpawn);
        transform.position = new Vector2(RandomRangeX, 10);
        //transform.localRotation = new Quaternion(RandomRangeX, 10, 0, 0);

        RandomItems = Random.Range(0, Items.Length);
        Instantiate(Items[RandomItems], transform.position, transform.localRotation);
    }
}
