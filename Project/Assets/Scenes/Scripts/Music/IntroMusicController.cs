using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMusicController : MonoBehaviour
{
    private AudioSource introMusic;
    public Sound[] backgroundSounds;
    public Text NowPlaying;

    private int musicIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        introMusic = MainMenuMusic.Instance.gameObject.GetComponent<AudioSource>();
        musicIndex = MainMenuMusic.Instance.gameObject.GetComponent<MainMenuMusic>().nowMusic;
        NowPlaying.text = backgroundSounds[musicIndex].name;
        Debug.Log("musicIndex" + musicIndex);
    }

    private void Update()
    {
        NowPlaying.text = backgroundSounds[musicIndex].name;
    }

    public void IntroMusicVolume(float volume)
    {
        introMusic.volume = volume;
    }

    public void NextMusic()
    {
        musicIndex += 1;
        if (musicIndex > 5)
        {
            musicIndex = 0;
        }
        MainMenuMusic.Instance.gameObject.GetComponent<MainMenuMusic>().nowMusic = musicIndex;
        Debug.Log("musicIndex" + musicIndex);
        introMusic.Stop();
        introMusic.clip = backgroundSounds[musicIndex].clip;
        introMusic.Play();
    }

    public void PreviousMusic()
    {
        musicIndex -= 1;
        if (musicIndex < 0)
        {
            musicIndex = 5;
        }
        MainMenuMusic.Instance.gameObject.GetComponent<MainMenuMusic>().nowMusic = musicIndex;
        Debug.Log("musicIndex" + musicIndex);
        introMusic.Stop();
        introMusic.clip = backgroundSounds[musicIndex].clip;
        introMusic.Play();
    }
}
