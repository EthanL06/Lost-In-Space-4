using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SetSettings : MonoBehaviour
{

    public PostProcessLayer postProcessLayer;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
        Debug.Log(PlayerPrefs.GetFloat("musicVolume"));
        music.volume = PlayerPrefs.GetFloat("musicVolume", 0.5f);

        // Get all particle systems
        ParticleSystem[] particleSystems = FindObjectsOfType<ParticleSystem>();
        

        switch (PlayerPrefs.GetInt("quality")) {
            case 0:
                // Disable all particle systems
                foreach (ParticleSystem particleSystem in particleSystems) {
                    particleSystem.Stop();
                    particleSystem.gameObject.SetActive(false);
                }

                // Disable post processing
                postProcessLayer.enabled = false;
                break;
            case 1:
                postProcessLayer.enabled = false;
                break;
            case 2:
                Debug.Log("Quality 2");
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
