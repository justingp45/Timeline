using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    void setCamera()    
    {
        Vector3 temp = cameraTransform.position;
        temp.z=0;
        transform.position=temp;
        //transform.
        //Debug.Log(cameraTransform.position);
    }
    void Start()
    {
        setCamera();
    }
    void LateUpdate()
    {
        setCamera();
    }
    
}
