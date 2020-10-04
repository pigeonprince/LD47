using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Animator animator;
    public DialogHandler dialogHandler;
    public Npcdialog npc;
    public GameObject projectile;
    public float walkSpeed = 500f;

    public bool canLaunch = false;
    public float launchPower = 500;

    float horizontal;
    float vertical;
    Vector2 lookDirection = new Vector2(1,0);

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    void Update()
    {
        Interact();
        Launch();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody.position, lookDirection, 1.5f, LayerMask.GetMask("NPC"));

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.tag == "NPC")
                {
                    npc = hit.collider.GetComponent<Npcdialog>();
                    npc.MessageHandler();
                }
                else if (hit.transform.gameObject.tag == "Altar")
                {
                    Altar altar = hit.collider.GetComponent<Altar>();
                    altar.HandleInteraction();
                }
                else if (hit.transform.gameObject.tag == "PuzzleDoor")
                {
                    hit.transform.gameObject.GetComponent<PassPuzzle>().OpenPuzzle();
                }
            }
            else if (dialogHandler.messageReceived)
            {
                dialogHandler.NextSentence();
            }
            else { return; }
        }
    } 

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        rigidbody.velocity = new Vector2(horizontal * walkSpeed,  vertical * walkSpeed);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
    }

    private void Launch()
    {
        if (canLaunch)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                GameObject projectileObject = Instantiate(projectile, rigidbody.position, Quaternion.identity);

                projectileObject.GetComponent<Rigidbody2D>().AddForce(lookDirection* launchPower);
            }
        }
    }
}
