using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogQuestController : MonoBehaviour
{
    public Image marker;
    public Text title;
    public Text description;
    public GameObject completeVeil;
    public Sprite incompleteSprite;
    public Sprite completeSprite;

    public GameObject questDetails;
    private int id;

    public void SetData(int _id, bool _complete, string _title, string _description)
    {
        id = _id;
        completeVeil.SetActive(_complete);
        title.text = _title;
        description.text = _description;

        if (_complete)
        {
            marker.sprite = completeSprite;
        }
        else
        {
            marker.sprite = incompleteSprite;
        }
    }

    public void OpenDetails()
    {
        questDetails.SetActive(true);

        string desc = Database.questDatabase[id].description + "\n\n";
        foreach (Database.QuestObjective obj in Database.questDatabase[id].objectives)
        {
            desc += "- " + obj.description + "\n";
        }

        questDetails.transform.GetChild(0).GetComponent<QuestDetailsController>().SetData(completeVeil.activeSelf, title.text, desc);
    }
}
