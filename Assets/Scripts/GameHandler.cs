using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private float playerHealth;

    private void Start()
    {
        playerHealth = 1.0f;
        healthBar.SetSize(playerHealth);
        LowerPlayerHealth(0.2f);
    }
    public void LowerPlayerHealth(float damage)
    {
        if (playerHealth > 0) {
            playerHealth -= damage;
            healthBar.SetSize(playerHealth);
        }
    }


}
