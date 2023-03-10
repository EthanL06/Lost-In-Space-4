using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter(Collider other) {
        // If the player collides with a collectible
        if (other.gameObject.tag == "Player") {
            // Get parent of this object
            gameObject.GetComponentInParent<CollectibleManager>().PlaySuccsess();
            player.RefuelJetpack();
            // Call the CollectItem function on the player
            other.gameObject.GetComponent<PlayerController>().CollectItem(gameObject.name);
            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
