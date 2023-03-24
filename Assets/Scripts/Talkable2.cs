using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable2 : MonoBehaviour
{
    public Dialogue dialogue;
    public string[] lines;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (!hasPlayed && other.gameObject.tag == "Player") {
            dialogue.PlayLinesWithOptions(lines);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            dialogue.StopDialogue();
        }
    }
}
