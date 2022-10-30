using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MasterStart : MonoBehaviour
{
    [SerializeField] UnityEvent eventStart;
    [SerializeField] bool playEvent;
    void Start()
    {
        if (playEvent) eventStart.Invoke();
    }
}
