using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{

    public TextMeshProUGUI collectibleText;
    public Transform[] collectiblePositions;
    public Transform shipPosition;
    public Transform playerPosition;
    private float distance;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool allCollected {
        get {
            foreach (Transform collectible in collectiblePositions) {
                if (collectible != null)
                    return false;
            }
            return true;
        }
    }

    public void PlaySuccsess() {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Find the closest collectible to the player
        Transform closest = null;
        float closestDistance = Mathf.Infinity;
        foreach (Transform collectible in collectiblePositions) {
            if (collectible == null)
                continue;
                
            distance = Vector3.Distance(collectible.position, playerPosition.position);
            if (distance < closestDistance) {
                closest = collectible;
                closestDistance = distance;
            }
        }

        // If all the collectibles are null, set the text to "All collectibles collected"
        if (closest == null) {
            distance = Vector3.Distance(shipPosition.position, playerPosition.position);
            collectibleText.text = "Go to your rocket! (" + distance.ToString("F2") + "m)";
        } else {
            // Update the text and round the distance to 2 decimal places
            collectibleText.text = "Closest rocket part: " + closestDistance.ToString("F2") + "m";
        }


    }
}
