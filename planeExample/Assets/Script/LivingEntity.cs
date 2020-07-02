using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageAble
{
    public float startingHealth;
    [SerializeField]
    protected float health;

    protected bool dead;

    public virtual void Start()
    {
        health = startingHealth;

    }

    public void TakeHit(float damage, Collider hit)
    {
        health = health - damage;

        if(health <= 0)
        {
            Die();
        }


    }

    public virtual void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
   



}
