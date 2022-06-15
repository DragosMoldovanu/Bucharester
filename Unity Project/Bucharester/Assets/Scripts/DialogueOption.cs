using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOption : MonoBehaviour
{
    public GameObject inventory;
    public GameObject stats;
    private GameObject box;
    private GameObject player;
    public bool closesDialogue;
    public bool continuesDialogue;
    public int continueId;
    public GameObject interactObject;

    public string interactName;
    public bool affectsQuest;
    public int questId;

    public bool changesItem;
    public int itemId;
    public int itemQuantity;

    public bool changesMoney;
    public int quantity;

    public bool finishesGame;
    public GameObject gameCompleteScreen;

    void Start()
    {
        box = GameObject.Find("DialogueFade");
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (GetComponent<Button>().interactable)
        {
            transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1);
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().color = new Color(0.22f, 0.22f, 0.22f);
        }

        GetComponent<Button>().interactable = true;
        if (changesItem)
        {
            if (itemQuantity < 0)
            {
                foreach (InventoryManager.Item item in inventory.GetComponent<InventoryManager>().items)
                {
                    if (item.id == itemId)
                    {
                        return;
                    }
                }
                GetComponent<Button>().interactable = false;
            }
        }
        
        if (changesMoney)
        {
            if (quantity < 0)
            {
                if (stats.GetComponent<StatsManager>().moneyAmount < Mathf.Abs(quantity))
                {
                    GetComponent<Button>().interactable = false;
                    return;
                }
            }
        }
    }

    public void Selected()
    {
        if (closesDialogue)
        {
            box.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
        }

        if (continuesDialogue)
        {
            interactObject.GetComponent<OpenDialogue>().dialogueId = continueId;
            interactObject.GetComponent<OpenDialogue>().Open(false);
        }

        if (finishesGame)
        {
            gameCompleteScreen.SetActive(true);
        }
    }
}
