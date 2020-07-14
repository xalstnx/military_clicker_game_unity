using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour {

    public float speed = 5.0f;
    public Text CoinTextBox;
	
	void Update () {
        moving();
	}
    public void moving()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        CoinTextBox.text = "+" + DataController.Instance.goldPerClick;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End_Box"))
        {
            gameObject.SetActive(false);
        }
    }
}
