using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurainTimeScript : MonoBehaviour
{
    public static DurainTimeScript instance;

    [Header("Setting")]
    public string[] GameObjectTag;
    public int thisObjectScore;
    public bool HasBonus;
    public int BonusScore;
    public int DestoryDelay;

    float destorytimer = 0;

    private void Update()
    {
        if (this.gameObject.transform.position.y < -1)
        {
            destorytimer += Time.deltaTime;
            if (destorytimer > DestoryDelay)
            {
                Destroy(this.gameObject);
                destorytimer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < GameObjectTag.Length; i++)
        {
            if (collision.gameObject.CompareTag(GameObjectTag[i]))
            {
                ScoreCalulateScript.instance.AddPoint(thisObjectScore, HasBonus, BonusScore, 0);
                Destroy(collision.gameObject);
            }
        }
    }
}
