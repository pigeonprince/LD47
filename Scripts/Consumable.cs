using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public int restoreAmount = 1;
    Health health;

    public void Restoration()
    {
        health = FindObjectOfType<Health>();
        if (health.health < health.numOfHearts)
        {
            health.AddHealth(restoreAmount);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
