using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook freelook;
    public Transform ship;
    public GameObject player;
    public GameObject astronaut;
    public Dialogue dialogue;
    public Canvas playerUI;
    public Animator shipAnimator;
    public CollectibleManager collectibleManager;

    private IEnumerator Play() {
        dialogue.StopDialogue();
        player.SetActive(false);
        astronaut.SetActive(false);

        yield return new WaitForSeconds(2);

        dialogue.PlayLine("3... 2... 1... Blast off!");

        yield return new WaitForSeconds(3);

        dialogue.StopDialogue();
        playerUI.GetComponent<Canvas>().enabled = false;

        freelook.Follow = ship.GetComponent<Transform>();
        freelook.LookAt = ship.GetComponent<Transform>();

        shipAnimator.Play("Launch");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && collectibleManager.allCollected) {
            Debug.Log("Player entered trigger");
            StartCoroutine("Play");
        }
    }
}
