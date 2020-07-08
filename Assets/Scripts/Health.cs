using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;


    public float GetHealth()
    {
        return health;
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        if (IsDead())
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }

        GameObject deathVFXObject = Instantiate(deathVFX, transform.position,transform.rotation);
        deathVFXObject.transform.position = transform.position;
        Destroy(deathVFXObject,1f);
    }

    private bool IsDead()
    {
        return health <= 0;
    }
}
