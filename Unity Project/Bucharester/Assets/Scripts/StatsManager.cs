using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public GameObject moneyIcon;

    public Text money;
    public Slider hunger;
    public float hungerPerSecond;
    public bool drainHunger;

    public int moneyAmount = 5;
    public float hungerPercent = 50;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        money.text = moneyAmount.ToString() + " RON";
        hunger.value = hungerPercent;
    }

    // Update is called once per frame
    void Update()
    {
        if (drainHunger)
        {
            UpdateHunger(-hungerPerSecond * Time.deltaTime);
        }

        if (hungerPercent < 20)
        {
            GameObject.Find("Tutorial Popups").GetComponent<TutorialManager>().HungerPopup();
        }
        else
        {
            GameObject.Find("Tutorial Popups").GetComponent<TutorialManager>().HungerFine();
        }

        if (hungerPercent <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void EnableMoney()
    {
        moneyIcon.SetActive(true);
    }

    public void UpdateMoney(int amount)
    {
        moneyAmount += amount;
        money.text = moneyAmount.ToString();
    }

    public void UpdateHunger(float amount)
    {
        hungerPercent += amount;
        if (hungerPercent < 0)
            hungerPercent = 0;
        if (hungerPercent > 100)
            hungerPercent = 100;

        hunger.value = hungerPercent;
    }
}
