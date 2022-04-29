using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private class Item
    {
        public Sprite sprite;
        public string name;
        public string description;
        public bool usable;

        public Item(Sprite _sprite, string _name, string _description, bool _usable)
        {
            sprite = _sprite;
            name = _name;
            description = _description;
            usable = _usable;
        }
    }

    public GameObject inventoryGrid;
    public GameObject itemPrefab;
    public int inventorySize;

    private Item[] items;
    private int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        items = new Item[inventorySize];
        itemCount = 0;
        UpdateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        UpdateInventory();
    }

    public void AddItem(Sprite sprite, string name, string description, bool usable)
    {
        Item item = new Item(sprite, name, description, usable);
        items[itemCount] = item;
        itemCount++;
        UpdateInventory();
    }

    public void RemoveItem(int index)
    {
        for (int i = index; i < itemCount; i++)
        {
            items[i] = items[i + 1];
        }
        itemCount--;
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        foreach (Transform item in inventoryGrid.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Item item in items)
        {
            Instantiate(itemPrefab, inventoryGrid.transform);
        }
    }
}
