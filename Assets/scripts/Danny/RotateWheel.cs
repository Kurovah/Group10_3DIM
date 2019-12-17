using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public Transform wheel;
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f && GetComponent<char_control>().canMove)
        {
            wheel.Rotate(0, 0, 3);
        }
    }
}
