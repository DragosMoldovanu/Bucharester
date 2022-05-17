using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    public bool opensDialogue;

    public void Clicked()
    {
        if (opensDialogue)
        {
            GetComponent<OpenDialogue>().Open();
        }
    }
}
