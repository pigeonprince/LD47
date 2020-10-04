using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;
    public bool vertical;
    public Rigidbody2D rigidbody;
    public Animator animator;
    int direction = 1;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        Vector2 position = rigidbody.position;

        if(vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move Y", direction);

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
        }
        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().HandleDamage(damage);
        }
        else
        {
            direction = -direction;
        }
    }
}
