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
    public int dialogueId;

    [Header("Option 1")]
    public GameObject optionButton1;

    [Header("Option 2")]
    public GameObject optionButton2;

    [Header("Option 3")]
    public GameObject optionButton3;

    // Update is called once per frame
    public void Open()
    {
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        box.SetActive(true);

        Database.TreeNode node = Database.treeDatabase[dialogueId];
        Database.Dialogue dialogue = node.current;

        title.text = dialogue.name;
        description.text = dialogue.line;

        if (dialogue.option1 != null)
        {
            optionButton1.SetActive(true);
            optionButton1.transform.Find("Text").GetComponent<Text>().text = dialogue.option1;
            if (node.option1 != null) {
                foreach (Database.DialogueEffect effect in node.option1.effects)
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
            }
            else
            {
                optionButton1.GetComponent<DialogueOption>().closesDialogue = true;
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
            if (node.option2 != null)
            {
                foreach (Database.DialogueEffect effect in node.option2.effects)
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
            }
            else
            {
                optionButton2.GetComponent<DialogueOption>().closesDialogue = true;
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
            if (node.option3 != null)
            {
                foreach (Database.DialogueEffect effect in node.option3.effects)
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
            }
            else
            {
                optionButton3.GetComponent<DialogueOption>().closesDialogue = true;
            }
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
