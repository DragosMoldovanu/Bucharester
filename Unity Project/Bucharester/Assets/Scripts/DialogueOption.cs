using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    private GameObject box;
    private GameObject player;
    public bool closesDialogue;

    public string interactName;
    public bool affectsQuest;
    public int questId;

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
    }
}
