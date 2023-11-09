using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [Header("To Scene")]
    public string SceneName;

    [Header("Transition Setting")]
    public Animator transition;
    public float transitionTime = 1f;
    public bool AddTransition = false;
    public KeyCode UseKey = KeyCode.Return;

    void Update()
    {
        if (Input.GetKeyUp(UseKey))
        {
            if (AddTransition)
            {
                StartCoroutine(TransitionScene());
            }
            else
            {
                EnterScene(SceneName);
            }
        }
    }

    public void EnterScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator TransitionScene()
    {
        transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(transitionTime);

        EnterScene(SceneName);
    }
}
