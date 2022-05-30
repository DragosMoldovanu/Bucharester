using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetailsController : MonoBehaviour
{
    public Text title;
    public GameObject completeText;
    public Text description;

    public void SetData(bool _completed, string _title, string _description)
    {
        completeText.SetActive(_completed);
        title.text = _title;
        description.text = _description;
    }
}
