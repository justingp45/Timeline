using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequiredComponent(typeof(Boxcollider2D))] // not nesessarily needed

public class Player : MonoBehaviour
{
    [SerializeField] private float speed; //

    private BoxCollider2D BoxCollider;

    private Vector3 moveDelta;


    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        float x = Input.GetAxisRaw("Horizontal"); //gives value that tells us where we want to move on horizontal axis
        float y = Input.GetAxisRaw("Vertical");   //gives value that tells us where we want to move on vertical axis
        

        moveDelta = new Vector3(x, (0.8f)*y, 0); 

        //swap sprite direction --> need to do later


        //move player
        transform.Translate(moveDelta * Time.deltaTime * speed); 
        //


        
        //Debug.Log(x); this is just a check, ignore me if everything is working
       // Debug.Log(y);
    }
}
