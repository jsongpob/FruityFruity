//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EndGameSound : MonoBehaviour
//{
//    [Header("End background sound")]
//    public AudioSource SoundSource;
//    public AudioClip Sound;

//    SoundPlayers soundPlayersScript;

//    void Start()
//    {
//        soundPlayersScript = GameObject.FindGameObjectWithTag("SoundPlayers").GetComponent<SoundPlayers>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (DeadLineDetectionScript.onDead)
//        {
//            StartCoroutine(BackgroundSound());
//            DontDestroyOnLoad(gameObject);
//        }
//    }

//    IEnumerator BackgroundSound()
//    {
//        yield return new WaitForSeconds(1f);
//        SoundSource.clip = Sound;
//        SoundSource.Play();
//    }
//}
