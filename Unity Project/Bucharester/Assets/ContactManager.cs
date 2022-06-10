using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactManager : MonoBehaviour
{
    public GameObject contactsContainer;
    public GameObject contactPrefab;

    void OnEnable()
    {
        foreach (Transform contact in contactsContainer.transform)
        {
            Destroy(contact.gameObject);
        }

        ItemManager dialogueData = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        foreach (string contact in Database.contactsDatabase.Keys)
        {
            GameObject contactObject = Instantiate(contactPrefab, contactsContainer.transform);
            contactObject.GetComponent<ContactController>().SetData(contact, contact);

            OpenDialogue dialogue = contactObject.GetComponent<OpenDialogue>();
            dialogue.startDialogue = Database.contactsDatabase[contact];
            dialogue.dialogueId = Database.contactsDatabase[contact];

            dialogue.NPC = dialogueData.sprite;
            dialogue.player = dialogueData.player;
            dialogue.box = dialogueData.dialogueBox;
            dialogue.title = dialogueData.title;
            dialogue.description = dialogueData.description;
            dialogue.optionButton1 = dialogueData.option1;
            dialogue.optionButton2 = dialogueData.option2;
            dialogue.optionButton3 = dialogueData.option3;
        }
    }
}
