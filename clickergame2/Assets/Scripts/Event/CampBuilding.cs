using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampBuilding : MonoBehaviour {
    public float Timer = 0.0f;
    public int countinuousTime = 5;
    public bool switchvalue = true;

    public GameObject sand;
    public GameObject character;

	void Update () {
		if(WeatherSystem.isEvent && (DataController.Instance.CurrentWeather == 0 || DataController.Instance.CurrentWeather == 2))
        {
            if(switchvalue)
            {
                DataController.Instance.Fatigue += 20;
                OnPlaying();
                switchvalue = false;
            }
            Timer += Time.deltaTime;
            if (Timer >= countinuousTime)
            {
                OffPlaying();
                WeatherSystem.isEvent = false;
                Timer = 0.0f;
                switchvalue = true;
            }
        }
	}
    
    void OnPlaying()
    {
        DataController.Instance.goldPerClick *= 2;
        sand.SetActive(true);
        character.GetComponent<Image>().sprite = Resources.Load<Sprite>("EventResources/shoveling");
        RectTransform rt = character.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(150, 191);
    }

    void OffPlaying()
    {
        DataController.Instance.goldPerClick /= 2;
        sand.SetActive(false);
        character.GetComponent<Image>().sprite = Resources.Load<Sprite>("Characters/char");
        RectTransform rt = character.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(98.7f, 191);
    }
}
