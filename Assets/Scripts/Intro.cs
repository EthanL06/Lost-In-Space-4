using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{

    public Cinemachine.CinemachineFreeLook freelook;
    public Transform ship;
    public GameObject player;
    public GameObject alien;
    public Dialogue dialogue;
    public Animator shipAnimator;

    public Audio audio;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {            
        player.SetActive(false);
        alien.SetActive(false);

        freelook.Follow = ship;
        freelook.LookAt = ship;      
        dialogue.PlayLine("You: Mayday, mayday! We're going down!");
        StartCoroutine(StopDialogue());
        StartCoroutine(Cutscene());
    }


    IEnumerator StopDialogue() {
        yield return new WaitForSeconds(4);
        dialogue.StopDialogue();
    }
   
    IEnumerator Cutscene() {
        yield return new WaitForSeconds(8);
        audio.PlayFire();
        yield return new WaitForSeconds(2);
        // Camera moves to player
        player.SetActive(true);
        player.GetComponent<ThirdPersonMovement>().enabled = false;
        freelook.Follow = player.GetComponent<Transform>();
        freelook.LookAt = player.GetComponent<Transform>();

        yield return new WaitForSeconds(2);
        dialogue.PlayLines(new string[] { "You: Ouch... that hurts. Where am I? And who is THAT?"});

        
        yield return new WaitForSeconds(8);
        dialogue.StopDialogue();
        player.GetComponent<ThirdPersonMovement>().enabled = true;
        alien.SetActive(true);
        // Activate the background music component
        backgroundMusic.enabled = true;
        backgroundMusic.Play();
    }
}
