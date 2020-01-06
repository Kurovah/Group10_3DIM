using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLockCharControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform ship;
    public bool active;
    void Start()
    {
        ship = GetComponent<Transform>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            //moving forward and back
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                ship.position += ship.forward.normalized * speed * Time.deltaTime;
            }
            if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                ship.position -= ship.forward.normalized * speed * Time.deltaTime;
            }

            //side to side
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                ship.position -= ship.right.normalized * speed * Time.deltaTime;
            }
            if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                ship.position += ship.right.normalized * speed * Time.deltaTime;
            }

            //Yaw
            if (Input.GetKey(KeyCode.U) && !Input.GetKey(KeyCode.I))
            {
                ship.Rotate(0, 10 * Time.deltaTime, 0);
            }
            if (!Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.I))
            {
                ship.Rotate(0, -10 * Time.deltaTime, 0);
            }
        }
    }
}
