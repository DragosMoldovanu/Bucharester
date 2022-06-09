using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnDataObject", order = 1)]
public class Database : ScriptableObject
{
    public static bool inventoryUnlocked = false;
    public static bool moneyUnlocked = false;

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

    public class ChangePhoneEffect : DialogueEffect
    {
        public string contact;
        public int newDialogue;

        public ChangePhoneEffect(string contact, int newDialogue)
        {
            this.contact = contact;
            this.newDialogue = newDialogue;
        }
    }

    public class DestroyEffect : DialogueEffect
    {

    }

    public class EnableInventoryEffect: DialogueEffect
    {

    }

    public class EnableMoneyEffect: DialogueEffect
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

    public class InteractObjective : QuestObjective
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

    public class MoneyObjective : QuestObjective
    {
        public int quantity;

        public MoneyObjective(int quantity, string _description)
        {
            this.quantity = quantity;
            this.description = _description;
        }
    }

    public class InventoryUnlockObjective : QuestObjective
    {
        public InventoryUnlockObjective(string _description)
        {
            description = _description;
        }
    }

    public class MoneyUnlockObjective : QuestObjective
    {
        public MoneyUnlockObjective(string _description)
        {
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
        { 1, new Quest(null, "Welcome to Bucharest", "Welcome to Bucharest!", 1, new QuestObjective[] {new InteractObjective("Mom", 0, 1, "Answer mom's text")}) },
        { 2, new Quest(null, "What Remains", "Pick up your backpack", 1, new QuestObjective[] {new InventoryUnlockObjective("Pick up your backpack")}) },
        { 3, new Quest(null, "Five Dollar Man", "Pick up your wallet", 1, new QuestObjective[] {new MoneyUnlockObjective("Pick up your wallet")}) },
        { 4, new Quest(null, "Ride Home", "Find a ride to leave the train station", 1, new QuestObjective[] {new InteractObjective("Taxi Guy", 0, 1, "Find a taxi")}) },
        { 5, new Quest("Taxi Guy", "Pennyless", "Get enough money for the taxi ride", 1, new QuestObjective[] {new MoneyObjective(70, "Get 70 bucks for taxi")}) },

        { 6, new Quest("Taxi Guy 2", "Good Idea", "That weird guy is right, it might be a good idea to call and ask for money.", 1, new QuestObjective[] {new InteractObjective("Mom", 0, 1, "Ask your mom for money")}) },
        { 7, new Quest(null, "To The Bank!", "Go to the ATM and get the money sent to you", 1, new QuestObjective[] {new InteractObjective("ATM", 0, 1, "Get money from ATM")}) },

        { 8, new Quest("Diana", "More Papers!", "This girl needs some papers copied for.. some reason.", 1, new QuestObjective[] {new InteractObjective("Printer", 0, 1, "Find a printer to copy papers")}) },
        { 9, new Quest(null, "Papers, Please!", "Now that you got all the papers, all that is left to do is deliver them", 1, new QuestObjective[] {new InteractObjective("Diana", 0, 1, "Bring papers back")}) },

        { 10, new Quest("Beggar", "Quest1", "The hobo wants something to eat. A burger should do nicely.", 1, new QuestObjective[] {new ItemObjective(1, 1, "Get a burger")}) },
        { 11, new Quest(null, "Quest2", "You got the burger. All you need to do now is bring it to the hobo.", 1, new QuestObjective[] {new InteractObjective("Beggar", 0, 1, "Give a burger to hobo")}) },
    };

