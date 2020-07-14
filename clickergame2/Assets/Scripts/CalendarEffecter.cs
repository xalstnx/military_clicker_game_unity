using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarEffecter : MonoBehaviour {

    public Image monthImage;
    public float fades = 1.0f;
    float time = 0;

    public float ypos = 0.0f;

    public float downypos;
	
	void Update () {
        if (WeatherSystem.iseffecting)
        {
            fadein();
            ypos -= 0.1f;
            transform.Translate(0, ypos, 0);
        }
	}

    void fadein()
    {
        time += Time.deltaTime;
        if(fades > 0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            monthImage.color = new Color(1, 1, 1, fades);
            time = 0;
        }
        else if(fades <= 0.0f)
        {
            WeatherSystem.iseffecting = false;
            fades = 1.0f;
            monthImage.color = new Color(1, 1, 1, fades);
            downypos = transform.localPosition.y;
            ypos = 0;
            transform.Translate(0, -downypos, 0);
        }
    }
}
