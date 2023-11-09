using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalulateScript : MonoBehaviour
{
    public static ScoreCalulateScript instance;
    public Text totalscoreText;
    public Text bonusText;

    public Image BonusCircleFill;
    float BonusScore = 0f;
    float BonusCircleFillTime = 0f;
    bool BCFActive = false;
    bool BCFUnActive = false;

    public static bool canDurainTime = false;

    [Header("Score Multiplier")]
    public float Multiplier = 0f;

    [Header("Durain Time")]
    public float BonusTimeSec = 2f;
    //public float BonusPoint = 0f;

    public static float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalscoreText.text = score.ToString();
        bonusText.text = "";

        BonusCircleFill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (DeadLineDetectionScript.onDead)
        {
            bonusText.text = "Fail!";
        }

        if (MergeObject.WataermalonMarge)
        {
            Debug.Log("Watermalon!");
            score += 500;
            MergeObject.WataermalonMarge = false;
        }


        onUpdateBonus();
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint(int Score, bool Bonus, int BonusScore, float BonusPoint)
    {
        score += Score * Multiplier;
        score += BonusScore;
        if (Bonus == true)
        {
            AddBonusPoint(BonusPoint);
            bonusText.text = "Bonus!";
            BCFActive = true;
        }
        else
        {
            bonusText.text = "";
        }
        totalscoreText.text = score.ToString();
    }

    void AddBonusPoint(float Point)
    {
        BonusScore += Point;
        BonusCircleFill.fillAmount = BonusScore;
    }

    private void onUpdateBonus()
    {
        if (BCFActive)
        {
            BonusCircleFillTime += Time.deltaTime;
            BonusCircleFill.fillAmount = BonusCircleFillTime;
            if (BonusCircleFillTime >= BonusScore)
            {
                BCFActive = false;
            }
        }

        if(BonusScore >= 1)
        {
            canDurainTime = true;
            BonusScore += 0.2f;
            bonusText.text = "BONUS TIME!";
            StartCoroutine(delayBonus());
        }

        if (BCFUnActive)
        {
            BonusCircleFillTime -= Time.deltaTime;
            BonusCircleFill.fillAmount = BonusCircleFillTime;
            if (BonusCircleFillTime <= BonusScore)
            {
                canDurainTime = false;
                BCFUnActive = false;
                bonusText.text = "";
            }
        }
    }

    IEnumerator delayBonus()
    {
        yield return new WaitForSeconds(BonusTimeSec);
        BonusScore = 0;
        BCFUnActive = true;
    }
}
