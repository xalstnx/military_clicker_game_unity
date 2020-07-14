using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherSystem: MonoBehaviour {
    public int NumForNextWeather = 100;
    public int timerdivider;
    public GameObject Current_month;
    public GameObject Next_month;

    public Text Current_month_Text;
    public Text Next_month_Text;

    public GameObject Background;

    public Slider slider;

    float fades = 1.0f;

    public static bool iseffecting = false;

    public static bool isEvent = false;
    public int EventPercent = 15;
    public int Ev;

    private void Start()
    {
        timerdivider = NumForNextWeather / 3;
        BackgroundChanger();
        ImageChanger();
    }

    void Update () {
        if (!PauseSystem.isPausing)
        {
            BackgroundChanger();
            if (!iseffecting)
            {
                ImageChanger();
                NextmonthChanger();
            }
            DataController.Instance.WeatherTimer += Time.deltaTime;

            slider.minValue = 0;
            slider.maxValue = NumForNextWeather;
            slider.value = DataController.Instance.WeatherTimer;

            if ((DataController.Instance.WeatherTimer >= timerdivider && DataController.Instance.WeatherTimer <= (timerdivider + 1)) || (DataController.Instance.WeatherTimer >= (timerdivider * 2) && DataController.Instance.WeatherTimer <= (timerdivider * 2 + 1)))
            {
                iseffecting = true;
            }

            if (DataController.Instance.WeatherTimer >= NumForNextWeather)
            {
                iseffecting = true;
                Nextweather();
                EventMaker();
            }
        }
	}

    void EventMaker()
    {
        Ev = Random.Range(0, 100);

        if(Ev <= EventPercent)
        {
            isEvent = true;
        }
        else
        {
            isEvent = false;
        }
    }

    void Nextweather()
    {
        DataController.Instance.CurrentWeather++;
        if(DataController.Instance.CurrentWeather >= 4)
        {
            DataController.Instance.CurrentWeather = 0;
        }
        DataController.Instance.WeatherTimer = 0.0f;
    }

    void NextmonthChanger()
    {
        if (DataController.Instance.CurrentWeather == 0)
        {
            if(DataController.Instance.WeatherTimer < timerdivider)
            {
                Current_month_Text.text = "3";
                Next_month_Text.text = "4";
            }else if(DataController.Instance.WeatherTimer >= timerdivider && DataController.Instance.WeatherTimer < (timerdivider * 2)){
                Current_month_Text.text = "4";
                Next_month_Text.text = "5";
            }
            else if(DataController.Instance.WeatherTimer >= (timerdivider * 2))
            {
                Current_month_Text.text = "5";
                Next_month_Text.text = "6";
            }
        }
        else if(DataController.Instance.CurrentWeather == 1)
        {
            if (DataController.Instance.WeatherTimer < timerdivider)
            {
                Current_month_Text.text = "6";
                Next_month_Text.text = "7";
            }
            else if (DataController.Instance.WeatherTimer >= timerdivider && DataController.Instance.WeatherTimer < (timerdivider * 2))
            {
                Current_month_Text.text = "7";
                Next_month_Text.text = "8";
            }
            else if (DataController.Instance.WeatherTimer >= (timerdivider * 2))
            {
                Current_month_Text.text = "8";
                Next_month_Text.text = "9";
            }
        }
        else if (DataController.Instance.CurrentWeather == 2)
        {
            if (DataController.Instance.WeatherTimer < timerdivider)
            {
                Current_month_Text.text = "9";
                Next_month_Text.text = "10";
            }
            else if (DataController.Instance.WeatherTimer >= timerdivider && DataController.Instance.WeatherTimer < (timerdivider * 2))
            {
                Current_month_Text.text = "10";
                Next_month_Text.text = "11";
            }
            else if (DataController.Instance.WeatherTimer >= (timerdivider * 2))
            {
                Current_month_Text.text = "11";
                Next_month_Text.text = "12";
            }
        }
        else
        {
            if (DataController.Instance.WeatherTimer < timerdivider)
            {
                Current_month_Text.text = "12";
                Next_month_Text.text = "1";
            }
            else if (DataController.Instance.WeatherTimer >= timerdivider && DataController.Instance.WeatherTimer < (timerdivider * 2))
            {
                Current_month_Text.text = "1";
                Next_month_Text.text = "2";
            }
            else if (DataController.Instance.WeatherTimer >= (timerdivider * 2))
            {
                Current_month_Text.text = "2";
                Next_month_Text.text = "3";
            }
        }
    }

    void ImageChanger()
    {
        Current_month.GetComponent<Image>().sprite = Resources.Load<Sprite>("Calendar/weather_" + DataController.Instance.CurrentWeather);
        if(DataController.Instance.CurrentWeather == 3 && DataController.Instance.WeatherTimer >= (timerdivider * 2))
        {
            Next_month.GetComponent<Image>().sprite = Resources.Load<Sprite>("Calendar/weather_0");
        }
        else if(DataController.Instance.CurrentWeather == 2 && DataController.Instance.WeatherTimer >= (timerdivider * 2) || DataController.Instance.CurrentWeather == 1 && DataController.Instance.WeatherTimer >= (timerdivider * 2) || DataController.Instance.CurrentWeather == 0 && DataController.Instance.WeatherTimer >= (timerdivider * 2))
        {
            Next_month.GetComponent<Image>().sprite = Resources.Load<Sprite>("Calendar/weather_" + (DataController.Instance.CurrentWeather + 1));
        }
        else
        {
            Next_month.GetComponent<Image>().sprite = Resources.Load<Sprite>("Calendar/weather_" + DataController.Instance.CurrentWeather);
        }
    }

    void BackgroundChanger()
    {
        Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("Backgrounds/back_" + DataController.Instance.CurrentWeather);
    }
}
