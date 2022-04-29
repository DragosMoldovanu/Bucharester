using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnDataObject", order = 1)]
public class Database : ScriptableObject
{
    public class ItemData
    {
        public string sprite;
        public string name;
        public string description;
        public bool usable;

        public ItemData(string _sprite, string _name, string _description, bool _usable)
        {
            sprite = _sprite;
            name = _name;
            description = _description;
            usable = _usable;
        }
    }

    public class QuestObjective
    {
        
    }

    public class ItemObjective : QuestObjective
    {
        public int itemId;
        public int count;

        public ItemObjective(int _itemId, int _count)
        {
            itemId = _itemId;
            count = _count;
        }
    }

    public class InteractObjective: QuestObjective
    {
        public string name;
        public int index;
        public int option;

        public InteractObjective(string _name, int _index, int _option)
        {
            name = _name;
            index = _index;
            option = _option;
        }
    }

    public class Quest
    {
        public string sourceName;
        public string name;
        public QuestObjective[] objectives;

        public Quest(string _name, QuestObjective[] _objectives)
        {
            name = _name;
            objectives = _objectives;
        }
    }

    public class Questline
    {
        public int[] questIds;

        public Questline(int[] _ids)
        {
            questIds = _ids;
        }
    }






    public Dictionary<int, ItemData> itemDatabase = new()
    {
        { 1, new ItemData("hamburger", "Hamburger", "Classic WcDonalds hamburger", false) },
        { 2, new ItemData("item2", "item2", "desc2", false) },
        { 3, new ItemData("item3", "item3", "desc3", false) }
    };
}
