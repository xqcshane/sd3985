using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    public Slider slider;
    public IntroMusicController introMusicController;
    //public Slider soundControl;

    public void IntroMusicVolume()
    {
        introMusicController.IntroMusicVolume(slider.value);
    }
}
