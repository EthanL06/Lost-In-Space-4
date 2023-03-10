using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float damageMultiplier = 3f;
    public float velocityThreshold = -5f;
    public PlayerController player;
    private CharacterController controller;
    private float lastYVelocity;

    private void Start() {
        controller = GetComponent<CharacterController>();    
    }

    private void Update() {
        if (controller.isGrounded) {
            if (lastYVelocity < velocityThreshold) {
                float damage = (lastYVelocity * -1) * damageMultiplier;
                Debug.Log("Damage: " + damage);
                player.Health -= damage;
            }
            lastYVelocity = 0;
        } else {
            lastYVelocity = controller.velocity.y;
        }
    }
}
