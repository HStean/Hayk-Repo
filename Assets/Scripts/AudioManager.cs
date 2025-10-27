using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;

    public AudioClip flip;
    public AudioClip match;
    public AudioClip missmatch;
    public AudioClip win;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }  
        else
        {
            Destroy(gameObject);
        }
            
    }


    public void Flip()
    {
        audioSource.PlayOneShot(flip);
    }
    public void Match()
    {
        audioSource.PlayOneShot(match);
    }
    public void MissMatch()
    {
        audioSource.PlayOneShot(missmatch);
    }
    public void Win()
    {
        audioSource.PlayOneShot(win);
    }
}
