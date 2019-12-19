using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform sphere;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sphere.Rotate(0,0.5f,0);
        sphere.position = new Vector3(transform.position.x, transform.position.y + 15 + Mathf.Sin(Time.time), transform.position.z);
    }
}
