using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player entered trigger");
            meshRenderer.enabled = true;
            other.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
