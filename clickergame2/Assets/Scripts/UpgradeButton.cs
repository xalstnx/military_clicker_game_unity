using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
    
    public int goldPerSec;
    public int startGoldPerSec = 1;

    [HideInInspector]
    public bool isPurchased = false;
    public GameObject locker;

    public Color upgradableColor = Color.blue;
    public Color notupgradableColor = Color.red;
    public Image colorImage;
    public GameObject LvImage;

    public Text upgradeDisplayerPrice;
    public Text upgradeDisplayerLevel;
    public Text upgradeDisplayerNextLevel;
    public Text upgradeDisplayerUpgrade;
    public Text upgradeDisplayerNextUpgrade;

    public CanvasGroup canvasGroup;
    public Slider slider;

    public string upgradeName;

    [HideInInspector]
    public int currentCost = 1;
    public int startCurrentCost = 1;
    
    public int level;

    public float upgradePow = 1.07f; 
    public float costPow = 3.14f; //price

    public DataController dataController;

    private void Start()
    {
        DataController.Instance.LoadUpgradeButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
        LevelImgChanger();

        if (upgradeName.Equals("1"))
        {
            locker.SetActive(false);
        }
    }

    public void PurchaseUpgrade()
    {
        if (!locker.activeSelf)
        {
            if (DataController.Instance.gold >= currentCost)
            {
                DataController.Instance.gold -= currentCost;
                level++;
                DataController.Instance.statPoint++;
                isPurchased = true;

                if(DataController.Instance.highlevel < int.Parse(upgradeName))
                {
                    DataController.Instance.highlevel = int.Parse(upgradeName);
                }

                UpdateUpgrade();
                UpdateUI();
                DataController.Instance.SaveUpgradeButton(this);
            }
        }
    }

    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isPurchased)
            {
                DataController.Instance.gold += goldPerSec;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateUpgrade()
    {
        goldPerSec += startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        upgradeDisplayerPrice.text = "가격 : " + currentCost;
        upgradeDisplayerLevel.text = level + " 호봉";
        upgradeDisplayerNextLevel.text = (level+1) + " 호봉";
        upgradeDisplayerUpgrade.text = goldPerSec + "/초";
        upgradeDisplayerNextUpgrade.text = "+" + (startGoldPerSec * (int)Mathf.Pow(upgradePow, level + 1)) + "/초";

        slider.minValue = 0;
        slider.maxValue = currentCost;

        slider.value = DataController.Instance.gold;

        if(currentCost <= DataController.Instance.gold)
        {
            colorImage.color = upgradableColor;
        }
        else
        {
            colorImage.color = notupgradableColor;
        }
    }

    private void Update()
    {
        UpdateUI();
        if (!upgradeName.Equals("1"))
        {
            Unlocker();
        }
    }

    public void LevelImgChanger()
    {
        Sprite sprite = Resources.Load<Sprite>("levels/lv"+ upgradeName);
        LvImage.GetComponent<Image>().sprite = sprite;
        
    }

    public void Unlocker()
    {
        int BeforeLevelNum = int.Parse(upgradeName) - 1;
        UpgradeButton upgradeButton = GameObject.Find("Upgrade_Button" + BeforeLevelNum.ToString()).GetComponent<UpgradeButton>();

        if(upgradeButton.isPurchased && upgradeButton.level > 3)
        {
            locker.SetActive(false);
        }
    }
}