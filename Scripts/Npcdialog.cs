using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcdialog : MonoBehaviour
{
    [TextArea(3,5)]
    public string[] messages, questCompleteMessage, afterCompletionMessage;
    public GameObject reward;

    bool questFinished = false;

    DialogHandler dialogHandler;
    Inventory inventory;
    GameObject trinket;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MessageHandler()
    {
        if (!questFinished)
        {
            trinket = GameObject.Find("trinket(Clone)");
            if (trinket != null)
            {
                Destroy(trinket);
                inventory.GetItem(reward, questCompleteMessage);
                questFinished = true;
            }
            if (!dialogHandler.messageReceived)
            {
                dialogHandler.DisplayMessage(messages);
            }
            else
            {
                dialogHandler.NextSentence();
            }
        }
        else
        {
            dialogHandler.DisplayMessage(afterCompletionMessage);
        }
    }
}
