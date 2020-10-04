using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairs : MonoBehaviour
{
    public Transform endingSpawnPoint;
    public GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = endingSpawnPoint.position;
    }
}
