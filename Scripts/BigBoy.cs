using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoy : MonoBehaviour
{
    int damage = 1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().HandleDamage(damage);
        }
    }
}
