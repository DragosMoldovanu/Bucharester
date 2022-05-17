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

    public string interactName;
    public bool affectsQuest;
    public int questId;

    public bool changesItem;
    public int itemId;

    public bool changesMoney;
    public int quantity;

    void Start()
    {
        box = GameObject.Find("DialogueBox");
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (changesItem)
        {
            if (quantity < 0)
            {
                foreach (InventoryManager.Item item in inventory.GetComponent<InventoryManager>().items)
                {
                    if (item.id == itemId)
                    {
                        return;
                    }
                }
                GetComponent<Button>().interactable = false;
                return;
            }
        }
        GetComponent<Button>().interactable = true;
    }

    public void Selected()
    {
        if (closesDialogue)
        {
            box.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
        }

        if (affectsQuest)
        {
            Database.Quest quest = Database.questDatabase[questId];

            if (quest.sourceName == interactName)
            {
                GameObject.Find("QuestList").GetComponent<QuestManager>().AcceptQuest(questId);
            }
            else
            {
                foreach (Database.QuestObjective objective in quest.objectives)
                {
                    if (objective is Database.InteractObjective)
                    {
                        GameObject.Find("QuestList").GetComponent<QuestManager>().CompleteQuest(questId);
                    }
                }
            }
        }

        if (changesItem)
        {
            if (quantity > 0)
            {
                inventory.GetComponent<InventoryManager>().AddItem(itemId);
            }
            else
            {
                inventory.GetComponent<InventoryManager>().RemoveItem(itemId);
            }
        }

        if (changesMoney)
        {
            stats.GetComponent<StatsManager>().UpdateMoney(quantity);
        }
    }
}
