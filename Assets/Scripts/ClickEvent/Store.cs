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
    public Button buddyButton;
    public Button buddyAmountButton;
    public Button buddySpeed;

    private Vector3 buddySpawnPos;

    public int[] storeCost = { 10, 25, 15, 50, 100, 200 };
    private bool autoOn;
    private float autoSpeed;

    private bool buddyOn;
    public GameObject buddy;
    private int buddyAmount;
    private float buddyMaxSpeed;
    private float buddyMinSpeed;
    void Start()
    {
        clickerScript = GameObject.Find("Canvas").GetComponent<ClickerScript>();
        autoOn = false;
        buddyOn = false;
        buddyMaxSpeed = 60;
        buddyMinSpeed = 30;
        buddyAmount = 25;
        autoSpeed = 3;

        
    }

    // Update is called once per frame
    void Update()
    {
        ActivateStore();

        buddySpawnPos = new Vector3(Random.Range(50, 1000), Random.Range(50, 400), 0);
        Debug.Log(buddySpawnPos);
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

    public void SpawnHelper()
    {
        buddyOn = true;
        buddyButton.gameObject.SetActive(false);
        buddyAmountButton.gameObject.SetActive(true);
        buddySpeed.gameObject.SetActive(true);
        StartCoroutine(BuddyCooldown());
        clickerScript.clickAmount -= storeCost[1];
    }

    public void IncreaseHelperSpeed()
    {
        if(clickerScript.clickAmount >= storeCost[4] || buddyOn)
        {
            buddyMinSpeed *= .5f;
            buddyMaxSpeed *= .5f;
            clickerScript.clickAmount -= storeCost[4];
            storeCost[4] *= 2;
        }
    }

    public void IncreaseBuddyAmount()
    {
        if (clickerScript.clickAmount >= storeCost[4] || buddyOn)
        {
            buddyAmount *= 2;
            clickerScript.clickAmount -= storeCost[5];
            storeCost[5] *= 2;
        }
    }

    private IEnumerator BuddyCooldown()
    {


        while (buddyOn)
        {
            buddy.transform.position = buddySpawnPos;
            yield return new WaitForSeconds(Random.Range(buddyMinSpeed, buddyMaxSpeed));
            buddy.gameObject.SetActive(true);
            clickerScript.clickAmount += buddyAmount;
            yield return new WaitForSeconds(3);
           buddy.gameObject.SetActive(false);
        }
    }

    private IEnumerator SetAutoClick()
    {
        while (buddyOn)
        {
            yield return new WaitForSeconds(autoSpeed);
            clickerScript.clickAmount++;
        }
    }
}
