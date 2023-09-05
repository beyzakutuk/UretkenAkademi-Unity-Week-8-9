using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider MusicSlider;
    public Slider SfxSlider;

    void Start()
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
            mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));

            SetSlider();
        }
        else
        {
            SetSlider();
        }

    }

    void Update()
    {
        
    }

    void SetSlider()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void UpdateMusicVolume()
    {
        mixer.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }
    public void UpdateSfxVolume()
    {
        mixer.SetFloat("SFXVolume", SfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SfxSlider.value);
    }
}
