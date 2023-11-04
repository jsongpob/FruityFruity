using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObject : MonoBehaviour
{
    int ObjectID;

    [Header("Object Merge")]
    public GameObject MergedObjectItem;
    [Range(0f, 5f)] public float delay = 0.5f;
    [Range(0f, 10f)] public float Distance;
    [Range(0f, 10f)] public float MergeSpeed;

    [Header("Object Tag")]
    public string GameObjectTag;

    [Header("Score")]
    public int thisObjectScore = 0;
    public bool HasBonus = false;
    public int BonusScore = 0;

    Transform ObjectOne;
    Transform ObjectTwo;

    bool canMerge = false;
    bool startMerge = false;


    // Start is called before the first frame update
    void Start()
    {
        ObjectID = GetInstanceID();
        StartCoroutine(WaitingMerged());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObjectOne != null && ObjectTwo != null && canMerge)
        {
            MoveToward();
            if (TryGetComponent<Rigidbody2D>(out Rigidbody2D checkRigi))
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }

        onDead();

    }

    public void MoveToward()
    {
        if (startMerge)
        {
            transform.position = Vector2.MoveTowards(ObjectOne.position, ObjectTwo.position, MergeSpeed);

            if (Vector2.Distance(ObjectOne.position, ObjectTwo.position) < Distance)
            {
                if (ObjectID < ObjectTwo.gameObject.GetComponent<MergeObject>().ObjectID) { return; }

                //Debug.Log($"From {gameObject.name} With ID: {ObjectID}");

                Destroy(ObjectTwo.gameObject);
                Destroy(this.gameObject);

                GameObject NewMargedObject = Instantiate(MergedObjectItem, transform.position, Quaternion.identity);
                //MergeController.Instance.DictMerge.Add(NewMargedObject.GetComponent<MergeObject>(), false);
                //NewMargedObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                NewMargedObject.GetComponent<Rigidbody2D>();

                AddPoint();
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

        //if (collision.gameObject.GetComponent<MergeObject>().ObjectTwo != transform)
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

        if (startMerge && transform.position.y < 3)
        {
            ObjectOne = transform;
            ObjectTwo = collision.transform;

            //Debug.Log($"{gameObject.name} {collision.gameObject.name}");

            StartCoroutine(WaitingObject());

            //Debug.Log("OnCollision");
        }
    }

    void onDead()
    {
        if (DeadLineDetectionScript.onDead)
        {
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    void AddPoint()
    {
        ScoreCalulateScript.instance.AddPoint(thisObjectScore, HasBonus, BonusScore);
    }

    public IEnumerator WaitingMerged()
    {
        yield return new WaitForSeconds(delay);
        startMerge = true;
    }

    IEnumerator WaitingObject()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
    }
}