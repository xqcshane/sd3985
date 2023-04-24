using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource startMenuMusic;

    private static MainMenuMusic instance = null;
    public static MainMenuMusic Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("huang");
            startMenuMusic.Play();
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Debug.Log("yu");
            if (instance.GetComponent<AudioSource>().isPlaying)
            {
                Debug.Log("yu1");
                Destroy(gameObject);
                return;
            }
            else
            {
                Debug.Log("yu2");
                //Destroy(gameObject);
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            Debug.Log("feng");
            Destroy(gameObject);
            return;
        }
    }
}
