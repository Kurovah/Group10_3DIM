using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoScreen1 : MonoBehaviour
{
    public Renderer goRend;

    void Start()
    {
        goRend = GetComponent<Renderer>();
        goRend.enabled = true;
        //this.GetComponent<Renderer>().enabled = true;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            goRend.enabled = !goRend.enabled;
            //this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled;
        }
    }
}

