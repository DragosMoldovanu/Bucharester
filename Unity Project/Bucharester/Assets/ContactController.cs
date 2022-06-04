using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactController : MonoBehaviour
{
    public Text contactName;

    public void SetData(string interactName, string contact)
    {
        name = interactName;
        contactName.text = contact;
    }
}
