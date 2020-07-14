using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Gacha : MonoBehaviour {
    public GameObject gachaPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (!gachaPanel.activeSelf)
        {
            gachaPanel.SetActive(true);
        }
    }
}
