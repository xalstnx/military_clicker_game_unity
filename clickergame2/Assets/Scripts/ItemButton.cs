using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    public Text itemDisplayerPrice;
    public Text itemDisplayerLevel;
    public Text itemDisplayerNextLevel;
    public Text itemDisplayerUpgrade;
    public Text itemDisplayerName;

    public string itemName;

    public int level;

    [HideInInspector]
    public int currentCost;

    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    public float costPow = 3.14f;
    public float upgradePow = 1.07f;

    [HideInInspector]
    public bool isPurchased = false;

    private void Start()
    {
        DataController.Instance.LoadItemButton(this);
        UpdateUI();
    }

    public void PurchasedItem()
    {
        if(DataController.Instance.gold >= currentCost)
        {
            isPurchased = true;
            DataController.Instance.gold -= currentCost;
            level++;
            DataController.Instance.goldPerClick += goldByUpgrade;

            if (DataController.Instance.highitem < int.Parse(itemName))
            {
                DataController.Instance.highitem = int.Parse(itemName);
            }

            UpdateItem();
            UpdateUI();

            DataController.Instance.SaveItemButton(this);
        }
    }

    public void UpdateItem()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        //itemDisplayerName.text = itemName;
        itemDisplayerPrice.text = "가격 : " + currentCost;
        itemDisplayerLevel.text = "+" + level;
        //itemDisplayerNextLevel.text = (level + 1) + " 레벨";
        itemDisplayerUpgrade.text = "+" + goldByUpgrade + "/클릭";
    }
}
