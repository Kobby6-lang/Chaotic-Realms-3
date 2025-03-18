using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwabena.FinalCharacterController
{
    public class PlayerHealth : MonoBehaviour
    {
        public int Health = 100; // Starting health

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Debug.Log($"Current Health: {Health}");

            if (Health <= 0)
            {
                Destroy(this.gameObject); // Destroy the player GameObject
                Debug.Log("Player has been destroyed!");
            }
        }
    }

}