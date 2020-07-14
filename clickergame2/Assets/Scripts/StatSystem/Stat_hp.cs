using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat_hp : MonoBehaviour {

    public Text itemDisplayerName;
    public Text itemDisplayerUpgrade;
    public Text PointText;

    public int point;

    public string statName;


    [HideInInspector]
    public int FatigueByUpgrade;
    public int startFatigueByUpgrade = 0;
    public int plusFatigueByUpgrade = 20;
    


    private void Start()
    {
        DataController.Instance.LoadStat_hp(this);
        UpdateUI();
    }

    public void OnClick()
    {
        if (DataController.Instance.statPoint > 0)
        {
            DataController.Instance.statPoint--;

            point++;
            DataController.Instance.plusFatigue += plusFatigueByUpgrade;
            
            UpdateUI();
            DataController.Instance.SaveStat_hp(this);
        }
    }
    

    public void UpdateUI()
    {
        itemDisplayerName.text = statName;
        itemDisplayerUpgrade.text = "+" + plusFatigueByUpgrade + "만큼 상승시킵니다.";
        PointText.text = point.ToString();
    }
}
