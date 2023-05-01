using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    //public static SoundManager instance { get; private set; }
    public static WinOrLose instance = null;
    public static WinOrLose Instance
    {
        get { return instance; }
    }

    private AudioSource source;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Find");
        }
        else
        {
            /*
            musicSource.clip = s.clip;
            musicSource.Play();
            */
            musicSource.PlayOneShot(s.clip);
        }
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Find");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Stop();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Find");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        Debug.Log("music");
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
