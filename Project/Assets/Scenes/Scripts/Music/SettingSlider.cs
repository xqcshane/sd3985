using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    public Slider slider;
    public IntroMusicController introMusicController;
    public MainMenuMusic MyMusicpre;
    //public Slider soundControl;

    void Start(){
        MyMusicpre = GameObject.Find("BackgroundMusic").GetComponent<MainMenuMusic>();
        Debug.Log(MyMusicpre.soundvalue);
        introMusicController.IntroMusicVolume(MyMusicpre.soundvalue);
        slider.value = MyMusicpre.soundvalue;
        
    }

    public void IntroMusicVolume()
    {
        introMusicController.IntroMusicVolume(slider.value);
        if(MyMusicpre != null){
            MyMusicpre.soundvalue = slider.value;
        }
    }
}
