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
        public string description;
    }

    public class ItemObjective : QuestObjective
    {
        public int itemId;
        public int count;

        public ItemObjective(int _itemId, int _count, string _description)
        {
            itemId = _itemId;
            count = _count;
            description = _description;
        }
    }

    public class InteractObjective: QuestObjective
    {
        public string name;
        public int index;
        public int option;

        public InteractObjective(string _name, int _index, int _option, string _description)
        {
            name = _name;
            index = _index;
            option = _option;
            description = _description;
        }
    }

    public class Quest
    {
        public string sourceName;
        public string name;
        public int objCount;
        public QuestObjective[] objectives;

        public Quest(string _source, string _name, int _count, QuestObjective[] _objectives)
        {
            sourceName = _source;
            name = _name;
            objCount = _count;
            objectives = _objectives;
        }
    }

    public class Questline
    {
        public int questCount;
        public int[] questIds;

        public Questline(int _count, int[] _ids)
        {
            questCount = _count;
            questIds = _ids;
        }
    }






    public static Dictionary<int, ItemData> itemDatabase = new Dictionary<int, ItemData>()
    {
        { 1, new ItemData("burger", "Burger", "Classic WcDonalds hamburger. Why do they always look better in the ads?", true) },
        { 2, new ItemData("soda", "Soda", "Postpone your hunger with a sugary drink!", true) }
    };

    public static Dictionary<int, Quest> questDatabase = new Dictionary<int, Quest>()
    {
        { 1, new Quest("Beggar", "Quest1", 1, new ItemObjective[] {new ItemObjective(1, 1, "Get a burger") }) },
        { 2, new Quest(null, "Quest2", 1, new InteractObjective[] {new InteractObjective("Beggar", 0, 1, "Give a burger to hobo")}) }
    };

    public static List<Questline> questlineDatabase = new List<Questline>()
    {
        new Questline(2, new int[] {1, 2})
    };
}
