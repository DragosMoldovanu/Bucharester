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

    public class DialogueEffect
    {

    }

    public class QuestEffect : DialogueEffect
    {
        public int questId;
        public bool accept;
        public bool complete;

        public QuestEffect(int questId, bool accept, bool complete)
        {
            this.questId = questId;
            this.accept = accept;
            this.complete = complete;
        }
    }

    public class ItemEffect : DialogueEffect
    {
        public int itemId;
        public int quantity;

        public ItemEffect(int itemId, int quantity)
        {
            this.itemId = itemId;
            this.quantity = quantity;
        }
    }

    public class MoneyEffect : DialogueEffect
    {
        public int quantity;

        public MoneyEffect(int quantity)
        {
            this.quantity = quantity;
        }
    }

    public class ChangeEffect : DialogueEffect
    {
        public int id;

        public ChangeEffect(int id)
        {
            this.id = id;
        }
    }

    public class DestroyEffect : DialogueEffect
    {

    }

    public class Dialogue
    {
        public int id;
        public List<DialogueEffect> effects;
        public string name;
        public string line;
        public string option1;
        public string option2;
        public string option3;

        public Dialogue(int id, List<DialogueEffect> effects, string name, string line, string option1, string option2, string option3)
        {
            this.id = id;
            this.effects = effects;
            this.name = name;
            this.line = line;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
        }
    }

    public class TreeNode
    {
        public Dialogue current;
        public int option1;
        public int option2;
        public int option3;

        public TreeNode(Dialogue current, int option1, int option2, int option3)
        {
            this.current = current;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
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
        public string description;
        public int objCount;
        public QuestObjective[] objectives;

        public Quest(string _source, string _name, string _description, int _count, QuestObjective[] _objectives)
        {
            sourceName = _source;
            name = _name;
            description = _description;
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
        { 1, new ItemData("burger", "Burger", "This tiny burger can also travel through thick walls.", true) },
        { 2, new ItemData("burger", "Soda", "This was definitely not made in China.", true) },
        { 3, new ItemData("soda", "Soda", "Refreshing sugary beverage, timed bomb, who knows what else.", true) },
        { 4, new ItemData("burger", "Cold Sandwitch", "May not be tasty, but at lesat it does its job, who needs laxatives anymore?", true) },
        { 5, new ItemData("burger", "Chocolate Bar", "Once a slice of heaven, now a reminder of hell.", true) },

        { 6, new ItemData("soda", "Files", "A tree named Greet might have been hurt in the process", false) }
    };

    public static Dictionary<int, Quest> questDatabase = new Dictionary<int, Quest>()
    {
        { 1, new Quest(null, "Welcome to Bucharest", "Welcome to Bucharest!", 1, new QuestObjective[] {new InteractObjective("mom", 0, 1, "Answer mom's text")}) },
        { 2, new Quest(null, "What Remains", "Pick up what remains of your baggages", 1, new QuestObjective[] {new ItemObjective(6, 3, "Pick up remaining baggages")}) },
        { 3, new Quest(null, "Ride Home", "Find a ride to leave the train station", 1, new QuestObjective[] {new InteractObjective("Taxi Guy", 0, 1, "Find a taxi")}) },
        { 100, new Quest("Beggar", "Quest1", "The hobo wants something to eat. A burger should do nicely.", 1, new QuestObjective[] {new ItemObjective(1, 1, "Get a burger")}) },
        { 200, new Quest(null, "Quest2", "You got the burger. All you need to do now is bring it to the hobo.", 1, new QuestObjective[] {new InteractObjective("Beggar", 0, 1, "Give a burger to hobo")}) },
    };

    public static Dictionary<int, Dialogue> dialogueDatabase = new Dictionary<int, Dialogue>()
    {
        { 1, new Dialogue(1, new List<DialogueEffect>() { new QuestEffect(1, true, false) }, "Hobo", "Hey, you got anything to eat?", "Sure", null, "Sorry, I don't" ) },
        { 2, new Dialogue(2, new List<DialogueEffect>() { new QuestEffect(2, false, true), new ItemEffect(1, -1), new ChangeEffect(5) }, "Hobo", "Thanks mate", null, "No Problem", null) },
        { 3, new Dialogue(3, new List<DialogueEffect>(), "Trash", "There is a WcDonalds hamburger thrown in the trash. Take it?", "Yes", null, "No") },
        { 4, new Dialogue(4, new List<DialogueEffect>() { new QuestEffect(1,false, true), new ItemEffect(1, 1), new DestroyEffect() }, "Trash", "You got a WcDonalds hamburger!", null, "Great!", null) },

        { 5, new Dialogue(5, new List<DialogueEffect>(), "Hobo", "I owe you one!", null, "Sure thing", null) }
    };

    public static Dictionary<int, TreeNode> treeDatabase = new Dictionary<int, TreeNode>()
    {
        { 1, new TreeNode( dialogueDatabase[1], 2, -1, -1) },
        { 2, new TreeNode( dialogueDatabase[2], -1, -1, -1) },
        { 3, new TreeNode( dialogueDatabase[3], 4, -1, -1) },
        { 4, new TreeNode( dialogueDatabase[4], -1, -1, -1) },

        { 5, new TreeNode( dialogueDatabase[5], -1, -1, -1) }
    };

    public static List<Questline> questlineDatabase = new List<Questline>()
    {
        new Questline(2, new int[] {1, 2})
    };
}
