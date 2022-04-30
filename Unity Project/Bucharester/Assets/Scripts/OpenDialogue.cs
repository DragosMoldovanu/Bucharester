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
    public string dialogueTitle;
    public string dialogueText;

    [Header("Option 1")]
    public GameObject optionButton1;
    public bool hasOption1;
    public string option1;

    public bool affectsQuest1;
    public int questId1;

    public bool changesItem1;
    public int itemId1;
    public int quantity1;

    [Header("Option 2")]
    public GameObject optionButton2;
    public bool hasOption2;
    public string option2;

    public bool affectsQuest2;
    public int questId2;

    public bool changesItem2;
    public int itemId2;
    public int quantity2;

    [Header("Option 3")]
    public GameObject optionButton3;
    public bool hasOption3;
    public string option3;

    public bool affectsQuest3;
    public int questId3;

    public bool changesItem3;
    public int itemId3;
    public int quantity3;

    // Update is called once per frame
    public void Open()
    {
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        box.SetActive(true);

        title.text = dialogueTitle;
        description.text = dialogueText;

        if (hasOption1)
        {
            optionButton1.SetActive(true);
            optionButton1.transform.Find("Text").GetComponent<Text>().text = option1;

            if (affectsQuest1)
            {
                optionButton1.GetComponent<DialogueOption>().affectsQuest = true;
                optionButton1.GetComponent<DialogueOption>().interactName = name;
                optionButton1.GetComponent<DialogueOption>().questId = questId1;
            }

            if (changesItem1)
            {
                optionButton1.GetComponent<DialogueOption>().changesItem = true;
                optionButton1.GetComponent<DialogueOption>().itemId = itemId1;
                optionButton1.GetComponent<DialogueOption>().quantity = quantity1;
            }
        }
        else
        {
            optionButton1.SetActive(false);
        }
        if (hasOption2)
        {
            optionButton2.SetActive(true);
            optionButton2.transform.Find("Text").GetComponent<Text>().text = option2;

            if (affectsQuest2)
            {
                optionButton2.GetComponent<DialogueOption>().affectsQuest = true;
                optionButton2.GetComponent<DialogueOption>().interactName = name;
                optionButton2.GetComponent<DialogueOption>().questId = questId2;
            }

            if (changesItem2)
            {
                optionButton2.GetComponent<DialogueOption>().changesItem = true;
                optionButton2.GetComponent<DialogueOption>().itemId = itemId2;
                optionButton2.GetComponent<DialogueOption>().quantity = quantity2;
            }
        }
        else
        {
            optionButton2.SetActive(false);
        }
        if (hasOption3)
        {
            optionButton3.SetActive(true);
            optionButton3.transform.Find("Text").GetComponent<Text>().text = option3;

            if (affectsQuest3)
            {
                optionButton3.GetComponent<DialogueOption>().affectsQuest = true;
                optionButton3.GetComponent<DialogueOption>().interactName = name;
                optionButton3.GetComponent<DialogueOption>().questId = questId3;
            }

            if (changesItem3)
            {
                optionButton3.GetComponent<DialogueOption>().changesItem = true;
                optionButton3.GetComponent<DialogueOption>().itemId = itemId3;
                optionButton3.GetComponent<DialogueOption>().quantity = quantity3;
            }
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
