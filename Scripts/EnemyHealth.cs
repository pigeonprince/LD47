using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public Animator animator;

    public void ReduceHealth(int damage)
    {
        if (health > 0)
        {
            if (gameObject.name == "Big Boy")
            {
                animator = GetComponent<Animator>();
                animator.SetTrigger("damage");
            }
            health -= damage;
            if (health < 1 )
            {
                Destroy(gameObject);
            }
        }
    }

}
