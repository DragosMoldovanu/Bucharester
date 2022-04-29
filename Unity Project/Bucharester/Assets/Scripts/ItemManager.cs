using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogueBox;
    public Text title;
    public Text description;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            OpenDialogue dialogue = transform.GetChild(i).GetComponent<OpenDialogue>();
            if (dialogue != null)
            {
                dialogue.player = player;
                dialogue.box = dialogueBox;
                dialogue.title = title;
                dialogue.description = description;
                dialogue.optionButton1 = option1;
                dialogue.optionButton2 = option2;
                dialogue.optionButton3 = option3;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
