using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //private Transform playerTransform;
    [SerializeField] private int cameraTolerance;
    [SerializeField] private Transform playerTransform;

    void Start() {
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    void LateUpdate() {
        // storing current camera's position in variable temp
        //Vector3 temp = transform.position;

        // set camera's position x/y to be equal to player's position x/y
        // the reason for the added code is to allow the camera to be aligned with the pixel grid. 0.0625 unit = 1 pixel
        //float tempX;
        //temp.x = (int)(playerTransform.position.x/0.0625)*0.0625f;
        //temp.y = (int)(playerTransform.position.y/0.0625)*0.0625f;
        //float tempX = (int)(playerTransform.position.x/0.0625)*0.0625f - transform.position.x;
        //float tempY = (int)(playerTransform.position.y/0.0625)*0.0625f - transform.position.y;
        float tempX = playerTransform.position.x - transform.position.x;
        float tempY = playerTransform.position.y - transform.position.y;
        if (Mathf.Abs(tempX) > cameraTolerance) 
            transform.position=new Vector3(transform.position.x + Mathf.Sign(tempX)*(Mathf.Abs(tempX)-cameraTolerance), transform.position.y, transform.position.z);
        if (Mathf.Abs(tempY) > cameraTolerance) 
            transform.position=new Vector3(transform.position.x ,transform.position.y+ Mathf.Sign(tempY)*(Mathf.Abs(tempY)-cameraTolerance), transform.position.z);
        //if (Mathf.Abs(temp.x - transform.position.x) > cameraTolerance || Mathf.Abs(temp.y - transform.position.y) > cameraTolerance) 
            //{
                //if (Mathf.Abs(temp.x - transform.position.x) > cameraTolerance)
                //    temp.x= temp.x + Mathf.Sign(temp.x - transform.position.x)*(Mathf.Abs(temp.x - transform.position.x)-cameraTolerance);
                
                //transform.position = temp;
            //}
        //temp.x = playerTransform.position.x;
        //temp.y = playerTransform.position.y;
        // set back camera's temp position to camera's curr postion
        
    }
} // class





