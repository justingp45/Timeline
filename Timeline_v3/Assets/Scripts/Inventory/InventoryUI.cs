using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : UITemplate
{
    [SerializeField] private GameObject inventoryBox;
    [SerializeField] private GameObject itemButtonTemplate;
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private Inventory inventoryData;
    //private GameObject[] itemBoxList;
    [SerializeField] private GameObject[] arrowButton;
    [SerializeField] private GameObject backButton;
    private List<GameObject> itemBoxList = new List<GameObject>();
    public Inventory Inventory => inventoryData;
    private int page = 0;
    // Start is called before the first frame update
    void Start()
    {
        arrowButton[0].GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse("prev"));
        arrowButton[1].GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse("next"));
        backButton.GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse("back"));
        CloseUI();
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
                    CloseUI();
                    break;
                
                default:
                    Debug.Log("Uhh how the hell- INVALID PICKED RESPONSE IN INVENTORY");
                    break;
            }
    }
    protected override void OpenUIInternal()
    {
        //refreshPage();
        uIManager.CallInventory(UIName.Inventory);
        inventoryBox.SetActive(true);
    }
    protected override void CloseUIInternal()
    {
        clearItems();
        inventoryBox.SetActive(false);
    }
    public void UpdateInventory(Inventory givenInventory)
    {
        inventoryData=givenInventory;
        refreshPage();
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
