using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogQuestManager : MonoBehaviour
{
    public QuestManager questManager;
    public GameObject questContainer;
    public GameObject questPrefab;

    void OnEnable()
    {
        foreach (Transform child in questContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (int id in questManager.activeQuests)
        {
            GameObject quest = Instantiate(questPrefab, questContainer.transform);
            Database.Quest questData = Database.questDatabase[id];

            string description = "";
            foreach (Database.QuestObjective obj in questData.objectives)
            {
                description += "- " + obj.description + "\n";
            }
            quest.GetComponent<LogQuestController>().SetData(false, questData.name, description);
        }

        foreach (int id in questManager.completedQuests)
        {
            GameObject quest = Instantiate(questPrefab, questContainer.transform);
            Database.Quest questData = Database.questDatabase[id];

            string description = "";
            foreach (Database.QuestObjective obj in questData.objectives)
            {
                description += "- " + obj.description + "\n";
            }
            quest.GetComponent<LogQuestController>().SetData(true, questData.name, description);
        }
    }
}
