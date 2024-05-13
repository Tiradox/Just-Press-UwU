using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    public UnityEvent dieEvent;
    public UnityEvent takeDamage;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
        else if (health > 0 && takeDamage!=null)
        {
            takeDamage.Invoke();
        }
    }

    public void Die()
    {
        dieEvent.Invoke();
    }
}
