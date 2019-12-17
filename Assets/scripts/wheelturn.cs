using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelturn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform wheel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheel.Rotate(0,0,3);
    }
}
