using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChar : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxSpeed = 100.0f;
    public float acc = 5.0f;
    public float dec = 5.0f;
    public float rotation = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {

            if (speed < maxSpeed)
                speed += acc;
        }
        else
        {
            if (speed > 0)
                speed -= dec;
        }


        transform.position += transform.forward * Time.deltaTime * speed;

       

        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(0, -1.5f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(0, 1.5f, 0);
        }
    }
}