    public static Dictionary<int, Dialogue> dialogueDatabase = new Dictionary<int, Dialogue>()
    {
        { 1, new Dialogue(1, new List<DialogueEffect>(), "Mom", "Hey, did you get there alright duckling?", "Yeah, everything's fine", null, "Did not have the greatest start...") },
        { 2, new Dialogue(2, new List<DialogueEffect>() { new QuestEffect(1, false, true), new ChangeEffect(4) }, "Mom", "Glad to hear. We'll talk more later. Don't forget about the snack I packed you. Love you!", null, "Yeah, thanks. Love you.", null) },
        { 3, new Dialogue(3, new List<DialogueEffect>() { new QuestEffect(1, false, true), new ChangeEffect(4) }, "Mom", "Aww, I'm sorry pumpkin. We'll talk more later. Eat the snack I prepared for you and feel better. Love you!", null, "Yeah, thanks. Love you.", null) },
        { 4, new Dialogue(4, new List<DialogueEffect>(), "Mom", "I'm a bit busy dear. We'll talk later.", null, "Okay...", null) },

        { 5, new Dialogue(5, new List<DialogueEffect>(), "Backpack", "Your backpack lies on the ground. It's open and empty. All of its contents are gone.", "Take it", null, "Hold on") },
        { 6, new Dialogue(6, new List<DialogueEffect>() { new QuestEffect(2, false, true), new EnableInventoryEffect(), new DestroyEffect() }, "Backpack", "You got your backpack back, for what it's worth", null, "Great...", null) },

        { 7, new Dialogue(7, new List<DialogueEffect>(), "Wallet", "Your wallet lies randomly tossed on the ground. It's all dusty and dirty.", "Take it", null, "Hold on") },
        { 8, new Dialogue(8, new List<DialogueEffect>() { new QuestEffect(3, false, true), new EnableMoneyEffect(), new DestroyEffect() }, "Wallet", "You got your wallet back. Not that there is much left in it", null, "Alright...", null) },

        { 9, new Dialogue(9, new List<DialogueEffect>(), "Taxi Guy", "Hey kid, need a ride?", "I do actually", null, "Not right now") },
        { 10, new Dialogue(10, new List<DialogueEffect>() { new ChangeEffect(10) }, "Taxi Guy", "Alright, where to?", "College dorms please", "Home", "Nevermind") },
        { 11, new Dialogue(11, new List<DialogueEffect>(), "Taxi Guy", "Look kid, I don't know where your home is. Come back when you've made up your mind as to where you wanna go.", "Sorry, to the college dorms please.", null, "Alright, I'll be back") },
        { 12, new Dialogue(12, new List<DialogueEffect>() { new ChangeEffect(12) }, "Taxi Guy", "Alright, a ride that far is gonna be 70 bucks.", "*Pay 70 RON for the taxi*", "Umm, I don't have that much", "Yes, I'll give you the money when we get there.") },
        { 13, new Dialogue(13, new List<DialogueEffect>(), "Taxi Guy", "Kid, look at yourself for a second. You're a mess. You ain't got a dime on you.", null, "Okay, fine, I don't have it", null) },
        { 14, new Dialogue(14, new List<DialogueEffect>() { new QuestEffect(5, true, false) }, "Taxi Guy", "Well unless you have the money, I ain't taking you anywhere.", null, "Okay, I'll be back.", null) },
        { 15, new Dialogue(15, new List<DialogueEffect>() { new QuestEffect(4, false, true), new MoneyEffect(-70) }, "Taxi Guy", "Good, now hop in already!", null, "*Hop in*", null) },

        { 16, new Dialogue(16, new List<DialogueEffect>(), "Taxi Guy", "Where to, kid?", "College dorms, please!", null, "Nevermind") },
        { 17, new Dialogue(17, new List<DialogueEffect>(), "Taxi Guy", "Sure thing. 70 bucks.", "What about 50?", null, "I don't have that much") },
        { 18, new Dialogue(18, new List<DialogueEffect>(), "Taxi Guy", "Well, can't help you then kid.", "Okay, what about 50?", null, "Goddammit") },
        { 19, new Dialogue(19, new List<DialogueEffect>() { new QuestEffect(6, true, false), new ChangeEffect(19) }, "Taxi Guy", "Look man, price is fixed. What, your parents don't give you any money?", null, "Hmm, okay then...", null) },

        { 20, new Dialogue(20, new List<DialogueEffect>(), "Mom", "Hey pumpkin, I'm a bit busy. What's up?", "Hey, could you send some money?", null, "Nevermind, let's talk later.") },
        { 21, new Dialogue(21, new List<DialogueEffect>(), "Mom", "More? Okay, I'll send you some. Try not to spend it so fast though!", null, "Okay, I will, thanks.", null) }

        //{ 1, new Dialogue(1, new List<DialogueEffect>() { new QuestEffect(1, true, false) }, "Hobo", "Hey, you got anything to eat?", "Sure", null, "Sorry, I don't" ) },
        //{ 2, new Dialogue(2, new List<DialogueEffect>() { new QuestEffect(2, false, true), new ItemEffect(1, -1), new ChangeEffect(5) }, "Hobo", "Thanks mate", null, "No Problem", null) },
        //{ 3, new Dialogue(3, new List<DialogueEffect>(), "Trash", "There is a WcDonalds hamburger thrown in the trash. Take it?", "Yes", null, "No") },
        //{ 4, new Dialogue(4, new List<DialogueEffect>() { new QuestEffect(1,false, true), new ItemEffect(1, 1), new DestroyEffect() }, "Trash", "You got a WcDonalds hamburger!", null, "Great!", null) },

        //{ 5, new Dialogue(5, new List<DialogueEffect>(), "Hobo", "I owe you one!", null, "Sure thing", null) }
    };

