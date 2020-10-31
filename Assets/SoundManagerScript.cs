using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip winSound, candyCornSound, deathSound, deleteSound, gumballSound, loseLifeSound, nextWaveSound, pezSound, pixyStixSound, upgradeSound, gameoverSound;
    static AudioSource audioSrc;
    void Start()
    {
        winSound = Resources.Load<AudioClip>("win");
        candyCornSound = Resources.Load<AudioClip>("candyCorn");
        deathSound = Resources.Load<AudioClip>("deathSound");
        deleteSound = Resources.Load<AudioClip>("delete");
        gumballSound = Resources.Load<AudioClip>("gumball");
        loseLifeSound = Resources.Load<AudioClip>("loseLife");
        nextWaveSound = Resources.Load<AudioClip>("nextWave");
        pezSound = Resources.Load<AudioClip>("pez");
        pixyStixSound = Resources.Load<AudioClip>("pixyStix");
        upgradeSound = Resources.Load<AudioClip>("upgrade");
        gameoverSound = Resources.Load<AudioClip>("gameover");


        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            case "candyCorn":
                audioSrc.PlayOneShot(candyCornSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "delete":
                audioSrc.PlayOneShot(deleteSound);
                break;
            case "gumball":
                audioSrc.PlayOneShot(gumballSound);
                break;
            case "loseLife":
                audioSrc.PlayOneShot(loseLifeSound);
                break;
            case "nextWave":
                audioSrc.PlayOneShot(nextWaveSound);
                break;
            case "pez":
                audioSrc.PlayOneShot(pezSound);
                break;
            case "pixyStix":
                audioSrc.PlayOneShot(pixyStixSound);
                break;
            case "upgrade":
                audioSrc.PlayOneShot(upgradeSound);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameoverSound);
                break;
            default:
                break;
        }
    }
}
