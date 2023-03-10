using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAllCollectiblesCollected : MonoBehaviour
{
    public CollectibleManager collectibleManager;
    public GameObject rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibleManager.allCollected) {
            rocket.SetActive(true);
        }
    }
}
