using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ResponseEventInvoker : MonoBehaviour
{
    // Because we can't simply invoke events within the UI scene that will affect objects outside of that scene, we have to to do this
    // Don't worry, I hate it too
    private void Awake(){
       UIManager.SendResponsEventsToScene += SendResponsEventsToScene;
   }
   private void SendResponsEventsToScene(ResponseEvent givenEvents){
       givenEvents.OnPickedResponse?.Invoke();
   }
}
