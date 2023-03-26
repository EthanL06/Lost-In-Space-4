using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform respawn; 
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player clicks "R" key, reset to current checkpoint
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Resetting to checkpoint");
            // Set player position to respawn position
            ResetToCheckpoint();
        
        }   
    }

    public void ResetToCheckpoint() {
        CharacterController controller = player.GetComponent<CharacterController>();
        player.gameObject.GetComponent<Health>().ResetHealth();
        player.gameObject.GetComponent<PlayerController>().RefuelJetpack();
        player.gameObject.GetComponent<ThirdPersonMovement>().enabled = true;
        controller.enabled = false;
        player.position = respawn.position;
        controller.enabled = true;
    }
}
