using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public Text questTitle;
    public Text questObjectives;

    public void SetQuestData(string title, int objCount, string[] objectives)
    {
        questTitle.text = title;

        questObjectives.text = "";
        for (int i = 0; i < objCount; i++)
        {
            questObjectives.text += "- " + objectives[i] + "\n";
        }
    }
}
