using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    public void OnClick()
    {
        if(!PauseSystem.isPausing)
            PauseSystem.isPausing = true;
        else
        {
            PauseSystem.isPausing = false;
        }
    }
}
