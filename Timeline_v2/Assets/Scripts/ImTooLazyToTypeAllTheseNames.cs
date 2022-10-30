using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ImTooLazyToTypeAllTheseNames : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject template;
    void Start()
    {
        string[] nameList= {"Carlos Bautista",
        "Dane Camacho",
        "Connor Capo",
        "Kai Curry",
        "Jules Gonzales",
        "Kendrick Haskins",
        "Kevin Huynh",
        "Thomas Lee",
        "Michael Nguyen",
        "Stephanie Pocci",
        "Vanessa Ragan",
        "Jordan Rodriguez",
        "Jonathan Story",
        "Ethan Maxwell Weissenberg"};

        for (int i = 0; i < nameList.Length; i++)
        {
            GameObject nameBox = Instantiate(template.gameObject, container.transform);
            nameBox.SetActive(true);
            nameBox.GetComponentInChildren<TMP_Text>().text = nameList[i];
        }
    }
}
