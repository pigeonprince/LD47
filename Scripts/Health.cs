using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    bool isInvincible;
    float invincibleTimer;
    float timeInvincible = 2f;
    Animator animator;

    IterationManager iterationManager;

    void Start()
    {
        iterationManager = FindObjectOfType<IterationManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite=emptyHeart;
            }
            if ( i< numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    public void HandleDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        } 
        else
        {
            if (health > 0)
            {
                health -= damage;
                animator.SetTrigger("damage");
                isInvincible = true;
                invincibleTimer = timeInvincible;
                if (health < 1)
                {
                    iterationManager.Restart();
                }
            }
            else {return;}
        }
    }

    public void AddHealth(int addition)
    {
        if (health < numOfHearts)
        {
            health += addition;
        }
        if (health >= numOfHearts)
        {
            return;
        }
    }
}
