using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TransitionTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent transitionEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement PlayerMovement))
        {
            Debug.Log("enter");
            //PlayerMovement.Interactable = this;
            transitionEffect.Invoke();
        }
    }
}
