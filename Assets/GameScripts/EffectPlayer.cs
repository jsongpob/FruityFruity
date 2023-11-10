using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [Header("Genaral")]
    public AudioSource SoundSource;
    public AudioClip Sound;

    [Header("DurainTime")]
    public AudioSource DurainSource;
    public AudioClip[] DurainVoiceline;

    [Header("Congreat")]
    public AudioSource CongreatSource;
    public AudioClip[] CongreatVoiceline;

    [Header("Point")]
    public AudioSource PointSource;
    public AudioClip PointVoiceline1000;
    public AudioClip[] PointVoiceline5000;
    public AudioClip PointVoicelineHighest;

    [Header("Watermalon")]
    public AudioSource WatermalonSource;
    public AudioClip Watermalonline;

    [Header("ShakeBox")]
    public AudioSource ShakeScoure;
    public AudioClip[] Shakeline;

    [Header("Bouns Effect")]
    public AudioSource BonusEffect;
    public AudioClip BonusEffectline;

    [Header("Countdown Effect")]
    public AudioSource CDEffect;
    public AudioClip CDEffectline;

    [Header("Woosh Effect")]
    public AudioSource WooshEffect;
    public AudioClip Wooshline;

    [Header("Go Effect")]
    public AudioClip Goline;

    public static EffectPlayer intante;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayDurainVoice();
        }
    }

    public void PlayEffectMerage()
    {
        SoundSource.clip = Sound;
        SoundSource.Play();
    }

    //DURAIN TIME
    public void runPlayDurainVoice()
    {
        StartCoroutine(PlayDurainVoice());
    }


    IEnumerator PlayDurainVoice()
    {
        int randomnum = Random.Range(0, DurainVoiceline.Length);
        DurainSource.clip = DurainVoiceline[randomnum];
        DurainSource.Play();
        yield return new WaitForSeconds(5f);
        DurainSource.Stop();
    }

    //CONGREAT
    public void runPlayCongreatVoice()
    {
        StartCoroutine(PlayCongreatVoice());
    }

    IEnumerator PlayCongreatVoice()
    {
        yield return new WaitForSeconds(1f);
        int random = Random.Range(0, CongreatVoiceline.Length);
        CongreatSource.clip = CongreatVoiceline[random];
        CongreatSource.Play();
        yield return new WaitForSeconds(10f);
        CongreatSource.Stop();
    }

    //POINT
    public void runPointVoice(int point)
    {
        StartCoroutine(PlayCongreatVoice(point));
    }

    IEnumerator PlayCongreatVoice(int point)
    {
        if(point == 1000)
        {
            PointSource.clip = PointVoiceline1000;
            PointSource.Play();
            yield return new WaitForSeconds(3f);
            PointSource.Stop();
        }
        if(point == 5000)
        {
            int random = Random.Range(0, PointVoiceline5000.Length);
            PointSource.clip = PointVoiceline5000[random];
            PointSource.Play();
            yield return new WaitForSeconds(3f);
            PointSource.Stop();
        }
        if(point == 10000)
        {
            PointSource.clip = PointVoicelineHighest;
            PointSource.Play();
            yield return new WaitForSeconds(3f);
            PointSource.Stop();
        }

    }

    //WATERMALON
    public void runWatermalonVoice()
    {
        StartCoroutine(PlayMaloneVoice());
    }

    IEnumerator PlayMaloneVoice()
    {
        WatermalonSource.clip = Watermalonline;
        WatermalonSource.Play();
        yield return new WaitForSeconds(10f);
        WatermalonSource.Stop();
    }

    //SHAKESOUND
    public void runShakeVoice()
    {
        StartCoroutine(PlayShakeVoice());
    }

    IEnumerator PlayShakeVoice()
    {
        int random = Random.Range(0, Shakeline.Length);
        ShakeScoure.clip = Shakeline[random];
        ShakeScoure.Play();
        yield return new WaitForSeconds(10f);
        ShakeScoure.Stop();
    }

    //BONUS
    public void runPlayBonusSound()
    {
        StartCoroutine(PlayBonusSound());
    }

    IEnumerator PlayBonusSound()
    {
        BonusEffect.clip = BonusEffectline;
        BonusEffect.Play();
        yield return new WaitForSeconds(1f);
        BonusEffect.Stop();
    }

    //COUNTDOWN
    public void runCountDownSound()
    {
        StartCoroutine(PlayCountDownSound());
    }

    IEnumerator PlayCountDownSound()
    {
        CDEffect.clip = CDEffectline;
        CDEffect.Play();
        yield return new WaitForSeconds(5f);
        CDEffect.Stop();
    }

    //COUNTDOWN
    public void runWooshSound()
    {
        StartCoroutine(PlayWooshSound());
    }

    IEnumerator PlayWooshSound()
    {
        WooshEffect.clip = Wooshline;
        WooshEffect.Play();
        yield return new WaitForSeconds(2f);
        WooshEffect.Stop();
        runGoSound();
    }

    public void runGoSound()
    {
        StartCoroutine(PlayGoSound());
    }

    IEnumerator PlayGoSound()
    {
        WooshEffect.clip = Goline;
        WooshEffect.Play();
        yield return new WaitForSeconds(6f);
        WooshEffect.Stop();
    }


}
