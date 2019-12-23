using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) 
        {
            this.GetComponent<Animator>().Play("CharAnim");
        }

        if (Input.GetKeyUp("w"))
        {
            this.GetComponent<Animator>().Play("rest");
        }
    }
}
