using UnityEngine;
using TMPro;

public class ClickerScript : MonoBehaviour
{
    public TMP_Text clickerCount;
    public int clickAmount;
    public int clickWorth;


    void Start()
    {
        clickAmount = 0;
        clickWorth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        clickerCount.text = clickAmount.ToString();
    }


    public void Click()
    {
        clickAmount += clickWorth;
    }

}
