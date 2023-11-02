using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObject : MonoBehaviour
{
    public string GameObjectTag;

    int ObjectID;
    public GameObject MergedObjectItem;
    [Range(0.1f, 1f)] public float delay = 0.5f;


    Transform ObjectOne;
    public Transform ObjectTwo;

    public float Distance;
    public float MergeSpeed;

    public bool canMerge = false;
    bool startMerge = false;
    float Objecttimer;
    int ObjectCount = 0;

    public int isInteracted = 0;

    // Start is called before the first frame update
    void Start()
    {
        ObjectID = GetInstanceID();
        StartCoroutine(WaitingMerged());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Objecttimer += Time.deltaTime;
        //if (Objecttimer > delay)
        //{
        //    startMerge = true;
        //}

        if (ObjectOne != null && ObjectTwo != null && canMerge)
        {
            MoveToward();
        }

    }

    public void MoveToward()
    {
        if (startMerge)
        {
            transform.position = Vector2.MoveTowards(ObjectOne.position, ObjectTwo.position, MergeSpeed);

            if (Vector2.Distance(ObjectOne.position, ObjectTwo.position) < Distance)
            {
                if (ObjectID < ObjectTwo.gameObject.GetComponent<MergeObject>().ObjectID) { return; }

                Debug.Log($"From {gameObject.name} With ID: {ObjectID}");

                Destroy(ObjectTwo.gameObject);
                Destroy(this.gameObject);

                GameObject NewMargedObject = Instantiate(MergedObjectItem, transform.position, Quaternion.identity);
                MergeController.Instance.DictMerge.Add(NewMargedObject.GetComponent<MergeObject>(), false);
                NewMargedObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);

                Debug.Log("MoveToWard");

                ScoreCalulateScript.instance.AddPoint(false);

                if (this.gameObject.CompareTag("Four"))
                {
                    ScoreCalulateScript.instance.AddPoint(true);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //MergeObject MO;
        //if (!collision.gameObject.TryGetComponent(out MO)) return;

        //if (isinteracted) return;

        canMerge = false;

        if (!collision.gameObject.CompareTag(GameObjectTag)) return;

        //if (collision.gameObject.GetComponent<MergeObject>().ObjectID > ObjectID)
        //{
        //    return;
        //}

        if (startMerge && transform.position.y < 3)
        {
            ObjectOne = transform;
            ObjectTwo = collision.transform;

            Debug.Log($"{gameObject.name} {collision.gameObject.name}");

            Debug.Log("OnCollision");
        }

        //if(collision.gameObject.GetComponent<MergeObject>().ObjectTwo != transform)
        //{
        //    gameObject.AddComponent<Rigidbody2D>();
        //}
        //if (collision.gameObject.GetComponent<MergeObject>().ObjectTwo == null) return;

        if (collision.gameObject.GetComponent<MergeObject>().ObjectTwo == transform)
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());
            canMerge = true;
            //MergeController.Instance.Duos.Add(new MergeDuo(this, ObjectTwo.GetComponent<MergeObject>()));
            StartCoroutine(WaitingObject());
        }

        ObjectCount = 0;
    }

    public IEnumerator WaitingMerged()
    {
        yield return new WaitForSeconds(delay);
        startMerge = true;
    }

    IEnumerator WaitingObject()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.AddComponent<Rigidbody2D>();
    }
}