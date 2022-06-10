using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuestMarker : MonoBehaviour
{
    private GameObject questMarker;

    // Start is called before the first frame update
    void Start()
    {
        questMarker = transform.Find("QuestMarker").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Database.questObjects.Contains(name))
        {
            questMarker.SetActive(true);
        }
        else
        {
            questMarker.SetActive(false);
        }
    }
}
