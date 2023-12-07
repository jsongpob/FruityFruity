using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalulateScript : MonoBehaviour
{
    public Text TestText;

    public static ScoreCalulateScript instance;
    public Text totalscoreText;
    public Text bonusText;

    public Image BonusCircleFill;
    public static float BonusScore = 0f;
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

    EffectPlayer effectplayerscript;
    bool canRunthisSound = true;
    bool canRunthisSound2 = true;
    bool canRunthisSound3 = true;

    // Start is called before the first frame update
    void Start()
    {
        totalscoreText.text = score.ToString();
        bonusText.text = "";

        BonusCircleFill.fillAmount = 0;

        effectplayerscript = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<EffectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        onUpdateBonus();

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

        //DEBUG
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            score += 990;
        }
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

        if (score >= 1000 && canRunthisSound)
        {
            canRunthisSound = false;
            effectplayerscript.runPointVoice(1000);
        }
        if (score >= 5000 && canRunthisSound2)
        {
            canRunthisSound2 = false;
            effectplayerscript.runPointVoice(5000);
        }
        if (score >= 10000 && canRunthisSound3)
        {
            canRunthisSound3 = false;
            effectplayerscript.runPointVoice(10000);
        }
    }

    void AddBonusPoint(float Point)
    {
        BonusScore += Point;
        BonusCircleFill.fillAmount = BonusScore;
        effectplayerscript.runPlayBonusSound();
    }

    private void onUpdateBonus()
    {
        if (BCFActive)
        {
            BonusCircleFillTime += Time.deltaTime;
            BonusCircleFill.fillAmount = BonusCircleFillTime/4;
            if (BonusCircleFillTime >= BonusScore)
            {
                BCFActive = false;
            }
        }

        if(BonusScore >= 4)
        {
            canDurainTime = true;
            BonusScore += 0.2f;
            bonusText.text = "BONUS TIME!";
            StartCoroutine(delayBonus());
        }

        TestText.text = BonusScore.ToString();

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
        BonusScore = 0f;
        BCFUnActive = true;
    }
}
