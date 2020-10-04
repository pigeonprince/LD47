using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    DialogHandler dialogHandler;

    void Start()
    {
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    public void GetItem(GameObject item, string[]message)
    {
        for (int i = 0; i < slots.Length; i++)
            {
                if (!isFull[i])
                {
                    isFull[i] = true;
                    Instantiate(item, slots[i].transform, false);
                    dialogHandler.DisplayMessage(message);
                    break;
                }
            }
    }

    public void GetItemWithoutMessage(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
            {
                if (!isFull[i])
                {
                    isFull[i] = true;
                    Instantiate(item, slots[i].transform, false);
                    break;
                }
            }
    }

}
