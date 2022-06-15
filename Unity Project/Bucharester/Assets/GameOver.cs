using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioListener listener;

    // Start is called before the first frame update
    void Start()
    {
        listener.enabled = false;
    }
}
