using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundPlayers : MonoBehaviour
{
    public AudioSource PlayerObject;

    [Header("Sound source files")]
    public AudioClip GameSound;

    public static SoundPlayers instance;

    Scene currentScene;
    string currentSceneName;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //}

    private void Update()
    {
        if (DeadLineDetectionScript.onDead)
        {
            PlayerObject.Stop();
        }
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        StartCoroutine(playingamesound());
    }

    IEnumerator playingamesound()
    {
        yield return new WaitForSeconds(3.5f);
        if (currentSceneName == "InGameScene")
        {
            PlayerObject.clip = GameSound;
            PlayerObject.Play();
        }
    }
}
