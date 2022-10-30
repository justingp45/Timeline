using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class LockerCode : MonoBehaviour
{
    [SerializeField] private GameObject dialTemplate;
    [SerializeField] private GameObject dialContainer;
    [SerializeField] private GameObject lockerObject;
    [SerializeField] private string solution;
    [SerializeField] private UnityEvent solutionEvent;
    private GameObject[] dialList=new GameObject[4];
    public bool isOpen;
    public bool isSolved=false;
    //private List<GameObject> dialList = new List<GameObject>();
    private int[] dialNumber = new int[4];
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject dial = Instantiate(dialTemplate.gameObject, dialContainer.transform);
            //dialList.Add();
            dial.gameObject.SetActive(true);
            // WHY IN THE WORLD DOES THE I GET SO MESSED UP WHEN PUT THROUGH ONPICKEDRESPONSE, HOW DID IT GET THE +1??? WHY ARE THEY
            // ASSIGNED THE SAME VALUE THROUGH ONPICKED UNTIL I DO THIS BS???? WHHY YYYY
            int num=i;
            dial.transform.Find("TopButton").gameObject.GetComponent<Button>().onClick.AddListener( () => OnPickedResponse(num, "top"));
            dial.transform.Find("TopButton").gameObject.GetComponent<Image>().color=new Color(1f,1f,1f,0f);
            dial.transform.Find("BottomButton").gameObject.GetComponent<Button>().onClick.AddListener( () => OnPickedResponse(num, "bottom"));
            dial.transform.Find("BottomButton").gameObject.GetComponent<Image>().color=new Color(1f,1f,1f,0f);
            dialList[i] = dial;
            dialNumber[i] = 0;
        }
        closeLocker();
    }
    public void openLocker()
    {
        if (isSolved) return;
        GetComponent<ClickableObjectHandler>().imOutOfVariableNames = false;
        isOpen=true;
        lockerObject.SetActive(true);
    }
    public void closeLocker()
    {
        GetComponent<ClickableObjectHandler>().imOutOfVariableNames = true;
        isOpen=false;
        lockerObject.SetActive(false);
    }
    private void OnPickedResponse(int index, string buttonType)
    {
        if (GetComponent<ClickableObjectHandler>().dialogueOpen) return;
        switch (buttonType)
        {
            // Add 1
            case "top":
                //if ( int.Parse(dialList[index].GetComponentInChildren<TMP_Text>().text ) >= 9) dialList[index].GetComponentInChildren<TMP_Text>().text=0;
                dialNumber[index] += 1;
                if (dialNumber[index] > 9) dialNumber[index] = 0;
                dialList[index].GetComponentInChildren<TMP_Text>().text= dialNumber[index].ToString();
                break;
            // Minus 1
            case "bottom":
                dialNumber[index] += -1;
                if (dialNumber[index] < 0) dialNumber[index] = 9;
                dialList[index].GetComponentInChildren<TMP_Text>().text= dialNumber[index].ToString();
                break;
            default:
                Debug.Log("Oh god, what have you done");
                break;

        }
        checkSolved();
    }
    private void checkSolved()
    {
        string temp="";
        for (int i = 0; i < 4; i++)
        {
            temp+=dialList[i].GetComponentInChildren<TMP_Text>().text;
        }
        if (solution.Equals(temp)) Solved();
    }
    private void Solved()
    {
        isSolved=true;
        solutionEvent.Invoke();
        closeLocker();
    }
}
