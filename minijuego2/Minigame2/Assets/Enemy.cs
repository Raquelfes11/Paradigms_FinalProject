using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health = 4f;

    public static int EnemiesAlive = 0;

    void Start()
    {
        EnemiesAlive++;
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude>health)//Information about the collision
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        EnemiesAlive--;

        if (EnemiesAlive<=0)
        {
            Debug.Log("WELL DONE, NOW YOU CAN SEE THE NEXT CLUE IN ORDER TO SCAPE THE ROOM\nSecret Word:\n*********Butterfly*********");



        }

        Destroy(gameObject);
    }
    
}
