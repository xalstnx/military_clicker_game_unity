using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha_exit_bt : MonoBehaviour {

    public GameObject GachaPanel;

    public void OnClick()
    {
        if(GachaPanel.activeSelf)
        GachaPanel.SetActive(false);
    }
}