    public static Dictionary<int, TreeNode> treeDatabase = new Dictionary<int, TreeNode>()
    {
        { 1, new TreeNode(dialogueDatabase[1], 2, -1, 3) },
        { 2, new TreeNode(dialogueDatabase[2], -1, -1, -1) },
        { 3, new TreeNode(dialogueDatabase[3], -1, -1, -1) },
        { 4, new TreeNode(dialogueDatabase[4], -1, -1, -1) },

        { 5, new TreeNode(dialogueDatabase[5], 6, -1, -1) },
        { 6, new TreeNode(dialogueDatabase[6], -1, -1, -1) },

        { 7, new TreeNode(dialogueDatabase[7], 8, -1, -1) },
        { 8, new TreeNode(dialogueDatabase[8], -1, -1, -1) },

        { 9, new TreeNode(dialogueDatabase[9], 10, -1, -1) },
        { 10, new TreeNode(dialogueDatabase[10], 12, 11, -1) },
        { 11, new TreeNode(dialogueDatabase[11], 12, -1, -1) },
        { 12, new TreeNode(dialogueDatabase[12], 15, 14, 13) },
        { 13, new TreeNode(dialogueDatabase[13], -1, 14, -1) },
        { 14, new TreeNode(dialogueDatabase[14], -1, -1, -1) },
        { 15, new TreeNode(dialogueDatabase[15], -1, -1, -1) },

        { 16, new TreeNode(dialogueDatabase[16], 17, -1, -1) },
        { 17, new TreeNode(dialogueDatabase[17], 19, -1, 18) },
        { 18, new TreeNode(dialogueDatabase[18], 19, -1, -1) },
        { 19, new TreeNode(dialogueDatabase[19], -1, -1, -1) },

        { 20, new TreeNode(dialogueDatabase[20], 21, -1, -1) },
        { 21, new TreeNode(dialogueDatabase[21], -1, -1, -1) }

        //{ 1, new TreeNode( dialogueDatabase[1], 2, -1, -1) },
        //{ 2, new TreeNode( dialogueDatabase[2], -1, -1, -1) },
        //{ 3, new TreeNode( dialogueDatabase[3], 4, -1, -1) },
        //{ 4, new TreeNode( dialogueDatabase[4], -1, -1, -1) },

        //{ 5, new TreeNode( dialogueDatabase[5], -1, -1, -1) }
    };

    public static List<Questline> questlineDatabase = new List<Questline>()
    {
        new Questline(5, new int[] {1, 2, 3, 4, 5}),
        new Questline(2, new int[] {6, 7})
    };

    public static Dictionary<string, int> contactsDatabase = new Dictionary<string, int>()
    {
        { "Mom", 1 }
    };

    public static int startingQuest = 1;
}
