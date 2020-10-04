using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRuby : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<IterationManager>().StartOver();
    }
}
