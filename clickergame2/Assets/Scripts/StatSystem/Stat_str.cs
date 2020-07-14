using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat_str : MonoBehaviour {
    
    public Text itemDisplayerName;
    public Text itemDisplayerUpgrade;
    public Text PointText;

    public int point;
    
    public string statName;
    

    [HideInInspector]
    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;
    
    public float upgradePow = 1.07f;
    

    private void Start()
    {
        DataController.Instance.LoadStat_str(this);
        UpdateUI();
    }

    public void OnClick()
    {
        if (DataController.Instance.statPoint > 0)
        {
            DataController.Instance.statPoint--;

            point++;
            DataController.Instance.goldPerClick += goldByUpgrade;

            UpdateItem();
            UpdateUI();
            DataController.Instance.SaveStat_str(this);
        }
    }

    public void UpdateItem()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, point);
    }

    public void UpdateUI()
    {
        itemDisplayerName.text = statName;
        itemDisplayerUpgrade.text = "+" + goldByUpgrade + "/클릭만큼 상승시킵니다.";
        PointText.text = point.ToString();
    }
}
