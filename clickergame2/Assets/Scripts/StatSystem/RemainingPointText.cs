using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingPointText : MonoBehaviour {

    public DataController dataController;
    public Text RPT;

    void Update () {
        RPT.text = "남은 포인트 : " + DataController.Instance.statPoint;
	}
}
