using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public void DisableSelf()
    {
        GetComponent<Image>().enabled = false;
    }
}
