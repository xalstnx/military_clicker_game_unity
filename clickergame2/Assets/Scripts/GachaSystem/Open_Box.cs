using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_Box : MonoBehaviour {
    public GameObject droppingBox;
    public GameObject droppedBox;

    public GameObject getItemPanel;

    public Inventory invsc = new Inventory();
    
    
    void Start () {
    }
	
	void Update () {
		
	}

    public void OnClick()
    {
        GameObject getItem = getItemPanel.transform.GetChild(0).gameObject;
        droppedBox.SetActive(false);
        getItemPanel.SetActive(true);
        getItemPanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemRarity/item" + GachaSystem.itemRarity);
        if (GachaSystem.itemRarity == 1)
        {
            getItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/shovel");
            invsc.AddItem(101);
        }
        else if(GachaSystem.itemRarity == 2)
        {
            getItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/backpack");
            invsc.AddItem(201);
        }
    }
}
