using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject phonePanel;
    public GameObject inventoryTab;
    public GameObject moneyStat;
    public float questPopupDelay;
    public float movementPopupDelay;

    [Header("Popups")]
    public GameObject quests;
    public GameObject inventory;
    public GameObject item;
    public GameObject money;
    public GameObject hunger;
    public GameObject eating;
    public GameObject phone;
    public GameObject cam;
    public GameObject movement;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (quests != null && !quests.activeSelf && time >= questPopupDelay)
        {
            quests.SetActive(true);
        }
        else if (movement != null && !movement.activeSelf && time >= movementPopupDelay)
        {
            movement.SetActive(true);
        }
        else
        {
            time += Time.deltaTime;
        }
        
        if (!phonePanel.activeSelf && phone != null && phone.activeSelf)
        {
            Destroy(phone);
        }
        if (!inventoryTab.activeSelf && inventory != null && inventory.activeSelf)
        {
            Destroy(inventory);
        }
        if (movement != null && movement.activeSelf && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            movement.GetComponent<Animator>().SetTrigger("fadeout");
            cam.SetActive(true);
        }
        if (cam != null && movement == null && (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E)))
        {
            cam.GetComponent<Animator>().SetTrigger("fadeout");
        }



        if (phonePanel.activeSelf)
        {
            PhonePopup();
        }
        if (inventoryTab.activeSelf)
        {
            InventoryPopup();
        }
        if (moneyStat.activeSelf)
        {
            MoneyPopup();
        }
    }

    public void HungerFine()
    {
        if (hunger != null && hunger.activeSelf)
        {
            Destroy(hunger);
        }
    }

    public void ItemClicked()
    {
        if (item != null && item.activeSelf)
        {
            Destroy(item);
        }
    }

    public void InventoryPopup()
    {
        if (inventory == null)
            return;

        inventory.SetActive(true);

        if (quests != null)
        {
            Destroy(quests);
        }
        if (item != null && item.activeSelf)
        {
            Destroy(item);
        }
    }

    public void ItemPopup()
    {
        if (item == null)
            return;

        item.SetActive(true);

        if (quests != null)
        {
            Destroy(quests);
        }
        if (inventory != null && inventory.activeSelf)
        {
            Destroy(inventory);
        }
    }

    public void MoneyPopup()
    {
        if (money == null)
            return;

        money.SetActive(true);

        if (hunger != null && hunger.activeSelf)
        {
            Destroy(hunger);
        }
    }

    public void HungerPopup()
    {
        if (hunger == null)
            return;

        hunger.SetActive(true);

        if (eating != null && eating.activeSelf)
        {
            Destroy(eating);
        }
        if (money != null && money.activeSelf)
        {
            Destroy(money);
        }
    }

    public void EatingPopup()
    {
        if (eating == null)
            return;

        eating.SetActive(true);

        if (hunger != null && hunger.activeSelf)
        {
            Destroy(hunger);
        }
        if (money != null && money.activeSelf)
        {
            Destroy(money);
        }
    }

    public void PhonePopup()
    {
        if (phone == null)
            return;

        phone.SetActive(true);

        if (quests != null)
        {
            Destroy(quests);
        }
    }
}
