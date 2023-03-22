using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Settings : MonoBehaviour
{

    public Slider musicSlider;
    public Slider sfxSlider;
    public TMPro.TMP_Dropdown qualityDropdown;

    public void Start() {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        qualityDropdown.onValueChanged.AddListener(SetQuality);

        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
        qualityDropdown.value = PlayerPrefs.GetInt("quality", 2);
    }

    public void SetMusicVolume(float volume) {
        Debug.Log("Music volume: " + musicSlider.value);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void SetSFXVolume(float volume) {
        Debug.Log("SFX volume: " + sfxSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

    public void SetQuality(int qualityIndex) {
        Debug.Log("Quality: " + qualityDropdown.options[qualityDropdown.value].text);
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        PlayerPrefs.SetInt("quality", qualityIndex);
    }

    public void Back() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel", 0));
    }
}
