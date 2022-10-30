using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : UITemplate
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionBoxTemplate;
    [SerializeField] private GameObject optionBoxContainer;
    [SerializeField] private DialogueActivator talkDialogue;
    //[SerializeField] private SoundManager soundManager;
    public bool hasMap = false;
    public bool hasBag = false;
    private string currentMenu = "default";
    [HideInInspector] private List<GameObject> menuOptionList = new List<GameObject>();
    public void BagGotten() { 
        hasBag = true; 
        menuOptionList[2].GetComponentInChildren<TMP_Text>().faceColor = new Color32(0,0,0,255);
        }
    public void MapGotten() { 
        hasMap = true; 
        menuOptionList[1].GetComponentInChildren<TMP_Text>().faceColor = new Color32(0,0,0,255);
        }
    void Start()
    {
        //resume, map, inventory, save, quit
        string [] boxNames={"Resume","Map","Inventory","Talk","Options"};
        for (int i=0; i<boxNames.Length; i++)
        {
            GameObject optionSlot=Instantiate(optionBoxTemplate.gameObject,optionBoxContainer.transform);
            optionSlot.gameObject.SetActive(true);
            optionSlot.GetComponentInChildren<TMP_Text>().text=boxNames[i];
            optionSlot.GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse(optionSlot.GetComponentInChildren<TMP_Text>().text));
            // Grey-out map/inventory if the player hasn't picked up the map/bag yet
            if ((boxNames[i].Equals("Inventory") && !hasBag) || (boxNames[i].Equals("Map") && !hasMap)){
                //optionSlot.GetComponentInChildren<TMP_Text>().faceColor = new Color32(150,150,150,255);
                optionSlot.GetComponentInChildren<TMP_Text>().color = new Color32(150,150,150,255);
            }
            menuOptionList.Add(optionSlot);
            
        }
        CloseUI();
    }
    private void OnPickedResponse(string option)
        {
            switch (option)
            {
                case "Resume":
                // Close out of menu
                    CloseUI();
                    break;

                case "Map":
                    if (hasMap)
                    {
                        currentMenu="map";
                        hidePauseMenu();
                        uIManager.OpenUI(UIName.Map);
                        // Open Map 
                        //soundManager.PlaySound(7);
                    }
                    break;

                case "Inventory":
                    if (hasBag)
                    {
                        currentMenu="inventory";
                        hidePauseMenu();
                        uIManager.OpenUI(UIName.Inventory);
                        // Open Inventory
                        //soundManager.PlaySound(7);
                    }
                    break;

                case "Talk":
                // Save the game
                    // I lied, there is no saving
                    talkDialogue.Interact(GetComponentInChildren<DialogueUI>());
                    CloseUI();
                    //soundManager.PlaySound(7);
                    break;
                case "Options":
                // Open "Do you want to quit" box
                //Jk, no
                    currentMenu = "options";
                    uIManager.OpenUI(UIName.Options);
                    hidePauseMenu();
                    //soundManager.PlaySound(7);
                    break;
                default:
                    Debug.Log("WARNING: Invalid Option Selected");
                    break;
            }
        }
    protected override void CloseUIInternal()
    {
        pauseMenu.SetActive(false);
        //if (IsOpen) soundManager.PlaySound(6);
        IsOpen = false;    
    }
    private void hidePauseMenu()
    {
        pauseMenu.SetActive(false);
        CloseUI();
    }
    protected override void OpenUIInternal()
    {
        //if (!IsOpen) soundManager.PlaySound(5);
        currentMenu = "default";
        pauseMenu.SetActive(true);
        IsOpen = true;
    }
}
