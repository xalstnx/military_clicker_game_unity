using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatItem : MonoBehaviour {

    public GameObject ItemIcon;
    
    void Start () {
		
	}
	
	void Update () {
        if(DataController.Instance.highitem == 0)
        {
            ItemIcon.SetActive(false);
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemRarity/item1");
        }
        else
        {
            ItemIcon.SetActive(true);
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemRarity/item" + DataController.Instance.highitem);
        }
	}
}
