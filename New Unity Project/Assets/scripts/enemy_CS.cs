using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_CS : MonoBehaviour
{
    [SerializeField] int health = 100;
    public float speed = 10f;
    

    // Update is called once per frame
   

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        WaveSpawner_CS.EnemiesAlive--;
        Destroy(gameObject);
    }

   
}
