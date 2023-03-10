using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{

    public Image HealthBar;
    private float CurrentHealth = 100f;
    private float MaxHealth = 100f;
    public PlayerController Player;
    public GameObject playerBody;
    public TextMeshProUGUI deadText;

    public void TakeDamage(float damage)
    {
        Player.Health -= damage;
    }

    public void ResetHealth()
    {
        Player.Health = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.Health <= 0)
        {
            Player.Health = 0;
            GetComponent<ThirdPersonMovement>().enabled = false;
            playerBody.SetActive(false);
            deadText.text = "You died! Press R to restart.";
        } else {
            playerBody.SetActive(true);
            deadText.text = "";
        }

        CurrentHealth = Player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
