using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogHandler : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject nextButton;
    public TextMeshProUGUI textMeshText;
    string[] message;
    int index;
    public float typingSpeed = 0.03f;
    public bool messageReceived = false;
    bool messageTyping = false;

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void DisplayMessage(string[] fetchedMessage)
    {
        if(!messageReceived)
        {
            messageReceived = true;
            textMeshText.text="";    
            message = fetchedMessage;
            StartCoroutine(TypeOutMessage());
        }
        else {return;}
    }
    
    IEnumerator TypeOutMessage()
    {
        messageTyping = true;
        dialogPanel.SetActive(true);
        nextButton.SetActive(false);
        foreach (char letter in message[index].ToCharArray())
        {
            textMeshText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        messageTyping = false;
        nextButton.SetActive(true);
    }

    public void NextSentence()
    {
        if(!messageTyping)
        {
            nextButton.SetActive(false);
            if(index < message.Length - 1)
            {
                index++;
                textMeshText.text = "";
                StartCoroutine(TypeOutMessage());
            }
            else
            {
                index = 0;
                dialogPanel.SetActive(false);
                textMeshText.text = "";
                messageReceived = false;
            }
        }
        else { return; }
    }

}
