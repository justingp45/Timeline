using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndigoGameObject : MonoBehaviour
{
    private void Awake()
    {
        GlobalReferences.Indigo = this;
    }
}
