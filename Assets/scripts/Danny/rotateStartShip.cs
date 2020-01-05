using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateStartShip : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ship;
    void Start()
    {
        ship = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ship.Rotate(0, 0.05f, 0);
    }
}
