using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTSBt : MonoBehaviour
{

    public GameObject UpgradePanel;
    public GameObject ItemPanel;
    public GameObject StatPanel;

    public void OnClick()
    {
        UpgradePanel.GetComponent<Canvas>().enabled = false;
        ItemPanel.GetComponent<Canvas>().enabled = false;
        StatPanel.GetComponent<Canvas>().enabled = true;
    }
}
