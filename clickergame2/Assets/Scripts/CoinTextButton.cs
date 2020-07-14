using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTextButton : MonoBehaviour {

    private Vector3 StartPos_Vec_CoinText;
    public GameObject StartPos_CoinText;
    public GameObject Character;

    bool isEffect;
    bool isClick;
   
	void Start () {
        StartPos_Vec_CoinText = StartPos_CoinText.transform.position;
	}

    void Update()
    {
        if (isClick)
        {
            isEffect = false;
            StartCoroutine("ClickEffect");
        }
    }

    public void OnClick()
    {
        if (!PauseSystem.isPausing)
        {
            isClick = true;
            int goldPerClick = DataController.Instance.goldPerClick;
            DataController.Instance.gold += goldPerClick;
            OnCoinText();
        }
    }

    public void OnCoinText()
    {
        GameObject obj_CoinText = NewObjtPooling.current.GetPooledObject_CoinText();

        if (obj_CoinText == null)
            return;

        obj_CoinText.transform.position = StartPos_Vec_CoinText;
        obj_CoinText.SetActive(true);
    }

    IEnumerator ClickEffect()
    {
        Vector3 currentScale = Character.transform.localScale;
        Vector3 destScale = Character.transform.localScale.x == 1.05f ? Vector3.one : new Vector3(1.05f, 1.05f, 1.05f);
        Character.transform.localScale = Vector3.Lerp(currentScale, destScale, 1f);

        isEffect = (currentScale.x == 1.05f);
        isClick = false;

        yield return null;

        if (!(Character.transform.localScale.x == 1f && isEffect))
            StartCoroutine("ClickEffect");
    }
}
