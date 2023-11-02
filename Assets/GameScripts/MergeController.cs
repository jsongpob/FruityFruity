using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : Singleton<MergeController>
{
    public List<MergeDuo> Duos = new List<MergeDuo>();
    public Dictionary<MergeObject, bool> DictMerge = new Dictionary<MergeObject, bool>();
    private Coroutine clear = null;

    public void exeucute()
    {
        if (Duos.Count <= 0) return;
        if (Duos[0].One == null || Duos[0].Two == null)
        {
            Duos.RemoveAt(0);
            return;
        }
        if (DictMerge[Duos[0].One] || DictMerge[Duos[0].Two])
        {
            Duos.RemoveAt(0);
            return;
        }

        //if (clear == null)
        //{
        //    StopCoroutine(clear);
        //}
        DictMerge[Duos[0].One] = true;
        DictMerge[Duos[0].Two] = true;
        Destroy(Duos[0].One.gameObject.GetComponent<Rigidbody2D>());
        Destroy(Duos[0].Two.gameObject.GetComponent<Rigidbody2D>());
        Duos[0].One.canMerge = true;
        Duos.RemoveAt(0);
        clear = StartCoroutine(clearList());
    }

    private void FixedUpdate()
    {
        exeucute();
    }

    IEnumerator clearList()
    {
        yield return new WaitForSeconds(1f);
        Duos.Clear();
    }
}

[System.Serializable]
public class MergeDuo
{
    public MergeObject One;
    public MergeObject Two;

    public MergeDuo(MergeObject A, MergeObject B)
    {
        One = A;
        Two = B;
    }
}
