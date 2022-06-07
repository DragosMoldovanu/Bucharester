using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float seconds;
    public bool selfDestruct;
    // Start is called before the first frame update
    void Start()
    {
        if (selfDestruct)
        {
            Destroy(gameObject, seconds);
        }
    }

    public void SelfDestruct()
    {
        Destroy(gameObject, seconds);
    }

    public void RemoveActiveQuest()
    {
        GameObject.Find("QuestList").GetComponent<QuestManager>().RemoveFromActiveQuests(GetComponent<QuestController>().id);
    }
}
