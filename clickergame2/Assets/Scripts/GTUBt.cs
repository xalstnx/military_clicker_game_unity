using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTUBt : MonoBehaviour {

    public GameObject UpgradePanel;
    public GameObject ItemPanel;
    public GameObject StatPanel;

    public void OnClick()
    {
        ItemPanel.GetComponent<Canvas>().enabled = false;
        StatPanel.GetComponent<Canvas>().enabled = false;
        UpgradePanel.GetComponent<Canvas>().enabled = true;
    }
}
