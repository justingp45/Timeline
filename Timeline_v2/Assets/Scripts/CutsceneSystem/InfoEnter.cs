using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InfoEnter : MonoBehaviour
{
    //[SerializeField] GameObject nameEnter;
    //[SerializeField] GameObject genderEnter;
    //[SerializeField] GameObject ageEnter;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject template;
    [SerializeField] private DialogueObject invalidResponse;
    private List<GameObject> infoList = new List<GameObject>();
    public bool IsOpen { get; private set; }
    public List<string> infoStringList = new List<string>();
    void Start()
    {   
        string[] temp = {"Name","Gender","Age"};
        for (int i=0; i < 3; i++){
            GameObject inputBox=Instantiate(template.gameObject, container.transform);
            inputBox.SetActive(true);
            // No shot this code works first try
            // D E A D A S S  IT WORKED?????
            inputBox.GetComponentInChildren<TMP_InputField>().placeholder.GetComponentInChildren<TMP_Text>().text= "Enter "+temp[i]+"...";
            infoList.Add(inputBox);
        }
        CloseScreen();
    }
    public void OnSubmit()
    {
        bool isValidInfo = true;
        for (int i = 0; i < infoList.Count; i++){
            infoStringList.Add(infoList[i].GetComponentInChildren<TMP_InputField>().text);
            if (infoStringList[i].Equals("") || infoStringList[i].Equals(""))  isValidInfo = false;
        }
        if (!int.TryParse(infoStringList[infoStringList.Count-1],out int number)) isValidInfo = false;
        if (isValidInfo) {
            CloseScreen();
        }
        else
        {
            GetComponentInParent<DialogueUI>().ShowDialogue(invalidResponse);
            infoStringList.Clear();
        }
    }
    public void OpenScreen()
    {
        IsOpen=true;
        screen.SetActive(true);
    }
    public void CloseScreen()
    {
        IsOpen = false;
        screen.SetActive(false);
    }
}
