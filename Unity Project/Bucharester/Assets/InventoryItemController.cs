using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public GameObject popup;
    public Text itemName;
    public Text itemDescription;
    public Button useButton;

    private int id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItemData(int itemId, Sprite icon, string name, string description, bool usable)
    {
        id = itemId;
        GetComponent<Image>().sprite = icon;
        itemName.text = name;
        itemDescription.text = description;

        useButton.interactable = usable;
    }

    public void ClickItem()
    {
        popup.SetActive(!popup.activeSelf);
    }

    public void UseItem()
    {
        transform.parent.parent.parent.GetComponent<InventoryManager>().RemoveItem(id);
    }
}
