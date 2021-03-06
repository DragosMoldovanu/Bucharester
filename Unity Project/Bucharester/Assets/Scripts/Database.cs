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
        public float feedAmount;

        public ItemData(string _sprite, string _name, string _description, bool _usable, float _feedAmount = 0)
        {
            sprite = _sprite;
            name = _name;
            description = _description;
            usable = _usable;
            feedAmount = _feedAmount;
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

    public class ChangeStartingDialogueEffect : DialogueEffect
    {
        public string obj;
        public int newDialogue;

        public ChangeStartingDialogueEffect(string obj, int newDialogue)
        {
            this.obj = obj;
            this.newDialogue = newDialogue;
        }
    }

    public class QuestObjectEffect : DialogueEffect
    {
        public string obj;
        public bool enable;

        public QuestObjectEffect(string obj, bool enable)
        {
            this.obj = obj;
            this.enable = enable;
        }
    }

    public class SoundEffect : DialogueEffect
    {
        public string sound;

        public SoundEffect(string sound)
        {
            this.sound = sound;
        }
    }

    public class Dialogue
    {
        public int id;
        public List<DialogueEffect> effects;
        public string sprite;
        public string name;
        public string line;
        public string option1;
        public string option2;
        public string option3;

        public Dialogue(int id, string sprite, List<DialogueEffect> effects, string name, string line, string option1, string option2, string option3)
        {
            this.id = id;
            this.sprite = sprite;
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






    public static List<string> questObjects = new List<string>()
    {
        "Diana",
        "Manhole",
        "WeirdGuy"
    };

    public static List<string> questedObjects = new List<string>();

    public static Dictionary<int, ItemData> itemDatabase = new Dictionary<int, ItemData>()
    {
        { 1, new ItemData("burger", "Burger", "This tiny burger can also travel through thick walls.", true, 25) },
        { 2, new ItemData("chips", "Chips", "For when you want to destroy your liver and don't have access to tabacco or booze.", true, 20) },
        { 3, new ItemData("soda", "Soda", "Makes your heart skip a beat...or two. You should go see a doctor about that.", true, 10) },
        { 4, new ItemData("sandwitch", "Cold Sandwitch", "Probably cheaper than a box of laxatives and just as effective.", true, 40) },
        { 5, new ItemData("chocolate", "Chocolate Bar", "No chocolate in this chocolate bar, but it's sweet so who cares.", true, 20) },

        { 6, new ItemData("files", "Files", "Tree after tree cut down for these, and to what end...", false) },
        { 7, new ItemData("files2", "More Files", "...to what end?", false) },
        { 8, new ItemData("bag", "Sketchy Package", "What's this, lemme take a whiff of it...maybe another one. Why is my head spinning..?", false) },
        { 9, new ItemData("trash", "Trash Burger", "Whatever you do, DO NOT EAT. Well, at the same time, beggars can't be choosers.", false) }
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

        { 10, new Quest("Manhole", "Dumpster Dive", "The hobo wants something to eat. Time to look for something inexpensive. Maybe the trash...?", 1, new QuestObjective[] {new ItemObjective(9, 1, "Get some disposable food")}) },
        { 11, new Quest(null, "Bon Apetit!", "You got the... food...? All you need to do now is bring it to the hobo.", 1, new QuestObjective[] {new InteractObjective("Manhole", 0, 1, "Give trash burger to hobo")}) },

        { 12, new Quest("WeirdGuy", "Strange Request", "The weird guy wants some sort of package. Perhaps you can find one around?", 1, new QuestObjective[] {new ItemObjective(8, 1, "Find the strange package")}) },
        { 13, new Quest(null, "Is This Legal?", "You got the package. There's only one thing to do now...", 1, new QuestObjective[] {new InteractObjective("WeirdGuy", 0, 1, "Deliver the package")}) }
    };

    public static Dictionary<int, Dialogue> dialogueDatabase = new Dictionary<int, Dialogue>()
    {
        { 1, new Dialogue(1, "mom", new List<DialogueEffect>(), "Mom", "Hey, did you get there alright duckling?", "Yeah, I'm fine", null, "Well, depends what you mean by that...") },
        { 2, new Dialogue(2, "mom", new List<DialogueEffect>() { new QuestEffect(1, false, true), new ChangeEffect(4), new ChangePhoneEffect("Mom", 4), new ChangeStartingDialogueEffect("TaxiGuy", 9), new QuestObjectEffect("TaxiGuy", true) }, "Mom", "Glad to hear. We'll talk more later. Don't forget about the snack I packed you. Love you!", null, "Yeah, thanks.", null) },
        { 3, new Dialogue(3, "mom", new List<DialogueEffect>() { new QuestEffect(1, false, true), new ChangeEffect(4), new ChangePhoneEffect("Mom", 4), new ChangeStartingDialogueEffect("TaxiGuy", 9), new QuestObjectEffect("TaxiGuy", true) }, "Mom", "Aww, I'm sorry pumpkin. Well you better eat something. We'll talk more later. Love you!", null, "Yeah, thanks.", null) },
        { 4, new Dialogue(4, "mom", new List<DialogueEffect>(), "Mom", "I'm a bit busy dear. We'll talk later.", null, "Okay...", null) },

        { 5, new Dialogue(5, null, new List<DialogueEffect>(), "Backpack", "Your backpack lies on the ground. It's open and empty. All of its contents are gone.", "Take it", null, "Hold on") },
        { 6, new Dialogue(6, null, new List<DialogueEffect>() { new QuestEffect(2, false, true), new EnableInventoryEffect(), new DestroyEffect() }, "Backpack", "You got your backpack back, for what it's worth", null, "Great...", null) },

        { 7, new Dialogue(7, null, new List<DialogueEffect>(), "Wallet", "Your wallet lies randomly tossed on the ground. It's all dusty and dirty. Thankfully they missed your credit card.", "Take it", null, "Hold on") },
        { 8, new Dialogue(8, null, new List<DialogueEffect>() { new QuestEffect(3, false, true), new EnableMoneyEffect(), new DestroyEffect(), new ChangeStartingDialogueEffect("ATM", 22) }, "Wallet", "You got your wallet back. Not that there is much left in it", null, "Alright...", null) },

        { 9, new Dialogue(9, "taximetrist", new List<DialogueEffect>(), "Taxi Guy", "Hey kid, need a ride?", "I do actually", null, "Not right now") },
        { 10, new Dialogue(10, "taximetrist", new List<DialogueEffect>() { new ChangeEffect(10) }, "Taxi Guy", "Alright, where to?", "College dorms please", "Home", "Nevermind") },
        { 11, new Dialogue(11, "taximetrist", new List<DialogueEffect>(), "Taxi Guy", "Look kid, I don't know where your home is. Come back when you've made up your mind as to where you wanna go.", "Sorry, to the college dorms please.", null, "Alright, I'll be back") },
        { 12, new Dialogue(12, "taximetrist", new List<DialogueEffect>() { new ChangeEffect(12) }, "Taxi Guy", "Alright, a ride that far is gonna be 70 bucks.", "*Pay 70 RON for the taxi*", "Umm, I don't have that much", "Yes, I'll give you the money when we get there.") },
        { 13, new Dialogue(13, "taximetrist", new List<DialogueEffect>(), "Taxi Guy", "Kid, look at yourself for a second. You're a mess. You ain't got a dime on you.", null, "Okay, fine, I don't have it", null) },
        { 14, new Dialogue(14, "taximetrist", new List<DialogueEffect>() { new QuestEffect(5, true, false), new ChangeStartingDialogueEffect("TaxiGuy 2", 16), new QuestObjectEffect("TaxiGuy 2", true) }, "Taxi Guy", "Well unless you have the money, I ain't taking you anywhere.", null, "Okay, I'll be back.", null) },
        { 15, new Dialogue(15, "taximetrist", new List<DialogueEffect>() { new QuestEffect(4, false, true), new MoneyEffect(-70), new QuestObjectEffect("TaxiGuy", false) }, "Taxi Guy", "Good, now hop in already!", null, "*Hop in*", null) },

        { 16, new Dialogue(16, "taximetrist2", new List<DialogueEffect>(), "Taxi Guy", "Where to, kid?", "College dorms, please!", null, "Nevermind") },
        { 17, new Dialogue(17, "taximetrist2", new List<DialogueEffect>(), "Taxi Guy", "Sure thing. 70 bucks.", "What about 50?", null, "I don't have that much") },
        { 18, new Dialogue(18, "taximetrist2", new List<DialogueEffect>(), "Taxi Guy", "Well, can't help you then kid.", "Okay, what about 50?", null, "Goddammit") },
        { 19, new Dialogue(19, "taximetrist2", new List<DialogueEffect>() { new QuestEffect(6, true, false), new ChangeEffect(19), new ChangePhoneEffect("Mom", 20), new QuestObjectEffect("TaxiGuy 2", false) }, "Taxi Guy", "Look man, price is fixed. What, your parents don't give you any money?", null, "Hmm, okay then...", null) },

        { 20, new Dialogue(20, "mom", new List<DialogueEffect>(), "Mom", "Hey pumpkin, I'm a bit busy. What's up?", "Hey, could you send some money?", null, "Nevermind, let's talk later.") },
        { 21, new Dialogue(21, "mom", new List<DialogueEffect>() { new QuestEffect(6, false, true), new ChangeStartingDialogueEffect("ATM", 23), new ChangeEffect(4) }, "Mom", "More? Okay, I'll send you some. Try not to spend it so fast though!", null, "Okay, I will, thanks.", null) },

        { 22, new Dialogue(22, null, new List<DialogueEffect>() { new SoundEffect("Train Station Sounds/Train Station Interactables/ATM Open") }, "ATM", "The ATM declines your card. Your account must be empty.", null, "Well then...", null) },
        { 23, new Dialogue(23, null, new List<DialogueEffect>() { new SoundEffect("Train Station Sounds/Train Station Interactables/ATM Open") }, "ATM", "Here's the train station ATM. It's as filty as you would expect it to be.", "Get Money", null, "Leave") },
        { 24, new Dialogue(24, null, new List<DialogueEffect>() { new QuestEffect(7, false, true), new MoneyEffect(30), new ChangeEffect(22), new SoundEffect("Train Station Sounds/Train Station Interactables/ATM Extract") }, "ATM", "The ATM dispensed 30 bucks. Apparently that's all you have left on your card. You might wanna wipe your fingers.", null, "Yuck.", null) },

        { 25, new Dialogue(25, null, new List<DialogueEffect>(), "ATM", "There's a piece of paper taped on this. It says 'Out of Order'", null, "Nothing to do here", null) },
        { 26, new Dialogue(26, null, new List<DialogueEffect>() { new SoundEffect("Train Station Sounds/Train Station Interactables/ATM Open") }, "ATM", "You're missing your wallet. No credit card, no money.", null, "Ah, crap", null) },

        { 27, new Dialogue(27, null, new List<DialogueEffect>(), "Xerox", "A xerox. Guess you know where to come if you need to copy some papers...", null, "Good to know...", null) },
        { 28, new Dialogue(28, null, new List<DialogueEffect>(), "Xerox", "A xerox. Perfect place to copy those papers.", "Copy them", null, "Not yet") },
        { 29, new Dialogue(29, null, new List<DialogueEffect>() { new QuestEffect(8, false, true), new ItemEffect(6, -1), new ItemEffect(7, 1), new ChangeEffect(27), new SoundEffect("Train Station Sounds/Train Station Interactables/ATM Extract") }, "Xerox", "You now have even more papers. Hooray...?", null, "Guess so.", null) },

        { 30, new Dialogue(30, "diana", new List<DialogueEffect>(), "Diana", "Oh, hey, you look not busy, unlike me. I got these papers I need copying. Go do it for me.", "Why would I do that?", null, "*Back away slowly*") },
        { 31, new Dialogue(31, "diana", new List<DialogueEffect>(), "Diana", "I can pay you to do it. I don't care, just go do it.", "Alright, sounds good.", null, "Lemme think about it") },
        { 32, new Dialogue(32, "diana", new List<DialogueEffect>() { new QuestEffect(8, true, false), new ChangeStartingDialogueEffect("Xerox", 28), new ItemEffect(6, 1), new ChangeEffect(33) }, "Diana", "Good. Now get to it. Those are important. Don't smudge them or I kill you.", null, "Okay...?", null) },
        { 33, new Dialogue(33, "diana", new List<DialogueEffect>(), "Diana", "Have you got those papers?", "Yes", null, "Not yet") },
        { 34, new Dialogue(34, "diana", new List<DialogueEffect>(), "Diana", "Then what are you doing here? Go away and do it.", null, "Okay, okay", null) },
        { 35, new Dialogue(35, "diana", new List<DialogueEffect>() { new QuestEffect(9, false, true), new ItemEffect(7, -1), new ChangeEffect(36), new MoneyEffect(20), new QuestObjectEffect("Diana", false) }, "Diana", "Great. Here's 20 bucks for the effort. Now leave me alone please!", null, "Glad to help I guess", null) },
        { 36, new Dialogue(36, "diana", new List<DialogueEffect>(), "Diana", "I don't need you anymore. Go away.", null, "Damn, okay", null) },

        { 37, new Dialogue(37, "sewer", new List<DialogueEffect>(), "Sewer Hobo", "Hey, you. You got something I could eat? I can give you something in return.", "Is that something money?", null, "What the hell, no") },
        { 38, new Dialogue(38, "sewer", new List<DialogueEffect>(), "Sewer Hobo", "Well, something like that. So, you in?", "Yeah, I guess", null, "Yeah... No thanks") },
        { 39, new Dialogue(39, "sewer", new List<DialogueEffect>() { new ChangeEffect(39), new QuestEffect(10, true, false) }, "Sewer Hobo", "So, you got anything to eat then?", "Yeah... Here", null, "Not yet, sorry") },
        { 40, new Dialogue(40, "sewer", new List<DialogueEffect>() { new ChangeEffect(41), new QuestEffect(11, false, true), new ItemEffect(8, 1), new ItemEffect(9, -1), new QuestObjectEffect("Manhole", false) }, "Sewer Hobo", "Yeah, thanks man. Here, take this package. Just... becareful with it...", null, "Okay...", null) },
        { 41, new Dialogue(41, "sewer", new List<DialogueEffect>(), "Sewer Hobo", "Let a man enjoy his burger, will ya?", null, "Umm, okay?", null) },

        { 42, new Dialogue(42, null, new List<DialogueEffect>(), "Trashcan", "There's a lot of random trash in here, but there's also an old discarded burger. Maybe it could be useful?", "Take it", null, "No thanks") },
        { 43, new Dialogue(43, null, new List<DialogueEffect>() { new DestroyEffect(), new QuestEffect(10, false, true), new ItemEffect(9, 1), new SoundEffect("Train Station Sounds/Train Station Interactables/Garbage Rumage") }, "Trashcan", "You are now the proud holder of an old moldy trash burger!", null, "Great...?", null) },

        { 44, new Dialogue(44, "homeless1", new List<DialogueEffect>() { new QuestEffect(12, true, false) }, "Weird Guy", "Hey, you know, there are some packages I... lost... through the station. If you find one, mind bringing it to me?", "I got one here", null, "Okay, I guess") },
        { 45, new Dialogue(45, "homeless1", new List<DialogueEffect>() { new QuestEffect(13, false, true), new ChangeEffect(46), new ItemEffect(8, -1), new MoneyEffect(20), new QuestObjectEffect("WeirdGuy", false) }, "Weird Guy", "Thanks man. Here's a 20. Don't spend it all in one place! I'm serious. Don't.", null, "Right...", null) },
        { 46, new Dialogue(46, "homeless1", new List<DialogueEffect>(), "Weird Guy", "Go away. We shouldn't be seen together for a while.", null, "Oh boy...", null) },

        { 100, new Dialogue(100, "taximetrist", new List<DialogueEffect>(), "Taxi Guy", "You trying to go somewhere, kid?", null, "Not right now", null) },
        { 101, new Dialogue(101, "taximetrist", new List<DialogueEffect>(), "Taxi Guy", "Then go away and stop wasting my time.", null, "Jeez, okay...", null) },

        { 102, new Dialogue(102, "taximetrist2", new List<DialogueEffect>(), "Taxi Guy", "You trying to go somewhere, kid?", null, "Not right now", null) },
        { 103, new Dialogue(103, "taximetrist2", new List<DialogueEffect>(), "Taxi Guy", "Then go away and stop wasting my time.", null, "Jeez, okay...", null) },

        { 1000, new Dialogue(1000, null, new List<DialogueEffect>(), "WcDonalds", "Hello this is WcDonalnds, can I take your order?", "Burger (2 RON)", "Soda (1 RON)", "Not right now") },
        { 1001, new Dialogue(1001, null, new List<DialogueEffect>() { new MoneyEffect(-2), new ItemEffect(1, 1) }, "WcDonalds", "Alright, here's your burger. Have a good day!", null, "Thanks", null) },
        { 1002, new Dialogue(1002, null, new List<DialogueEffect>() { new MoneyEffect(-1), new ItemEffect(3, 1) }, "WcDonalds", "Alright, here's your drink. Have a good day!", null, "Thanks", null) },

        { 1003, new Dialogue(1003, null, new List<DialogueEffect>(), "Vending Machine", "From what you can see, you can either get a soda or some chips", "Chips (1 RON)", "Soda (1 RON)", "Nevermind") },
        { 1004, new Dialogue(1004, null, new List<DialogueEffect>() { new MoneyEffect(-1), new ItemEffect(2, 1) }, "Vending Machine", "You got a bag of chips.", null, "Good", null) },
        { 1005, new Dialogue(1005, null, new List<DialogueEffect>() { new MoneyEffect(-1), new ItemEffect(3, 1) }, "Vending Machine", "You got a soda can.", null, "Good", null) },

        { 1006, new Dialogue(1006, null, new List<DialogueEffect>(), "Vending Machine", "From what you can see, you can either get a sandwitch or some chocolate", "Sandwitch (3 RON)", "Chocolate (2 RON)", "Nevermind") },
        { 1007, new Dialogue(1007, null, new List<DialogueEffect>() { new MoneyEffect(-3), new ItemEffect(4, 1) }, "Vending Machine", "You got a wrapped, cold ham sandwitch", null, "Alright", null) },
        { 1008, new Dialogue(1008, null, new List<DialogueEffect>() { new MoneyEffect(-2), new ItemEffect(5, 1) }, "Vending Machine", "You got a bar of chocolate", null, "Alright", null) }
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
        { 15, new TreeNode(dialogueDatabase[15], -1, 0, -1) },

        { 16, new TreeNode(dialogueDatabase[16], 17, -1, -1) },
        { 17, new TreeNode(dialogueDatabase[17], 19, -1, 18) },
        { 18, new TreeNode(dialogueDatabase[18], 19, -1, -1) },
        { 19, new TreeNode(dialogueDatabase[19], -1, -1, -1) },

        { 20, new TreeNode(dialogueDatabase[20], 21, -1, -1) },
        { 21, new TreeNode(dialogueDatabase[21], -1, -1, -1) },

        { 22, new TreeNode(dialogueDatabase[22], -1, -1, -1) },
        { 23, new TreeNode(dialogueDatabase[23], 24, -1, -1) },
        { 24, new TreeNode(dialogueDatabase[24], -1, -1, -1) },

        { 25, new TreeNode(dialogueDatabase[25], -1, -1, -1) },
        { 26, new TreeNode(dialogueDatabase[26], -1, -1, -1) },

        { 27, new TreeNode(dialogueDatabase[27], -1, -1, -1) },
        { 28, new TreeNode(dialogueDatabase[28], 29, -1, -1) },
        { 29, new TreeNode(dialogueDatabase[29], -1, -1, -1) },

        { 30, new TreeNode(dialogueDatabase[30], 31, -1, -1) },
        { 31, new TreeNode(dialogueDatabase[31], 32, -1, -1) },
        { 32, new TreeNode(dialogueDatabase[32], -1, -1, -1) },
        { 33, new TreeNode(dialogueDatabase[33], 35, -1, 34) },
        { 34, new TreeNode(dialogueDatabase[34], -1, -1, -1) },
        { 35, new TreeNode(dialogueDatabase[35], -1, -1, -1) },
        { 36, new TreeNode(dialogueDatabase[36], -1, -1, -1) },

        { 37, new TreeNode(dialogueDatabase[37], 38, -1, -1) },
        { 38, new TreeNode(dialogueDatabase[38], 39, -1, -1) },
        { 39, new TreeNode(dialogueDatabase[39], 40, -1, -1) },
        { 40, new TreeNode(dialogueDatabase[40], -1, -1, -1) },

        { 42, new TreeNode(dialogueDatabase[42], 43, -1, -1) },
        { 43, new TreeNode(dialogueDatabase[43], -1, -1, -1) },

        { 44, new TreeNode(dialogueDatabase[44], 45, -1, -1) },
        { 45, new TreeNode(dialogueDatabase[45], -1, -1, -1) },
        { 46, new TreeNode(dialogueDatabase[46], -1, -1, -1) },

        { 100, new TreeNode(dialogueDatabase[100], -1, 101, -1) },
        { 101, new TreeNode(dialogueDatabase[101], -1, -1, -1) },

        { 102, new TreeNode(dialogueDatabase[102], -1, 103, -1) },
        { 103, new TreeNode(dialogueDatabase[103], -1, -1, -1) },

        { 1000, new TreeNode(dialogueDatabase[1000], 1001, 1002, -1) },
        { 1001, new TreeNode(dialogueDatabase[1001], -1, -1, -1) },
        { 1002, new TreeNode(dialogueDatabase[1002], -1, -1, -1) },

        { 1003, new TreeNode(dialogueDatabase[1003], 1004, 1005, -1) },
        { 1004, new TreeNode(dialogueDatabase[1004], -1, -1, -1) },
        { 1005, new TreeNode(dialogueDatabase[1005], -1, -1, -1) },

        { 1006, new TreeNode(dialogueDatabase[1006], 1007, 1008, -1) },
        { 1007, new TreeNode(dialogueDatabase[1007], -1, -1, -1) },
        { 1008, new TreeNode(dialogueDatabase[1008], -1, -1, -1) }
    };

    public static List<Questline> questlineDatabase = new List<Questline>()
    {
        new Questline(5, new int[] {1, 2, 3, 4, 5}),
        new Questline(2, new int[] {6, 7}),
        new Questline(2, new int[] {8, 9}),
        new Questline(2, new int[] {10, 11}),
        new Questline(2, new int[] {12, 13})
    };

    public static Dictionary<string, int> contactsDatabase = new Dictionary<string, int>()
    {
        { "Mom", 1 }
    };

    public static int startingQuest = 1;
}
