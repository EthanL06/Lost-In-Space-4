using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform startingCheckpoint;
    public Transform currentCheckpoint;
    public Transform player;

    private void Update() {

       transform.position = currentCheckpoint.position;
    }

    public void SetCheckpoint(Checkpoint checkpoint) {
        currentCheckpoint = checkpoint.transform;
    }
}
