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
    public static Renderer gameObjectSize;

    int Counting = 0;
    public static int RandomObjectItems;

    bool canSpawn = true;
    public static float TimerSpawn = 0f;
    public float TimerDelay = 1f;

    public GameObject IndecatorLine;

    bool DelayOnStart;

    void Start()
    {
        //ControllerRender = GetComponent<SpriteRenderer>();
        //ControllerRender.enabled = false;
        statusBar.setMaxFill(TimerDelay);
        statusBar.setFill(0);

        RandomObjectItems = 0;

        gameObjectSize = ObjectPlayItems[RandomObjectItems].GetComponent<SpriteRenderer>();
        //StartCoroutine(WaitForSpawn());
    }

    void Update()
    {
        DelayStart();

        if (DelayOnStart)
        {
            if (!DeadLineDetectionScript.onDead)
            {
                if (!ScoreCalulateScript.canDurainTime)
                {
                    RandomObjectSpawnProduction();
                }
            }
            statusBar.setFill(TimerSpawn);
        }
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
            //MergeController.Instance.DictMerge.Add(Fruit.GetComponent<MergeObject>(), false);

            RandomObjectItems = Random.Range(0, ObjectPlayItems.Length);
            gameObjectSize = ObjectPlayItems[RandomObjectItems].GetComponent<SpriteRenderer>();

            canSpawn = false;

        }
    }

    void RandomObjectSpawnProduction()
    {
        float spawnMove = (Arduino_Initial.vol_Value1 - 500f) / 200f;
        transform.position = new Vector3(spawnMove, 4, 0);
        IndecatorLine.gameObject.transform.position += new Vector3(spawnMove, 0f, 0f);

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

        if (Arduino_Initial.tou_Value3 == 1 && canSpawn)
        {
            Counting++;
            if (Counting >= maxCounting)
            {
                GameObject Fruit = Instantiate(ObjectPlayItems[RandomObjectItems], this.transform.position, Quaternion.identity);
                RandomObjectItems = Random.Range(0, ObjectPlayItems.Length);
                gameObjectSize = ObjectPlayItems[RandomObjectItems].GetComponent<SpriteRenderer>();

                canSpawn = false;

            }
            //MergeController.Instance.DictMerge.Add(Fruit.GetComponent<MergeObject>(), false);
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

    float delaystart;
    bool disabledelay = false;

    void DelayStart()
    {
        if (!disabledelay)
        {
            delaystart += Time.deltaTime;
            if (delaystart >= 4f)
            {
                DelayOnStart = true;
                disabledelay = true;
                delaystart = 0f;
            }
        }
    }
}
