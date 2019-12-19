using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSpin : MonoBehaviour
{
    public int spinY = 0;
    
    void Update()
    {
        transform.Rotate(0, spinY*Time.deltaTime, 0);
    }
}
