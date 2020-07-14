using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjtPooling : MonoBehaviour {

    public static NewObjtPooling current;

    public GameObject PoolObj_CoinText;

    public GameObject Play_Obj;

    public int PoolAmount_CoinText = 10;

    public List<GameObject> PoolObjs_CoinText;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        PoolObjs_CoinText = new List<GameObject>();

        for(int i = 0; i < PoolAmount_CoinText; i++)
        {
            GameObject obj_CoinText = (GameObject)Instantiate(PoolObj_CoinText);
            obj_CoinText.transform.SetParent(Play_Obj.transform);
            //obj_CoinText.transform.parent = Play_Obj.transform;

            obj_CoinText.SetActive(false);
            PoolObjs_CoinText.Add(obj_CoinText);
        }
    }

    public GameObject GetPooledObject_CoinText()
    {
        for(int i = 0; i < PoolObjs_CoinText.Count; i++)
        {
            if (!PoolObjs_CoinText[i].activeInHierarchy)
            {
                return PoolObjs_CoinText[i];
            }
        }
        return null;
    }
}
