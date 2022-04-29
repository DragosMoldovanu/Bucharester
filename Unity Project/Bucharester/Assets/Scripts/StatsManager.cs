using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Text money;
    public Slider hunger;
    public float hungerPerSecond;
    public bool drainHunger;

    private int moneyAmount = 100;
    private float hungerPercent = 100;

    // Start is called before the first frame update
    void Start()
    {
        money.text = moneyAmount.ToString();
        hunger.value = hungerPercent;
    }

    // Update is called once per frame
    void Update()
    {
        if (drainHunger)
        {
            UpdateHunger(-hungerPerSecond * Time.deltaTime);
        }
    }

    public void UpdateMoney(int amount)
    {
        moneyAmount += amount;
        money.text = moneyAmount.ToString();
    }

    public void UpdateHunger(float amount)
    {
        hungerPercent += amount;
        hunger.value = hungerPercent;
    }
}
