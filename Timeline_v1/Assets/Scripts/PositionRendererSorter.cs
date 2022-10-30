using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//uses y values to make it so that the character can be in front of or behind objects 

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private float sortingOrderBase = 0.5f; //manually change this to 5000 for all objects
    [SerializeField]
    private float offset = 0.0f; //in unity change the players offset to -0.01 (for now, this value could possibly be changed)
    [SerializeField]
    private bool runOnlyOnce = false;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
         myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset); //need to explicitly convert back
        if(runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
