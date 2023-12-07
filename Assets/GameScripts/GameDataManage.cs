using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDataManage : MonoBehaviour
{
    [Header("Text Setting")]
    public Text playerNameTitle;
    public Text playerScoreTitle;
    public Text highestScoreTitle;

    //[Header("Feild Name Management")]
    //public InputField insertNameField;
    //string playerNameData;

    [Header("Transition UI Animate")]
    public Animator endTitleAnimate;
    public static bool startEndTitleAnimate = false;
    public Image HighestImage;

    public Animator overAllTitleAnimate;

    bool RunCongreatAnimate = true;

    float timerRestart = 0f;

    insertToDataBase database;
    EffectPlayer effectplayerscript;

    //GAMEDATA MANAGEMENT
    public static float GamedataScore = 0f;
    public static float GamedataHighestScore = 0f;
    public static float GamedataCurrentHighestScore = 0f;
    public static string GamedataPlayerName;

    private void Start()
    {
        database = GameObject.FindGameObjectWithTag("database").GetComponent<insertToDataBase>();
        effectplayerscript = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<EffectPlayer>();
        HighestImage.enabled = false;
        InvokeRepeating("onDataSummitAtInsert", 5f, 1f);
        effectplayerscript.runWooshSound();
    }

    private void Update()
    {
        if (DeadLineDetectionScript.onDead)
        {
            //PLAY SOUNDS

            //COLLECT DATA
            GamedataScore = ScoreCalulateScript.score;

            //HIGHEST SCORE CONDITION
            if (GamedataScore > GamedataHighestScore)
            {
                GamedataHighestScore = GamedataCurrentHighestScore;
            }

            //RUN ANIMATE
            if (RunCongreatAnimate)
            {
                StartCoroutine(AnimationEndGame());
                effectplayerscript.runPlayCongreatVoice();
            }

            //SHOW DATA AFTER PLAYED
            playerNameTitle.text = GamedataPlayerName;
            playerScoreTitle.text = GamedataScore.ToString();
            highestScoreTitle.text = $"Highest score: {GamedataHighestScore}";

            //GAME RESET
            timerRestart += Time.deltaTime;
            //Debug.Log($"Count Down to Restart Game in {timerRestart}");
            if (timerRestart > 180f)
            {
                SceneManager.LoadScene("01IdleScene");
                ResetGame();
                timerRestart = 0f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //INSERT DATABASE
                database.On_ClickInsertDatabase();
                SceneManager.LoadScene("ShakeScene");
                ResetGame();
            }
        }
    }

    public void onDataSummitAtInsert()
    {
        GamedataPlayerName = InsertNametoData.playerNameData;

        if (ScoreCalulateScript.score != 0)
        {
            GamedataScore = ScoreCalulateScript.score;
        }

        if (GamedataScore > GamedataHighestScore)
        {
            GamedataCurrentHighestScore = GamedataScore;
            if (GamedataCurrentHighestScore > GamedataHighestScore)
            {
                HighestImage.enabled = true;
                GamedataHighestScore = GamedataCurrentHighestScore;
            }
        }

        Debug.Log($"PlayerName: {GamedataPlayerName}, PlayerScore: {GamedataScore}, HighestScore: {GamedataHighestScore}");
    }

    IEnumerator AnimationEndGame()
    {
        RunCongreatAnimate = false;
        endTitleAnimate.SetTrigger("onEndGameTitle_start");
        yield return new WaitForSeconds(3f);
        endTitleAnimate.SetTrigger("onEndGameTitle_stop");
        StartCoroutine(AnimationOverall());
    }

    IEnumerator AnimationOverall()
    {
        overAllTitleAnimate.SetTrigger("StartOverallAnimate");
        yield return new WaitForSeconds(190f);
        overAllTitleAnimate.SetTrigger("idle");
    }

    void ResetGame()
    {
        GamedataScore = 0f;
        GamedataPlayerName = "";
        ScoreCalulateScript.score = 0f;
        DeadLineDetectionScript.onDead = false;
        ScoreCalulateScript.BonusScore = 0;
    }
}
