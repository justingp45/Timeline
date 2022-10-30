using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FirstLoad : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] GameObject cutsceneManger;
    //[SerializeField] UnityEvent[] startCutscene;
    [SerializeField] UnityEvent startCutscene;
    public bool playCutscene => startCutscene!=null;
    // Start is called before the first frame update
    void Start()
    {
        if (playCutscene) {
            player.GetComponent<PlayerMovement>().inCutscene=true;
            //StartCoroutine(PlayStartCutscene());
            PlayStartCutscene();
        }
    }
    public void PlayStartCutscene()
    {
        //yield return null;
        //foreach (UnityEvent givenEvent in startCutscene)
        //{givenEvent.Invoke();}
        startCutscene.Invoke();
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
