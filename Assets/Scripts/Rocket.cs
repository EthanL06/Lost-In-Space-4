using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public CollectibleManager collectibleManager;

    // Start is called before the first frame update
    void Start()
    {
        // Make all the children of this object inactive
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibleManager.allCollected) {
            // Make all the children of this object active
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
