using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    public bool opensDialogue;

    public bool affectsQuest;
    public int questId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        if (opensDialogue)
        {
            GetComponent<OpenDialogue>().Open();

            if (affectsQuest)
            {
                Database.Quest quest = Database.questDatabase[questId];

                if (quest.sourceName == gameObject.name)
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
}
