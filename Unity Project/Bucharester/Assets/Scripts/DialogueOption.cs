using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    private GameObject box;
    private GameObject player;
    public bool closesDialogue;

    void Start()
    {
        box = GameObject.Find("DialogueBox");
        player = GameObject.Find("Player");
    }

    public void Selected()
    {
        if (closesDialogue)
        {
            box.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
        }
    }
}
