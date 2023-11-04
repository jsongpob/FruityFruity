using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItemScript : MonoBehaviour
{
    public StatusOfWaitingForSpawn statusBar;

    public SpriteRenderer ControllerRender;
    Rigidbody2D ActiveRigid;

    public int maxCounting;
    public GameObject Items;
    public Text Countingtext;

    public GameObject[] ObjectPlayItems;

    int Counting = 0;
    public static int RandomObjectItems;

    bool canSpawn = true;
    float TimerSpawn = 0f;
    public float TimerDelay = 1f;

    public GameObject IndecatorLine;

    void Start()
    {
        //ControllerRender = GetComponent<SpriteRenderer>();
        //ControllerRender.enabled = false;
        statusBar.setMaxFill(TimerDelay);

        RandomObjectItems = 0;
        //StartCoroutine(WaitForSpawn());
    }

    void Update()
    {
        if (!DeadLineDetectionScript.onDead)
        {
            RandomObjectSpawn();
        }
        statusBar.setFill(TimerSpawn);
    }

    void RandomObjectSpawn()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * 3f;
        IndecatorLine.gameObject.transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * 3f;

        if (canSpawn == false)
        {
            TimerSpawn += Time.deltaTime;
            if (TimerSpawn > TimerDelay)
            {
                //Debug.Log("canSpawn: " + canSpawn);
                TimerSpawn = 0f;
                canSpawn = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && canSpawn)
        {
            GameObject Fruit = Instantiate(ObjectPlayItems[RandomObjectItems], this.transform.position, Quaternion.identity);
            MergeController.Instance.DictMerge.Add(Fruit.GetComponent<MergeObject>(), false);

            RandomObjectItems = Random.Range(0, ObjectPlayItems.Length);

            canSpawn = false;

        }
    }

    void Testing()
    {
        //MOVE WITH KEYBOARD FOR TESTING
        float moveX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * 3f;

        //INPUT FROM KEYBOARD FOR TESTING
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Items.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 2f), Random.Range(0f, 2f), Random.Range(0f, 2f), 1f);
            Items.transform.localScale = Vector3.one * Random.Range(0.2f, 1.5f);

            Vector2 posToSpawn = new Vector2(transform.position.x, transform.position.y);
            Instantiate(Items, posToSpawn, Quaternion.identity);
        }
    }

    void Production()
    {
        //MOVE WITH SENSOR FOR PRODUCTION
        float spawnMove = (Arduino_Initial.vol_Value1 - 500f) / 150f;
        transform.position = new Vector3(spawnMove, 4, 0);
        print(spawnMove);

        //INPUT FROM SENSOR FOR PRODUCTION
        if (Arduino_Initial.tou_Value3 == 1)
        {
            Items.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 2f), Random.Range(0f, 2f), Random.Range(0f, 2f), 1f);
            Items.transform.localScale = Vector3.one * Random.Range(0.2f, 1.5f);

            Counting++;
            if (Counting >= maxCounting)
            {
                Vector2 posToSpawn = new Vector2(transform.position.x, transform.position.y);
                Instantiate(Items, posToSpawn, Quaternion.identity);

                Counting = 0;
            }
        }
        else
        {
            Counting = 0;
        }

        Countingtext.text = Counting.ToString();
    }

    //IEnumerator WaitForSpawn()
    //{
    //    yield return new WaitForSeconds(1f);
    //    canSpawn = true;
    //}
}
