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
                }

                if (effect is Database.MoneyEffect)
                {
                    optionButton1.GetComponent<DialogueOption>().changesMoney = true;
                    optionButton1.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                }
            }
        }
        else
        {
            optionButton1.SetActive(false);
        }
        if (dialogue.option2 != null)
        {
            optionButton1.SetActive(true);
            optionButton1.transform.Find("Text").GetComponent<Text>().text = dialogue.option2;

            foreach (Database.DialogueEffect effect in node.option2.effects)
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
                }

                if (effect is Database.MoneyEffect)
                {
                    optionButton1.GetComponent<DialogueOption>().changesMoney = true;
                    optionButton1.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                }
            }
        }
        else
        {
            optionButton2.SetActive(false);
        }
        if (dialogue.option3 != null)
        {
            optionButton1.SetActive(true);
            optionButton1.transform.Find("Text").GetComponent<Text>().text = dialogue.option3;

            foreach (Database.DialogueEffect effect in node.option3.effects)
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
                }

                if (effect is Database.MoneyEffect)
                {
                    optionButton1.GetComponent<DialogueOption>().changesMoney = true;
                    optionButton1.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                }
            }
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
