using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    void Start()
    {
        Time.captureFramerate=60;
        Application.targetFrameRate = 60;
    }
}
