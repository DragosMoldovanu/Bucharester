using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject questPrefab;
    public List<int> activeQuests;
    public List<int> completedQuests;
    public InventoryManager inventory;
    public StatsManager stats;
    public GameObject questLabel;

    // Start is called before the first frame update
    void Start()
    {
        activeQuests = new List<int>();
        completedQuests = new List<int>();

        AcceptQuest(Database.startingQuest);
    }

    // Update is called once per frame
    void Update()
    {
        int[] questsCopy = new int[activeQuests.Count];
        activeQuests.CopyTo(questsCopy);

        foreach (int id in questsCopy)
        {
            Database.Quest quest = Database.questDatabase[id];

            foreach (Database.QuestObjective obj in quest.objectives)
            {
                if (obj is Database.ItemObjective)
                {
                    int itemId = (obj as Database.ItemObjective).itemId;
                    if (inventory.ItemCount(itemId) >= (obj as Database.ItemObjective).count)
                    {
                        CompleteQuest(id);
                    }
                }
                else if (obj is Database.InventoryUnlockObjective)
                {
                    if (Database.inventoryUnlocked)
                    {
                        CompleteQuest(id);
                    }
                }
                else if (obj is Database.MoneyUnlockObjective)
                {
                    if (Database.moneyUnlocked)
                    {
                        CompleteQuest(id);
                    }
                }
                else if (obj is Database.MoneyObjective)
                {
                    int quantity = (obj as Database.MoneyObjective).quantity;
                    if (stats.moneyAmount >= quantity)
                    {
                        CompleteQuest(id);
                    }
                }
            }
        }

        if (activeQuests.Count == 0)
        {
            questLabel.SetActive(false);
        }
        else
        {
            questLabel.SetActive(true);
        }
    }

    public void AcceptQuest(int id)
    {
        if (!activeQuests.Contains(id) && !completedQuests.Contains(id))
        {
            AddActiveQuest(id);
            activeQuests.Add(id);
        }
    }

    public void CompleteQuest(int id)
    {
        if (activeQuests.Contains(id))
        {
            DeleteActiveQuest(id);
            if (!completedQuests.Contains(id))
            {
                completedQuests.Add(id);
            }
            NextQuest(id);
        }
    }

    private void AddActiveQuest(int id)
    {
        Database.Quest quest = Database.questDatabase[id];

        GameObject newQuest = Instantiate(questPrefab, transform);
        string[] objectives = new string[quest.objCount];
        for (int i = 0; i < quest.objCount; i++)
        {
            objectives[i] = quest.objectives[i].description;
        }
        newQuest.GetComponent<QuestController>().SetQuestData(id, quest.name, quest.objCount, objectives);
    }

    private void DeleteActiveQuest(int id)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i] == id)
            {
                //Destroy(transform.GetChild(i).gameObject);
                transform.GetChild(i).GetComponent<Animator>().SetTrigger("complete");
                break;
            }
        }
    }

    public void RemoveFromActiveQuests(int id)
    {
        activeQuests.Remove(id);
    }

    private void NextQuest(int id)
    {
        foreach (Database.Questline questline in Database.questlineDatabase)
        {
            for (int i = 0; i < questline.questCount - 1; i++)
            {
                if (questline.questIds[i] == id && Database.questDatabase[questline.questIds[i + 1]].sourceName == null)
                {
                    AcceptQuest(questline.questIds[i + 1]);
                }
            }
        }
    }
}
