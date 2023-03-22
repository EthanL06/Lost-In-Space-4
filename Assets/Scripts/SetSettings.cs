using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSettings : MonoBehaviour
{
    public AudioSource music;
    public AudioSource[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        // set graphic quality
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 2));

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
