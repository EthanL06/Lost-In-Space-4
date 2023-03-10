using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other) {
        // If the player collides with a collectible
        if (other.gameObject.tag == "Player") {
            audioSource.Play();
        }
    }
}
