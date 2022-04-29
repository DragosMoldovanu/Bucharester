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

    [Header("Option 2")]
    public GameObject optionButton2;
    public bool hasOption2;
    public string option2;

    [Header("Option 3")]
    public GameObject optionButton3;
    public bool hasOption3;
    public string option3;

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
        }
        else
        {
            optionButton1.SetActive(false);
        }
        if (hasOption2)
        {
            optionButton2.SetActive(true);
            optionButton2.transform.Find("Text").GetComponent<Text>().text = option2;
        }
        else
        {
            optionButton2.SetActive(false);
        }
        if (hasOption3)
        {
            optionButton3.SetActive(true);
            optionButton3.transform.Find("Text").GetComponent<Text>().text = option3;
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
