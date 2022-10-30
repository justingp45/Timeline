using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryBox;
    [SerializeField] private GameObject itemButtonTemplate;
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private Inventory inventoryData;
    //private GameObject[] itemBoxList;
    [SerializeField] private GameObject[] arrowButton;
    [SerializeField] private GameObject backButton;
    private List<GameObject> itemBoxList = new List<GameObject>();
    public bool IsOpen { get; private set; }
    public Inventory Inventory => inventoryData;
    private int page = 0;
    // Start is called before the first frame update
    void Start()
    {
        arrowButton[0].GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse("prev"));
        arrowButton[1].GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse("next"));
        backButton.GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse("back"));
        closeInventory();
    }
    private void OnPickedResponse(string option)
    {
        switch (option)
            {
                case "prev":
                    if ( page != 0 ) page += -1;
                    refreshPage();
                    break;
                case "next":
                    if ( (page + 1) * 8 < inventoryData.ItemList.Count ) page += 1;
                    refreshPage();
                    break;
                case "back":
                    closeInventory();
                    break;
                
                default:
                    Debug.Log("Uhh how the hell- INVALID PICKED RESPONSE IN INVENTORY");
                    break;
            }
    }
    public void openInventory()
    {
        IsOpen=true;
        refreshPage();
        inventoryBox.SetActive(true);
    }
    private void closeInventory()
    {
        IsOpen=false;
        clearItems();
        inventoryBox.SetActive(false);
    }
    private void refreshPage()
    {
        clearItems();
        drawItems();
        if ( (page + 1) * 8 < inventoryData.ItemList.Count ) arrowButton[1].SetActive(true);
        else arrowButton[1].SetActive(false);
        if (page != 0) arrowButton[0].SetActive(true);
        else arrowButton[0].SetActive(false);
    }
    private void drawItems()
    {
        //inventoryData.ItemList
        itemBoxList = new List<GameObject>();
        int temp=8;
        if (inventoryData.ItemList.Count - (page*8) < 8) temp = inventoryData.ItemList.Count - (page*8);
        for(int i = 0; i < temp; i++)
        {
            GameObject itemSlot = Instantiate(itemButtonTemplate.gameObject,itemContainer.transform);
            itemSlot.gameObject.SetActive(true);
            itemSlot.GetComponentInChildren<TMP_Text>().text = inventoryData.ItemList[i + (page * 8)].ItemName;
            itemBoxList.Add(itemSlot);
        }
    }
    private void clearItems()
    {
        for(int i = 0; i < itemBoxList.Count; i++)
        {
            Destroy (itemBoxList[i]);
        }
    }
}
