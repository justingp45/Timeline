using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadBar : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] RectTransform bar;
    public bool isDone = false;
    void Start()
    {
        //Random.InitState(6942069);
        //Random.InitState(5656);
        //square
        Random.InitState(1917211185);
        //container.SetActive(true);
        bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,0);
        //container.SetActive(false);
        
    }
    public void startBar()
    {
        container.SetActive(true);
        StartCoroutine(barMove());
    }
    private IEnumerator barMove()
    {
        //container.SetActive(true);
        for (int i = 0; i<110; i++) yield return null;
        int currentWidth=0;
        //var temp = Random.state;
        //Debug.Log(Random.state);
        while (currentWidth < 232)
        {
            
            currentWidth+=(int)Random.Range(0,2);
            if (currentWidth>232) currentWidth = 232;
            bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,currentWidth);
            yield return null;
            if (currentWidth==0) yield return null;
        }
        for (int i = 0; i<30; i++) yield return null;

        float currentTrans=1f;
        while (currentTrans > 0f)
        {
            currentTrans+=-0.02f;
            foreach (Image eachOne in container.GetComponentsInChildren<Image>()) 
                eachOne.color=new Color (eachOne.color.r, eachOne.color.g, eachOne.color.b, currentTrans);
            //container.GetComponentInChildren<Image>().color=new Color32 (0f, 0f, 0f, currentTrans);
            yield return null;
        }
        isDone = true;
    }
    public void closeBar()
    {
        //Debug.Log("END");
        container.SetActive(false);
    }
}
