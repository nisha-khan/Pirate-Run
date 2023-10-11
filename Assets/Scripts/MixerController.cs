using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider SfxSlider;
    public AudioMixer mixer;

    const string MIXER_VOLUME = "MusicVolume";
    const string MIXER_SFX = "SFX";
    const string VOLUME_PREF = "SavedMusicVolume";
    const string SFX_PREF = "SavedSFXVolume";

    private void Awake()
    {
        // Load saved volume settings from PlayerPrefs or use default values
        float savedVolume = PlayerPrefs.GetFloat(VOLUME_PREF, 0.5f);
        float savedSfx = PlayerPrefs.GetFloat(SFX_PREF, 0.5f);

        // Apply the saved volume settings to the sliders and Audio Mixer
        VolumeSlider.value = savedVolume;
        SfxSlider.value = savedSfx;
        SetMusicVolume(savedVolume);
        SetSFXVolume(savedSfx);

        // Add listeners to the sliders
        VolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        SfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_VOLUME, value);
        PlayerPrefs.SetFloat(VOLUME_PREF, value); // Save the volume setting
        PlayerPrefs.Save();
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, value);
        PlayerPrefs.SetFloat(SFX_PREF, value); // Save the SFX setting
        PlayerPrefs.Save();
    }
}
