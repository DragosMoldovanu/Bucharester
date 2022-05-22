using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public class Item
    {
        public int id;
        public Sprite sprite;
        public string name;
        public string description;
        public bool usable;

        public Item(int _id, Sprite _sprite, string _name, string _description, bool _usable)
        {
            id = _id;
            sprite = _sprite;
            name = _name;
            description = _description;
            usable = _usable;
        }
    }

    public GameObject inventoryGrid;
    public GameObject itemPrefab;
    public int inventorySize;

    public List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        UpdateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //UpdateInventory();
    }

    public int ItemCount(int itemId)
    {
        int count = 0;
        foreach (Item item in items)
        {
            if (item.id == itemId)
            {
                count++;
            }
        }
        return count;
    }

    public void AddItem(int id)
    {
        if (items.Count >= inventorySize)
            return;

        Database.ItemData itemData = Database.itemDatabase[id];
        Sprite sprite = Resources.Load<Sprite>("Art/Sprites/Items/" + itemData.sprite);

        Item item = new Item(id, sprite, itemData.name, itemData.description, itemData.usable);
        items.Add(item);
        UpdateInventory();

        foreach (int questId in Database.questDatabase.Keys)
        {
            Database.Quest quest = Database.questDatabase[questId];

            foreach (Database.QuestObjective objective in quest.objectives)
            {
                if (objective is Database.ItemObjective && (objective as Database.ItemObjective).itemId == id)
                {
                    if (GameObject.Find("QuestList").GetComponent<QuestManager>().activeQuests.Contains(questId))
                        GameObject.Find("QuestList").GetComponent<QuestManager>().CompleteQuest(questId);
                }
            }
        }
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].id == id)
            {
                items.RemoveAt(i);
                break;
            }
        }
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        ClearInventory();
        foreach (Item item in items)
        {
            GameObject inventoryItem = Instantiate(itemPrefab, inventoryGrid.transform);
            inventoryItem.GetComponent<InventoryItemController>().SetItemData(item.id, item.sprite, item.name, item.description, item.usable);
        }
    }

    private void ClearInventory()
    {
        foreach (Transform item in inventoryGrid.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
