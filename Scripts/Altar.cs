using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [TextArea(3,5)]
    public string[] messages;
    DialogHandler dialogHandler;
    IterationManager iterationManager;

    GameObject inventory;

    void Start()
    {
        iterationManager = FindObjectOfType<IterationManager>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        inventory = FindObjectOfType<Inventory>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleInteraction()
    {
        CheckItems();
    }

    private void CheckItems()
    {
        GameObject WhiteRuby;
        GameObject RedRuby;
        GameObject OrangeRuby;
        GameObject YellowRuby;
        GameObject GreenRuby;
        GameObject BlueRuby;
        GameObject IndigoRuby;
        GameObject PurpleRuby;
        GameObject BlackRuby;
        GameObject CrystalSkull;

        WhiteRuby = GameObject.Find("WhiteRuby(Clone)");
        RedRuby = GameObject.Find("RedRuby(Clone)");
        OrangeRuby = GameObject.Find("orangeruby(Clone)");
        YellowRuby = GameObject.Find("YellowRuby(Clone)");
        GreenRuby = GameObject.Find("GreenRuby(Clone)");
        BlueRuby = GameObject.Find("BlueRuby(Clone)");
        IndigoRuby = GameObject.Find("IndigoRuby(Clone)");
        PurpleRuby = GameObject.Find("PurpleRuby(Clone)");
        BlackRuby = GameObject.Find("BlackRuby(Clone)");
        CrystalSkull = GameObject.Find("CrystalSkull(Clone)");
        if (WhiteRuby != null)
        {
            Destroy(WhiteRuby);
            iterationManager.FirstRespawn();
        }
        else if (RedRuby != null)
        {
            Destroy(RedRuby);
            iterationManager.RemoveSpikes();
        }
        else if (OrangeRuby != null)
        {
            Destroy(OrangeRuby);
            iterationManager.SetBridge();
        }
        else if (YellowRuby != null)
        {
            Destroy(YellowRuby);
            iterationManager.RewardTrinket();
        }
        else if (GreenRuby != null)
        {
            Destroy(GreenRuby);
            iterationManager.ActivateProjectileShooting();
        }
        else if (BlueRuby != null)
        {
            Destroy(BlueRuby);
            iterationManager.RemoveWater();
        }
        else if (IndigoRuby != null)
        {
            Destroy(IndigoRuby);
            iterationManager.PassMemo();
        }
        else if (PurpleRuby != null)
        {
            Destroy(PurpleRuby);
            iterationManager.HiddenRoomDetector();
        }
        else if (BlackRuby != null)
        {
            Destroy(BlackRuby);
            iterationManager.GiveCrystalSkull();
        }
        else if (CrystalSkull != null)
        {
            Destroy(CrystalSkull);
            iterationManager.OpenStairs();
        }
        else
        {
            MessageHandler();
        }
    }

    public void MessageHandler()
    {
        if (!dialogHandler.messageReceived)
        {
            dialogHandler.DisplayMessage(messages);
        }
        else
        {
            dialogHandler.NextSentence();
        }
    }
}
