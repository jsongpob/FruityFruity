using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalulateScript : MonoBehaviour
{
    public static ScoreCalulateScript instance;
    public Text totalscoreText;
    public Text bonusText;

    //System.DateTime DT = System.DateTime.Now;

    int score = 0;
    //int totalscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalscoreText.text = score.ToString() + " POINTS";
        bonusText.text = "";
        //Debug.Log(DT);
    }

    // Update is called once per frame
    void Update()
    {
        if (DeadLineDetectionScript.onDead)
        {
            bonusText.text = "Fail!";
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint(bool Bonus)
    {
        score += 1;
        if(Bonus == true)
        {
            score += 10;
            bonusText.text = "Bonus!";
        }
        else
        {
            bonusText.text = "";
        }
        totalscoreText.text = score.ToString() + " POINTS";
    }
}
