using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusicController : MonoBehaviour
{
    private AudioSource introMusic;

    // Start is called before the first frame update
    void Start()
    {

        introMusic = MainMenuMusic.Instance.gameObject.GetComponent<AudioSource>();
    }

    public void IntroMusicVolume(float volume)
    {
        introMusic.volume = volume;
    }
}
