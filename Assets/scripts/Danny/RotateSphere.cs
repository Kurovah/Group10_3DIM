using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform sphere;
    public Renderer rend;
    private float c,end;
    void Start()
    {
        c = 0;
        rend.material.SetFloat("Cutoff", c);
        end = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sphere.Rotate(0,0.5f,0);
        sphere.position = new Vector3(transform.position.x, transform.position.y + 20 + Mathf.Sin(Time.time), transform.position.z);
        c = Mathf.Lerp(c, end, 0.1f);
        rend.material.SetFloat("_cutoff", c);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(end == 0)
            {
                end = 1;
            } else
            {
                end = 0;
            }
        }
    }
}
