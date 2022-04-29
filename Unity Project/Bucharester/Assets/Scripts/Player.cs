using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int maxHealth = 3;
    int healthCounter = 3;

    public bool scareEnemies = false;
    

    public Image[] hearts;

    private void Start()
    {
        UpdateHearts();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            scareEnemies = true;
        if (Input.GetKeyDown(KeyCode.L))
            scareEnemies = false;



    }

    public void TakeDMG(int amount)
    {
        if (healthCounter >= 1)
        {
            healthCounter -= amount;
            UpdateHearts();
            for (int i = healthCounter; i < healthCounter + amount; i++)
            {
                hearts[i].GetComponent<Animator>().SetTrigger("fade");
            }
        }
        else
            Debug.LogError("E mort baaa");
    }

    private void UpdateHearts()
    {
        if (healthCounter == maxHealth)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                hearts[i].enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < healthCounter; i++)
            {
                hearts[i].enabled = true;
            }
            for (int i = healthCounter; i < maxHealth; i++)
            {
                //hearts[i].enabled = false;
            }
        }

        if (healthCounter == 1)
        {
            hearts[0].GetComponent<Animator>().SetBool("flashing", true);
        }
        else
        {
            hearts[0].GetComponent<Animator>().SetBool("flashing", false);
        }
    }
}
