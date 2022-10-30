using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTrigger : MonoBehaviour
{
    EventManager eM;
    [SerializeField] public MultiSceneLoader msL;
    [SerializeField] public SceneName scene;
    [SerializeField] public bool Unload;
    private void OnTriggerEnter2D(Collider2D other)
    {
        msL.LoadScene(scene);
        EventManager.TriggerEvent("testMan",  new Dictionary<string, object> { { "pause", true } });
       // GuidReference reference = new GuidReference();
        
        //em=reference.gameObject.GetComponent<EventManager>();
        //eM.TriggerEvent("testMan",  null);
    }
    
}

