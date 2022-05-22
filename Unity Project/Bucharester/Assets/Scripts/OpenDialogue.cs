using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDialogue : MonoBehaviour
{
    public GameObject player;

    [Header("Dialogue")]
    public GameObject box;
    public Text title;
    public Text description;
    public int startDialogue;
    public int dialogueId;

    [Header("Option 1")]
    public GameObject optionButton1;

    [Header("Option 2")]
    public GameObject optionButton2;

    [Header("Option 3")]
    public GameObject optionButton3;

    // Update is called once per frame
    public void Open(bool startOver = true)
    {
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        box.SetActive(true);

        Database.TreeNode node;
        if (startOver)
        {
            node = Database.treeDatabase[startDialogue];
        }
        else
        {
            node = Database.treeDatabase[dialogueId];
        }
        Database.Dialogue dialogue = node.current;

        title.text = dialogue.name;
        description.text = dialogue.line;

        foreach (Database.DialogueEffect effect in dialogue.effects)
        {
            if (effect is Database.QuestEffect)
            {
                Database.QuestEffect quest = effect as Database.QuestEffect;
                if (quest.accept)
                {
                    GameObject.Find("QuestList").GetComponent<QuestManager>().AcceptQuest(quest.questId);
                }
                else if (quest.complete)
                {
                    GameObject.Find("QuestList").GetComponent<QuestManager>().CompleteQuest(quest.questId);
                }
            }
            else if (effect is Database.ItemEffect)
            {
                Database.ItemEffect item = effect as Database.ItemEffect;
                if (item.quantity > 0)
                {
                    GameObject.Find("Inventory").GetComponent<InventoryManager>().AddItem(item.itemId);
                }
                else if (item.quantity < 0)
                {
                    GameObject.Find("Inventory").GetComponent<InventoryManager>().RemoveItem(item.itemId);
                }
            }
            else if (effect is Database.MoneyEffect)
            {
                Database.MoneyEffect money = effect as Database.MoneyEffect;
                GameObject.Find("Stats").GetComponent<StatsManager>().UpdateMoney(money.quantity);
            }
            else if (effect is Database.ChangeEffect)
            {
                Database.ChangeEffect change = effect as Database.ChangeEffect;
                startDialogue = change.id;
            }
            else if (effect is Database.DestroyEffect)
            {
                Destroy(gameObject);
            }
        }

        if (dialogue.option1 != null)
        {
            optionButton1.SetActive(true);
            optionButton1.transform.Find("Text").GetComponent<Text>().text = dialogue.option1;
            if (node.option1 > 0) {
                foreach (Database.DialogueEffect effect in Database.dialogueDatabase[node.option1].effects)
                {
                    if (effect is Database.QuestEffect)
                    {
                        optionButton1.GetComponent<DialogueOption>().affectsQuest = true;
                        optionButton1.GetComponent<DialogueOption>().interactName = name;
                        optionButton1.GetComponent<DialogueOption>().questId = (effect as Database.QuestEffect).questId;
                    }

                    if (effect is Database.ItemEffect)
                    {
                        optionButton1.GetComponent<DialogueOption>().changesItem = true;
                        optionButton1.GetComponent<DialogueOption>().itemId = (effect as Database.ItemEffect).itemId;
                        optionButton1.GetComponent<DialogueOption>().itemQuantity = (effect as Database.ItemEffect).quantity;
                    }

                    if (effect is Database.MoneyEffect)
                    {
                        optionButton1.GetComponent<DialogueOption>().changesMoney = true;
                        optionButton1.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                    }
                }
                optionButton1.GetComponent<DialogueOption>().closesDialogue = false;
                optionButton1.GetComponent<DialogueOption>().continuesDialogue = true;
                optionButton1.GetComponent<DialogueOption>().continueId = node.option1;
                optionButton1.GetComponent<DialogueOption>().interactObject = gameObject;
            }
            else
            {
                optionButton1.GetComponent<DialogueOption>().closesDialogue = true;
                optionButton1.GetComponent<DialogueOption>().continuesDialogue = false;
            }
        }
        else
        {
            optionButton1.SetActive(false);
        }



        if (dialogue.option2 != null)
        {
            optionButton2.SetActive(true);
            optionButton2.transform.Find("Text").GetComponent<Text>().text = dialogue.option2;
            if (node.option2 > 0)
            {
                foreach (Database.DialogueEffect effect in Database.dialogueDatabase[node.option2].effects)
                {
                    if (effect is Database.QuestEffect)
                    {
                        optionButton2.GetComponent<DialogueOption>().affectsQuest = true;
                        optionButton2.GetComponent<DialogueOption>().interactName = name;
                        optionButton2.GetComponent<DialogueOption>().questId = (effect as Database.QuestEffect).questId;
                    }

                    if (effect is Database.ItemEffect)
                    {
                        optionButton2.GetComponent<DialogueOption>().changesItem = true;
                        optionButton2.GetComponent<DialogueOption>().itemId = (effect as Database.ItemEffect).itemId;
                        optionButton2.GetComponent<DialogueOption>().itemQuantity = (effect as Database.ItemEffect).quantity;
                    }

                    if (effect is Database.MoneyEffect)
                    {
                        optionButton2.GetComponent<DialogueOption>().changesMoney = true;
                        optionButton2.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                    }
                }
                optionButton2.GetComponent<DialogueOption>().closesDialogue = false;
                optionButton2.GetComponent<DialogueOption>().continuesDialogue = true;
                optionButton2.GetComponent<DialogueOption>().continueId = node.option2;
                optionButton2.GetComponent<DialogueOption>().interactObject = gameObject;
            }
            else
            {
                optionButton2.GetComponent<DialogueOption>().closesDialogue = true;
                optionButton2.GetComponent<DialogueOption>().continuesDialogue = false;
            }
        }
        else
        {
            optionButton2.SetActive(false);
        }



        if (dialogue.option3 != null)
        {
            optionButton3.SetActive(true);
            optionButton3.transform.Find("Text").GetComponent<Text>().text = dialogue.option3;
            if (node.option3 > 0)
            {
                foreach (Database.DialogueEffect effect in Database.dialogueDatabase[node.option3].effects)
                {
                    if (effect is Database.QuestEffect)
                    {
                        optionButton3.GetComponent<DialogueOption>().affectsQuest = true;
                        optionButton3.GetComponent<DialogueOption>().interactName = name;
                        optionButton3.GetComponent<DialogueOption>().questId = (effect as Database.QuestEffect).questId;
                    }

                    if (effect is Database.ItemEffect)
                    {
                        optionButton3.GetComponent<DialogueOption>().changesItem = true;
                        optionButton3.GetComponent<DialogueOption>().itemId = (effect as Database.ItemEffect).itemId;
                        optionButton3.GetComponent<DialogueOption>().itemQuantity = (effect as Database.ItemEffect).quantity;
                    }

                    if (effect is Database.MoneyEffect)
                    {
                        optionButton3.GetComponent<DialogueOption>().changesMoney = true;
                        optionButton3.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                    }
                }
                optionButton3.GetComponent<DialogueOption>().closesDialogue = false;
                optionButton3.GetComponent<DialogueOption>().continuesDialogue = true;
                optionButton3.GetComponent<DialogueOption>().continueId = node.option3;
                optionButton3.GetComponent<DialogueOption>().interactObject = gameObject;
            }
            else
            {
                optionButton3.GetComponent<DialogueOption>().closesDialogue = true;
                optionButton3.GetComponent<DialogueOption>().continuesDialogue = false;
            }
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
