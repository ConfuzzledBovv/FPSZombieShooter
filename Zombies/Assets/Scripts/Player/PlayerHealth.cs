using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void TakeDamge(float damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            FindObjectOfType<DeathHandler>().HandleDeath();
        }
    }
}
