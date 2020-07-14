using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSecDisplayer;

    public Image Lvimage;

    public Slider FatigueSlider;
    public Image colorImage;
    public int MaxFatigue = 100;
    public Color goodColor = Color.blue;
    public Color badColor = Color.red;

    private void Update()
    {
        goldDisplayer.text = "짬  " + DataController.Instance.gold;
        goldPerClickDisplayer.text = DataController.Instance.goldPerClick + "/클릭";
        goldPerSecDisplayer.text = DataController.Instance.GetGoldPerSec() + "/초";
        Lvimage.sprite = Resources.Load<Sprite>("levels/lv" + DataController.Instance.highlevel.ToString());

        FatigueSlider.minValue = 0;
        FatigueSlider.maxValue = MaxFatigue + DataController.Instance.plusFatigue;

        FatigueSlider.value = DataController.Instance.Fatigue;

        if (DataController.Instance.Fatigue <= MaxFatigue * 0.8)
        {
            colorImage.color = goodColor;
        }
        else
        {
            colorImage.color = badColor;
        }
    }
}
