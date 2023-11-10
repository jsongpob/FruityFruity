using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound : MonoBehaviour
{
    [Header("Genaral")]
    public AudioSource SoundSource;
    public AudioClip Sound;

    bool canPlay = true;

    Scene currentScene;
    string currentSceneName;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        if (currentSceneName == "01IdleScene")
        {
            canPlay = true;
            Destroy(gameObject);
        }

        if (DeadLineDetectionScript.onDead && canPlay)
        {
            canPlay = false;
            SoundSource.PlayOneShot(Sound);
        }

    }
}
