using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Store : MonoBehaviour
{

    private ClickerScript clickerScript;
    public Button storeButton;
    public Button autoClickButton;
    public Button increaseAuto;

    public int[] storeCost = { 10, 25, 15 };
    private bool autoOn;
    private float autoSpeed;
    void Start()
    {
        clickerScript = GameObject.Find("Canvas").GetComponent<ClickerScript>();
        autoOn = false;
        autoSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ActivateStore();
    }

    void ActivateStore()
    {
        if (clickerScript.clickAmount <= 10)
        {
           storeButton.enabled = false;
        }
        else
        {
            storeButton.enabled = true;
        }
    }

    public void IncreaseClick()
    {
        if (clickerScript.clickAmount >= storeCost[0])
        {
            clickerScript.clickWorth *= 2;
            clickerScript.clickAmount -= storeCost[0];
            storeCost[0] *= 2;
        }
    }

    public void AutoClick()
    {
        if (clickerScript.clickAmount >= storeCost[1])
        {
            autoOn = true;
            StartCoroutine(SetAutoClick());
            clickerScript.clickAmount -= storeCost[1];
            autoClickButton.enabled = false;
            increaseAuto.gameObject.SetActive(true);
            autoClickButton.gameObject.SetActive(false);
        }
    }

    public void IncreaseAutoSpeed()
    {
        if(clickerScript.clickAmount >= storeCost[2] || autoOn)
        {
            autoSpeed *= .5f;
            clickerScript.clickAmount -= storeCost[2];
            storeCost[2] *= 2;
        }
    }

    private IEnumerator SetAutoClick()
    {
        while (autoOn)
        {
            yield return new WaitForSeconds(autoSpeed);
            clickerScript.clickAmount++;
        }
    }
}
