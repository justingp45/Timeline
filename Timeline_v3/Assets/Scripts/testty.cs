using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testty : MonoBehaviour
{
    // Start is called before the first frame update
      void OnEnable()
    {
        EventManager.StartListening("testMan", Testt);
    }

    // Update is called once per frame
    void Testt(Dictionary<string, object> message)
    {
         //var amount = (int) message["amount"];
         Testt();
    }
    void Testt()
{
    Debug.Log("test");
}
}
