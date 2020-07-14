using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour {

    public GameObject dropingBox;
    public GameObject dropedBox;
    public GameObject purchaseButton;
    public GameObject smokeParticle;

    public Vector3 from = new Vector3(-0.0050125f, 424.95f, 0);
    public Vector3 to = new Vector3(-0.0050125f, -220f, 0);

    public Vector3 fromScale = new Vector3(1, 1, 1);
    public Vector3 toScale = new Vector3(10, 10, 1);
    private float startTime;
    public float totalTime = 3.0f;

    public int rareItemPercent = 15;
    public int ISEV;

    public static int itemRarity;

    void Start () {
        dropingBox.transform.localPosition = from;
        dropingBox.transform.localScale = fromScale;
    }

    public void OnClickDropingBox()
    {
        dropingBox.transform.localPosition = from;
        dropingBox.transform.localScale = fromScale;

        Invoke("go", 0);
    }

    void dropAnim()
    {
        float deltaTime = Time.time - startTime;

        if(deltaTime < totalTime)
        {
            if (purchaseButton.activeSelf)
            {
                purchaseButton.SetActive(false);
            }
            dropingBox.transform.localPosition = Vector3.Lerp(from, to, deltaTime / totalTime);
            dropingBox.transform.localScale = Vector3.Lerp(fromScale, toScale, deltaTime / totalTime);
        }
        else
        {
            if (!purchaseButton.activeSelf)
            {
                purchaseButton.SetActive(true);
            }
            dropingBox.transform.localPosition = to;
            dropingBox.transform.localScale = toScale;
            if (dropingBox.activeSelf && !dropedBox.activeSelf)
            {
                dropingBox.SetActive(false);
                ActivingGacha();
            }
        }
    }

    void go()
    {
        startTime = Time.time;
        InvokeRepeating("dropAnim", 0, 0.01667f);
    }

    void ActivingGacha()
    {
        dropedBox.SetActive(true);
        GachaItemSelecter();
        
    }

    void GachaItemSelecter()
    {
        ParticleSystem smokeParticleSystem = smokeParticle.GetComponent<ParticleSystem>();
        ISEV = Random.Range(0, 100);
        var col = smokeParticleSystem.colorOverLifetime;
        col.enabled = true;

        if (ISEV <= rareItemPercent)
        {
            itemRarity = 2;
            Gradient grad = new Gradient();
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

            col.color = grad;
        }
        else
        {
            itemRarity = 1;
            col.enabled = false;
        }
    }
}
