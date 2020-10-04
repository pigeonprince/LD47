using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    Inventory inventory;
    public int i;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update(){
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
        if(transform.childCount == 1)
        {
            inventory.isFull[i] = true;
        }
    }
}
