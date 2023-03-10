using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Add slider between 0 and 100
    [Range(0, 100)]
    public float Health = 100f;

    [Range(0, 100)]
    public float JetpackFuel = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefuelJetpack() {
        JetpackFuel = 100;
    }

    public void UseJetpack(float amount) {
        JetpackFuel -= amount;
        if (JetpackFuel < 0) {
            JetpackFuel = 0;
        }
    }
    
    public void CollectItem(string name) {
        // Add 10 to health
        Health += 10;
        // Add 10 to jetpack
        JetpackFuel += 10;

        Debug.Log("Collected " + name);
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collided with " + other.gameObject.name);
    }


}
