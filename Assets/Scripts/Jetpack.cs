using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{
    public Image JetpackBar;
    private float CurrentJetpack = 100f;
    private float MaxJetpack = 100f;
    public PlayerController Player;

    void Update()
    {
        // If the player is holding E, 
        CurrentJetpack = Player.JetpackFuel;
        JetpackBar.fillAmount = CurrentJetpack / MaxJetpack;    
    }
}
