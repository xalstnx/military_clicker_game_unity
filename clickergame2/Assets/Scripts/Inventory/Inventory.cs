using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase databasesc;
    public GameObject inventorySlot;
    public GameObject inventoryItemPanel;
    public GameObject inventoryItemDescription;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        databasesc = GetComponent<ItemDatabase>();

        slotAmount = 3;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].transform.localScale = new Vector3(1, 1, 1);
        }
        StartingItemGenerator();
        /*
        AddItem(101);
        AddItem(201);
        AddItem(301);
        AddItem(101);
        AddItem(101);
        AddItem(201);
        AddItem(201);
        AddItem(301);
        AddItem(201);
        */
    }

    public void AddItem(int id)
    {
        Item itemToAdd = databasesc.FetchItemByID(id);
        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    DataController.Instance.SaveItem(id, data.amount);
                    data.transform.GetChild(0).GetComponent<Text>().text = "x" + data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObjPanel = Instantiate(inventoryItemPanel);
                    GameObject itemObj = itemObjPanel.transform.GetChild(0).gameObject;
                    //GameObject itemObj = Instantiate(inventoryItem);
                    itemObjPanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemRarity/item"+itemToAdd.Rarity);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObjPanel.transform.SetParent(slots[i].transform);
                    //itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObjPanel.transform.position = Vector2.zero;
                    ItemData data = slots[i].transform.GetChild(0).GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    DataController.Instance.SaveItem(id, data.amount);
                    break;
                }
            }
        }
    }

    public void AddItemToStart(int id)
    {
        Item itemToAdd = databasesc.FetchItemByID(id);
        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    //DataController.Instance.SaveItem(id, data.amount);
                    data.transform.GetChild(0).GetComponent<Text>().text = "x" + data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObjPanel = Instantiate(inventoryItemPanel);
                    GameObject itemObj = itemObjPanel.transform.GetChild(0).gameObject;
                    //GameObject itemObj = Instantiate(inventoryItem);
                    itemObjPanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemRarity/item" + itemToAdd.Rarity);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObjPanel.transform.SetParent(slots[i].transform);
                    itemObjPanel.transform.localScale = new Vector3(1, 1, 1);
                    //itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObjPanel.transform.localPosition = new Vector2(-230, 0);
                    //itemObj.transform.localPosition = Vector2.zero;
                    ItemData data = slots[i].transform.GetChild(0).GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    //DataController.Instance.SaveItem(id, data.amount);
                    break;
                }
            }
        }

    }

    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    }

    public void StartingItemGenerator()
    {
        for (int i = 0; i < databasesc.database.Count; i++)
        {
            if (DataController.Instance.LoadItem(databasesc.database[i].ID) > 0)
            {
                Debug.Log(DataController.Instance.LoadItem(databasesc.database[i].ID));
                for (int j = 0; j < DataController.Instance.LoadItem(databasesc.database[i].ID); j++)
                {
                    Debug.Log("111");
                    AddItemToStart(databasesc.database[i].ID);
                }
            }
        }
    }
}