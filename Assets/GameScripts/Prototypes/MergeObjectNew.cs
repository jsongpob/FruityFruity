//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MergeObjectNew : MonoBehaviour
//{
//    public string GameObjectTag;

//    int ObjectID;
//    public GameObject MergedObjectItem;
//    [Range(0.1f, 1f)] public float delay = 0.5f;


//    Transform ObjectOne;
//    public Transform ObjectTwo;

//    public float Distance;
//    public float MergeSpeed;

//    bool canMerge = false;
//    bool startMerge = false;
//    float Objecttimer;
//    int ObjectCount = 0;

//    public int isInteracted = 0;

//    public float objectRange = 0f;

//    public LayerMask LayerObject;

//    // Start is called before the first frame update
//    void Start()
//    {
//        ObjectID = GetInstanceID();
//        StartCoroutine(WaitingMerged());
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        //Objecttimer += Time.deltaTime;
//        //if (Objecttimer > delay)
//        //{
//        //    startMerge = true;
//        //}

//        if (ObjectOne != null && ObjectTwo != null && canMerge)
//        {
//            MoveToward();
//        }

//    }

//    public void MoveToward()
//    {
//        if (startMerge)
//        {
//            transform.position = Vector2.MoveTowards(ObjectOne.position, ObjectTwo.position, MergeSpeed);

//            if (Vector2.Distance(ObjectOne.position, ObjectTwo.position) < Distance)
//            {
//                if (ObjectID < ObjectTwo.gameObject.GetComponent<MergeObjectNew>().ObjectID) { return; }

//                Debug.Log($"From {gameObject.name} With ID: {ObjectID}");

//                GameObject NewMargedObject = Instantiate(MergedObjectItem, transform.position, Quaternion.identity) as GameObject;

//                Debug.Log("MoveToWard");

//                ScoreCalulateScript.instance.AddPoint(false);

//                if (this.gameObject.CompareTag("Four"))
//                {
//                    ScoreCalulateScript.instance.AddPoint(true);
//                }

//                Object.Destroy(ObjectTwo.gameObject);
//                Object.Destroy(this.gameObject);
//            }
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        canMerge = false;

//        Collider2D[] colliderObject = Physics2D.OverlapCircleAll(transform.position, objectRange, LayerObject);

//        if (!collision.gameObject.CompareTag(GameObjectTag)) return;

//        if (colliderObject.Length <= 1)
//        {
//            if (startMerge && transform.position.y < 3)
//            {
//                ObjectOne = transform;
//                ObjectTwo = collision.transform;

//                Debug.Log($"{gameObject.name} {collision.gameObject.name}");

//                StartCoroutine(WaitingObject());

//                Debug.Log("OnCollision");

//                if (ObjectTwo.gameObject.GetComponent<MergeObjectNew>().ObjectTwo == transform)
//                {
//                    Destroy(ObjectTwo.gameObject.GetComponent<Rigidbody2D>());
//                    Destroy(this.gameObject.GetComponent<Rigidbody2D>());
//                    canMerge = true;
//                }
//            }
//        }
//        else
//        {
//            if (startMerge && transform.position.y < 3)
//            {
//                ObjectOne = transform;
//                ObjectTwo = nearsestObject(colliderObject).transform;

//                StartCoroutine(WaitingObject());

//                Destroy(ObjectTwo.gameObject.GetComponent<Rigidbody2D>());
//                Destroy(this.gameObject.GetComponent<Rigidbody2D>());
//                canMerge = true;
//            }
//        }

//    }

//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, objectRange);
//    }

//    Collider2D nearsestObject(Collider2D[] objs)
//    {
//        float nearestDistance = Vector2.Distance(transform.position, objs[0].transform.position);
//        Collider2D nearestObj = objs[0];

//        for(int i = 1; i < objs.Length; i++)
//        {
//            float ObjDistance1 = Vector2.Distance(transform.position, objs[i].transform.position);
//            if(ObjDistance1 < nearestDistance)
//            {
//                nearestDistance = ObjDistance1;
//                nearestObj = objs[i];
//            }
//        }

//        return nearestObj;
//    }

//    IEnumerator WaitingMerged()
//    {
//        yield return new WaitForSeconds(delay);
//        startMerge = true;
//    }

//    IEnumerator WaitingObject()
//    {
//        yield return new WaitForSeconds(0.1f);
//        gameObject.AddComponent<Rigidbody2D>();
//    }
//}