using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STUPIDLASTMINUTECODE : MonoBehaviour
{
    // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    [SerializeField] private GameObject itself;
    [SerializeField] private DialogueUI dialogueUI;
    void Start()
    {
        itself.SetActive(false);
    }
    public void showItself()
    {
        itself.SetActive(true);
        StartCoroutine(waitTillOver());
    }
    private IEnumerator waitTillOver()
    {
        while (dialogueUI.IsOpen)
        {
            yield return null;
        }
        itself.SetActive(false);
    }
}
