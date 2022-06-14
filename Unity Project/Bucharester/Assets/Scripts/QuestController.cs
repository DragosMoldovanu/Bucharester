using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public Text questTitle;
    public Text questObjectives;

    public int id;
    public AudioClip completeSound;

    public void SetQuestData(int _id, string title, int objCount, string[] objectives)
    {
        id = _id;
        questTitle.text = title;

        questObjectives.text = "";
        for (int i = 0; i < objCount; i++)
        {
            questObjectives.text += "- " + objectives[i] + "\n";
        }
    }

    public void CompleteSound()
    {
        GetComponent<AudioSource>().clip = completeSound;
        GetComponent<AudioSource>().Play();
    }
}
