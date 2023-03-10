using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fire;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    public void PlayFire() {
        audioSource.clip = fire;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
