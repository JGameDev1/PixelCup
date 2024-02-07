using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MusicManager : MonoBehaviour
{
    public static MusicManager sharedInstance;
    public List<AudioClip> SongsToPlayInMatch;
    public List<AudioClip> SongsToPlayInPenalties;
    public List<AudioClip> SongsToPlayInRunner;
    public AudioSource audiosource;
    public MenuManager menuManager;
    public bool runner,normalMatch,penalties;

    private void Awake()
    {
        if (MusicManager.sharedInstance != null)
        { Destroy(gameObject); }
        else
        {
            MusicManager.sharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        audiosource = GetComponent<AudioSource>();
    }
    void Start()
    {
        audiosource.clip = SongsToPlayInMatch[0];
        audiosource.Play();
    }

    public void ChangeSong()
    {
        audiosource.Stop();
        if(normalMatch&&!runner&&!penalties)
        {   audiosource.Stop();
            audiosource.clip=SongsToPlayInMatch[Random.Range(0,SongsToPlayInMatch.Count)];
            audiosource.Play();
        }
        else if(!normalMatch&&runner&&!penalties)
        {
            audiosource.Stop();
            audiosource.clip=SongsToPlayInRunner[Random.Range(0,SongsToPlayInRunner.Count)];
            audiosource.Play();
        }
        else if(!normalMatch&&!runner&&penalties)
        {
            audiosource.Stop();
            audiosource.clip=SongsToPlayInPenalties[Random.Range(0,SongsToPlayInPenalties.Count)];
            audiosource.Play();
        }

    }
}
