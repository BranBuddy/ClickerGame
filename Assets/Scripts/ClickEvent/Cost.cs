using UnityEngine;
using TMPro;
public class Cost : MonoBehaviour
{
    public TMP_Text increaseClick;
    public TMP_Text autoClick;
    public TMP_Text increaseSpeed;

    private Store store;
    void Start()
    {
        store = GameObject.Find("Store").GetComponent<Store>();
    }

    // Update is called once per frame
    void Update()
    {
        increaseClick.text = "Cost: " + store.storeCost[0];
        autoClick.text = "Cost: " + store.storeCost[1];
        increaseSpeed.text = "Cost: " + store.storeCost[2];
    }
}
