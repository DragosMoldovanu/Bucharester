using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDialogue : MonoBehaviour
{
    private static string lastObject = "";
    private static int lastId = 0;
    public GameObject player;

    [Header("Dialogue")]
    public Image NPC;
    public GameObject box;
    public Text title;
    public Text description;
    public int startDialogue;
    public int dialogueId;

    [Header("Option 1")]
    public GameObject optionButton1;

    [Header("Option 2")]
    public GameObject optionButton2;

    [Header("Option 3")]
    public GameObject optionButton3;

    // Update is called once per frame
    public void Open(bool startOver = true)
    {
        if (GameObject.Find("PhoneFade") != null && !Database.contactsDatabase.ContainsKey(name))
        {
            return;
        }
        if (box.activeSelf && name != lastObject)
        {
            return;
        }
        lastObject = name;

        Database.TreeNode node;
        if (startOver)
        {
            node = Database.treeDatabase[startDialogue];
        }
        else
        {
            node = Database.treeDatabase[dialogueId];
        }
        Database.Dialogue dialogue = node.current;

        if (box.activeSelf && name == lastObject && dialogue.id == startDialogue)
        {
            return;
        }

        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        box.SetActive(true);

        title.text = dialogue.name;
        description.text = dialogue.line;

        foreach (Database.DialogueEffect effect in dialogue.effects)
        {
            if (effect is Database.QuestEffect)
            {
                Database.QuestEffect quest = effect as Database.QuestEffect;
                if (quest.accept)
                {
                    GameObject.Find("QuestList").GetComponent<QuestManager>().AcceptQuest(quest.questId);
                }
                else if (quest.complete)
                {
                    GameObject.Find("QuestList").GetComponent<QuestManager>().CompleteQuest(quest.questId);
                }
            }
            else if (effect is Database.ItemEffect)
            {
                Database.ItemEffect item = effect as Database.ItemEffect;
                if (item.quantity > 0)
                {
                    GameObject.Find("Inventory").GetComponent<InventoryManager>().AddItem(item.itemId);
                }
                else if (item.quantity < 0)
                {
                    GameObject.Find("Inventory").GetComponent<InventoryManager>().RemoveItem(item.itemId);
                }
            }
            else if (effect is Database.MoneyEffect)
            {
                Database.MoneyEffect money = effect as Database.MoneyEffect;
                GameObject.Find("Stats").GetComponent<StatsManager>().UpdateMoney(money.quantity);
            }
            else if (effect is Database.ChangeEffect)
            {
                Database.ChangeEffect change = effect as Database.ChangeEffect;
                startDialogue = change.id;
            }
            else if (effect is Database.DestroyEffect)
            {
                Destroy(gameObject);
            }
            else if (effect is Database.EnableInventoryEffect)
            {
                GameObject.Find("Inventory").GetComponent<InventoryManager>().EnableInventory();
                Database.inventoryUnlocked = true;
            }
            else if (effect is Database.EnableMoneyEffect)
            {
                GameObject.Find("Stats").GetComponent<StatsManager>().EnableMoney();
                Database.moneyUnlocked = true;
            }
            else if (effect is Database.ChangeStartingDialogueEffect)
            {
                string obj = (effect as Database.ChangeStartingDialogueEffect).obj;
                int dlg = (effect as Database.ChangeStartingDialogueEffect).newDialogue;
                if (GameObject.Find(obj) != null)
                {
                    GameObject.Find(obj).GetComponent<OpenDialogue>().startDialogue = dlg;
                    GameObject.Find(obj).GetComponent<OpenDialogue>().dialogueId = dlg;
                }
            }
            else if (effect is Database.ChangePhoneEffect)
            {
                string obj = (effect as Database.ChangePhoneEffect).contact;
                int dlg = (effect as Database.ChangePhoneEffect).newDialogue;
                Database.contactsDatabase[obj] = dlg;
            }
            else if (effect is Database.QuestObjectEffect)
            {
                string obj = (effect as Database.QuestObjectEffect).obj;
                bool enable = (effect as Database.QuestObjectEffect).enable;
                if (enable && !Database.questObjects.Contains(obj) && !Database.questedObjects.Contains(obj))
                {
                    Database.questObjects.Add(obj);
                }
                else
                {
                    Database.questObjects.Remove(obj);
                    Database.questedObjects.Add(obj);
                }
            }
            else if (effect is Database.SoundEffect)
            {
                AudioClip sound = Resources.Load<AudioClip>("Audio/" + (effect as Database.SoundEffect).sound);
                Debug.Log(sound);
                box.GetComponent<AudioSource>().clip = sound;
                box.GetComponent<AudioSource>().Play();
            }
        }

        if (dialogue.sprite != null)
        {
            Sprite npcSprite = Resources.Load<Sprite>("Art/Sprites/Characters/" + dialogue.sprite);
            if (npcSprite != null)
            {
                NPC.enabled = true;
                NPC.sprite = npcSprite;
                if (dialogue.sprite == "mom")
                {
                    NPC.transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    NPC.transform.localEulerAngles = new Vector3(0, 180, 0);
                }
            }
            else
            {
                NPC.enabled = false;
                Debug.Log("NPC Sprite not found");
            }
        }
        else
        {
            NPC.enabled = false;
            NPC.sprite = null;
        }

        if (dialogue.option1 != null)
        {
            optionButton1.SetActive(true);
            optionButton1.transform.Find("Text").GetComponent<Text>().text = dialogue.option1;
            if (node.option1 > 0) 
            {
                optionButton1.GetComponent<DialogueOption>().affectsQuest = false;
                optionButton1.GetComponent<DialogueOption>().changesItem = false;
                optionButton1.GetComponent<DialogueOption>().changesMoney = false;
                foreach (Database.DialogueEffect effect in Database.dialogueDatabase[node.option1].effects)
                {
                    if (effect is Database.QuestEffect)
                    {
                        optionButton1.GetComponent<DialogueOption>().affectsQuest = true;
                        optionButton1.GetComponent<DialogueOption>().interactName = name;
                        optionButton1.GetComponent<DialogueOption>().questId = (effect as Database.QuestEffect).questId;
                    }

                    if (effect is Database.ItemEffect)
                    {
                        optionButton1.GetComponent<DialogueOption>().changesItem = true;
                        optionButton1.GetComponent<DialogueOption>().itemId = (effect as Database.ItemEffect).itemId;
                        optionButton1.GetComponent<DialogueOption>().itemQuantity = (effect as Database.ItemEffect).quantity;
                    }

                    if (effect is Database.MoneyEffect)
                    {
                        optionButton1.GetComponent<DialogueOption>().changesMoney = true;
                        optionButton1.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                    }
                }
                optionButton1.GetComponent<DialogueOption>().closesDialogue = false;
                optionButton1.GetComponent<DialogueOption>().continuesDialogue = true;
                optionButton1.GetComponent<DialogueOption>().continueId = node.option1;
                optionButton1.GetComponent<DialogueOption>().interactObject = gameObject;
            }
            else
            {
                optionButton1.GetComponent<DialogueOption>().closesDialogue = true;
                optionButton1.GetComponent<DialogueOption>().continuesDialogue = false;

                optionButton1.GetComponent<DialogueOption>().affectsQuest = false;
                optionButton1.GetComponent<DialogueOption>().changesItem = false;
                optionButton1.GetComponent<DialogueOption>().changesMoney = false;
            }
        }
        else
        {
            optionButton1.SetActive(false);
        }



        if (dialogue.option2 != null)
        {
            optionButton2.SetActive(true);
            optionButton2.transform.Find("Text").GetComponent<Text>().text = dialogue.option2;
            if (node.option2 > 0)
            {
                optionButton2.GetComponent<DialogueOption>().affectsQuest = false;
                optionButton2.GetComponent<DialogueOption>().changesItem = false;
                optionButton2.GetComponent<DialogueOption>().changesMoney = false;
                foreach (Database.DialogueEffect effect in Database.dialogueDatabase[node.option2].effects)
                {
                    if (effect is Database.QuestEffect)
                    {
                        optionButton2.GetComponent<DialogueOption>().affectsQuest = true;
                        optionButton2.GetComponent<DialogueOption>().interactName = name;
                        optionButton2.GetComponent<DialogueOption>().questId = (effect as Database.QuestEffect).questId;
                    }

                    if (effect is Database.ItemEffect)
                    {
                        optionButton2.GetComponent<DialogueOption>().changesItem = true;
                        optionButton2.GetComponent<DialogueOption>().itemId = (effect as Database.ItemEffect).itemId;
                        optionButton2.GetComponent<DialogueOption>().itemQuantity = (effect as Database.ItemEffect).quantity;
                    }

                    if (effect is Database.MoneyEffect)
                    {
                        optionButton2.GetComponent<DialogueOption>().changesMoney = true;
                        optionButton2.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                    }
                }
                optionButton2.GetComponent<DialogueOption>().closesDialogue = false;
                optionButton2.GetComponent<DialogueOption>().continuesDialogue = true;
                optionButton2.GetComponent<DialogueOption>().continueId = node.option2;
                optionButton2.GetComponent<DialogueOption>().interactObject = gameObject;
            }
            else
            {
                optionButton2.GetComponent<DialogueOption>().closesDialogue = true;
                optionButton2.GetComponent<DialogueOption>().continuesDialogue = false;

                optionButton2.GetComponent<DialogueOption>().affectsQuest = false;
                optionButton2.GetComponent<DialogueOption>().changesItem = false;
                optionButton2.GetComponent<DialogueOption>().changesMoney = false;
            }
        }
        else
        {
            optionButton2.SetActive(false);
        }



        if (dialogue.option3 != null)
        {
            optionButton3.SetActive(true);
            optionButton3.transform.Find("Text").GetComponent<Text>().text = dialogue.option3;
            if (node.option3 > 0)
            {
                optionButton3.GetComponent<DialogueOption>().affectsQuest = false;
                optionButton3.GetComponent<DialogueOption>().changesItem = false;
                optionButton3.GetComponent<DialogueOption>().changesMoney = false;
                foreach (Database.DialogueEffect effect in Database.dialogueDatabase[node.option3].effects)
                {
                    if (effect is Database.QuestEffect)
                    {
                        optionButton3.GetComponent<DialogueOption>().affectsQuest = true;
                        optionButton3.GetComponent<DialogueOption>().interactName = name;
                        optionButton3.GetComponent<DialogueOption>().questId = (effect as Database.QuestEffect).questId;
                    }

                    if (effect is Database.ItemEffect)
                    {
                        optionButton3.GetComponent<DialogueOption>().changesItem = true;
                        optionButton3.GetComponent<DialogueOption>().itemId = (effect as Database.ItemEffect).itemId;
                        optionButton3.GetComponent<DialogueOption>().itemQuantity = (effect as Database.ItemEffect).quantity;
                    }

                    if (effect is Database.MoneyEffect)
                    {
                        optionButton3.GetComponent<DialogueOption>().changesMoney = true;
                        optionButton3.GetComponent<DialogueOption>().quantity = (effect as Database.MoneyEffect).quantity;
                    }
                }
                optionButton3.GetComponent<DialogueOption>().closesDialogue = false;
                optionButton3.GetComponent<DialogueOption>().continuesDialogue = true;
                optionButton3.GetComponent<DialogueOption>().continueId = node.option3;
                optionButton3.GetComponent<DialogueOption>().interactObject = gameObject;
            }
            else
            {
                optionButton3.GetComponent<DialogueOption>().closesDialogue = true;
                optionButton3.GetComponent<DialogueOption>().continuesDialogue = false;

                optionButton3.GetComponent<DialogueOption>().affectsQuest = false;
                optionButton3.GetComponent<DialogueOption>().changesItem = false;
                optionButton3.GetComponent<DialogueOption>().changesMoney = false;
            }
        }
        else
        {
            optionButton3.SetActive(false);
        }
    }
}
