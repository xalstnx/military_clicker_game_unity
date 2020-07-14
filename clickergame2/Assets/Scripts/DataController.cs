using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    private static DataController instance;

    public static DataController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataController>();

                if (instance == null)
                {
                    GameObject container = new GameObject("DataController");

                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }
    }

    private UpgradeButton[] upgradeButtons;

    public long gold
    {
        get
        {
            if (!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }
            string tmpGold = PlayerPrefs.GetString("Gold");
            return long.Parse(tmpGold);
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }
    public int goldPerClick
    {
        get
        {
            return PlayerPrefs.GetInt("GoldPerClick", 1);
        }
        set
        {
            PlayerPrefs.SetInt("GoldPerClick", value);
        }
    }
    public int highlevel
    {
        get
        {
            return PlayerPrefs.GetInt("HighLevel", 1);
        }
        set
        {
            PlayerPrefs.SetInt("HighLevel", value);
        }
    }

    public int highitem
    {
        get
        {
            return PlayerPrefs.GetInt("HighItem", 0);
        }
        set
        {
            PlayerPrefs.SetInt("HighItem", value);
        }
    }

    public int statPoint
    {
        get
        {
            return PlayerPrefs.GetInt("statPoint", 0);
        }
        set
        {
            PlayerPrefs.SetInt("statPoint", value);
        }
    }

    public void LoadStat_str(Stat_str stat_str)
    {
        string key = stat_str.statName;
        stat_str.point = PlayerPrefs.GetInt(key + "_point", stat_str.point);
        stat_str.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", stat_str.startGoldByUpgrade);
    }

    public void SaveStat_str(Stat_str stat_str)
    {
        string key = stat_str.statName;

        PlayerPrefs.SetInt(key + "_point", stat_str.point);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", stat_str.goldByUpgrade);
    }

    public void LoadStat_hp(Stat_hp stat_hp)
    {
        string key = stat_hp.statName;
        stat_hp.point = PlayerPrefs.GetInt(key + "_point", stat_hp.point);
        stat_hp.FatigueByUpgrade = PlayerPrefs.GetInt(key + "_FatigueByUpgrade", stat_hp.startFatigueByUpgrade);
    }

    public void SaveStat_hp(Stat_hp stat_hp)
    {
        string key = stat_hp.statName;

        PlayerPrefs.SetInt(key + "_point", stat_hp.point);
        PlayerPrefs.SetInt(key + "_FatigueByUpgrade", stat_hp.FatigueByUpgrade);
    }

    public int LoadItem(int key)
    {
        return PlayerPrefs.GetInt("item_" + key, 0);
    }

    public void SaveItem(int key, int num)
    {
        PlayerPrefs.SetInt("item_" + key, num);
    }
    /*
    public void LoadStatPoint(StatSystem statSystem)
    {
        string key = statSystem.statName;

        statSystem.point = PlayerPrefs.GetInt(key + "_stat");
    }

    public void SaveStatPoint(StatSystem statSystem)
    {
        string key = statSystem.statName;

        PlayerPrefs.SetInt(key + "_stat", statSystem.point);
    }*/

    private void Awake()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();  
    }

    

    public void LoadItemButton(ItemButton itemButton)
    {
        /*
        string key = itemButton.itemName;

        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", itemButton.startGoldByUpgrade);
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);

        if (PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
        */
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        /*
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", itemButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);

        if (itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
        */
    }

    
    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.level = PlayerPrefs.GetInt(key + "_level");
        upgradeButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);

        if(PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            upgradeButton.isPurchased = true;
        }
        else
        {
            upgradeButton.isPurchased = false;
        }
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldPerSec", upgradeButton.goldPerSec);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);

        if(upgradeButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }
    
    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for(int i = 0; i < upgradeButtons.Length; i++)
        {
            goldPerSec += upgradeButtons[i].goldPerSec;
        }
        return goldPerSec;
    }

    public float WeatherTimer
    {
        get
        {
            return PlayerPrefs.GetFloat("WeatherTimer", 0.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("WeatherTimer", value);
        }
    }

    public int CurrentWeather
    {
        get
        {
            return PlayerPrefs.GetInt("CurrentWeather", 0);
        }
        set
        {
            PlayerPrefs.SetInt("CurrentWeather", value);
        }
    }

    public int Fatigue
    {
        get
        {
            return PlayerPrefs.GetInt("Fatigue", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Fatigue", value);
        }
    }

    public int plusFatigue
    {
        get
        {
            return PlayerPrefs.GetInt("plusFatigue", 0);
        }
        set
        {
            PlayerPrefs.SetInt("plusFatigue", value);
        }
    }
}
