using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform startingCheckpoint;
    public Transform currentCheckpoint;
    public Transform player;

    private void Update() {
        // If player clicks "R" key, reset to current checkpoint
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Resetting to checkpoint");
            Debug.Log(currentCheckpoint.position);
            // Get the character controller component
            ResetToCheckpoint();
        
        }
    }

    public void ResetToCheckpoint() {
        CharacterController controller = player.GetComponent<CharacterController>();
        player.gameObject.GetComponent<Health>().ResetHealth();
        player.gameObject.GetComponent<PlayerController>().RefuelJetpack();
        player.gameObject.GetComponent<ThirdPersonMovement>().enabled = true;
        controller.enabled = false;
        transform.position = currentCheckpoint.position;
        controller.enabled = true;
    }
    

    public void SetCheckpoint(Checkpoint checkpoint) {
        currentCheckpoint = checkpoint.transform;
    }
}
