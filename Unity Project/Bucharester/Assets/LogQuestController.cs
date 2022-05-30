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

    public void SetData(bool _complete, string _title, string _description)
    {
        completeVeil.SetActive(_complete);
        title.text = _title;
        description.text = _description;
    }
}
