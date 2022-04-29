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

    [Header("Option 2")]
    public GameObject optionButton2;
    public bool hasOption2;
    public string option2;
    public bool affectsQuest2;
    public int questId2;

    [Header("Option 3")]
    public GameObject optionButton3;
    public bool hasOption3;
    public string option3;
    public bool affectsQuest3;
    public int questId3;

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
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
