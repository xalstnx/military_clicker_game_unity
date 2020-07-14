using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour {

    public static bool isPausing = false;
    public GameObject PausePanel;

    void Update()
    {
        if (isPausing)
        {
            PausePanel.SetActive(true);
        }
        else
        {
            PausePanel.SetActive(false);
        }
    }
}
