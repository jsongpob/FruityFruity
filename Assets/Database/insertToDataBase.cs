using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class insertToDataBase : MonoBehaviour
{
    string value_url = "http://localhost/fruityfruity/Insertdatabase.php";

    string GameDataPlayerName;
    float GameDataPlayerScore;
    float GameDataHighestScore;

    void Start()
    {

    }

    public void On_ClickInsertDatabase()
    {
        GameDataPlayerName = GameDataManage.GamedataPlayerName;
        GameDataPlayerScore = GameDataManage.GamedataScore;
        GameDataHighestScore = GameDataManage.GamedataHighestScore;

        print("DB::" + "GameDataPlayerScore:" + GameDataPlayerScore + " GameDataPlayerName:" + GameDataPlayerName + " GameDataHighestScore:" + GameDataHighestScore);

        if (GameDataPlayerScore >= 0)
        {
            StartCoroutine(insertDB());
        }
    }

    // Use this for initialization
    IEnumerator insertDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("player_name", GameDataPlayerName.ToString());
        form.AddField("player_score", GameDataPlayerScore.ToString());
        form.AddField("highest_score", GameDataHighestScore.ToString());

        // Create a download object
        var download = UnityWebRequest.Post(value_url, form);

        // Wait until the download is done
        yield return download.SendWebRequest();

        if (download.result != UnityWebRequest.Result.Success)
        {
            //case Not Success
            print("Error downloading: " + download.error);
        }
        else
        {
            //case Success
            Debug.Log(download.result);
        }
    }
}
