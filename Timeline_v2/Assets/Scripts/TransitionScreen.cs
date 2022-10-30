using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TransitionScreen : MonoBehaviour
{
    [SerializeField] ScreenHandler screenHandler;
    [SerializeField] float transSpeed;
    [SerializeField] GameObject imageObject;
    private float transparencyLevel=0f;
    private bool halfWay = false;
    [SerializeField] private Image itsImage;
    private UnityEvent midEvent;
    //private UnityEvent endEvent;
    public void fullTransitionItself()
    {
        StartCoroutine(trans());
        StartCoroutine(halfTrans());
    }
    public void halfTransitionItself()
    {
        StartCoroutine(halfTrans());
    }
    public void sceneTransition(int index)
    {
        StartCoroutine(studiperFix(index));
    }
    public void fullTransitionItself(int index)
    {
        
        StartCoroutine(stupidFix(index));
        //StartCoroutine(trans());
       // screenHandler.changeScreen(index);
        //StartCoroutine(halfTrans());
        
        //StartCoroutine(halfTrans());
    }
    private IEnumerator stupidFix(int index)
    {
        
        yield return (trans());
        //while (!halfWay)  yield return null;
        //Debug.Log("Ff");
        //screenHandler.changeScreen(index);
        //Debug.Log("BB");
        screenHandler.changeScreen(index);
        //yield return (halfTrans());
        //while (halfWay)  yield return null;
    }
    private IEnumerator studiperFix(int index)
    {
        yield return (trans());
        screenHandler.changeScene(index);
    }
    void Start()
    {
        //itsImage.color = new Color (0f, 0f, 0f, 0f);
        //imageObject.SetActive(false);
    }
    private IEnumerator trans()
    {
        
        imageObject.SetActive(true);
        itsImage.color = new Color (0f, 0f, 0f, 0f);
        transparencyLevel=0f;
        halfWay = false;
        while (!halfWay) 
        {
            transparencyLevel+=transSpeed;
            if (transparencyLevel>=1f) 
            {
                transparencyLevel=1f;
                halfWay=true;
            }
            itsImage.color = new Color (0f, 0f, 0f, transparencyLevel);
            yield return null;
        }
        //if (midEvent!=null) midEvent.Invoke();
    }
    private IEnumerator halfTrans()
    {
        imageObject.SetActive(true);
        itsImage.color = new Color (0f, 0f, 0f, 1f);
        transparencyLevel=1f;
        halfWay = true;
        while (halfWay)
        {
            
            transparencyLevel+=-transSpeed;
            if (transparencyLevel <= 0f) 
            {
                transparencyLevel=0f;
                halfWay = false;
            }
            itsImage.color = new Color (0f, 0f, 0f, transparencyLevel);
            yield return null;
        }
        imageObject.SetActive(false);
    }
}
