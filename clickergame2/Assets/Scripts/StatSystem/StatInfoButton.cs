using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatInfoButton : MonoBehaviour {

    public GameObject StatInfoPanel;
    public bool onoff;

	// Use this for initialization
	void Start () {
        onoff = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (onoff == false)
        {
            StatInfoPanel.SetActive(true);
            onoff = true;
        }
        else
        {
            StatInfoPanel.SetActive(false);
            onoff = false;
        }
    }
}
