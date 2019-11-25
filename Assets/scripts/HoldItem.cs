using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldItem : MonoBehaviour
{
    public GameObject item;
    public string description;
    public Transform camP;
    // Start is called before the first frame update
    void Start()
    {
        item.transform.position = transform.position + new Vector3(0,5);
    }

    // Update is called once per frame
    void Update()
    {
        //make itmem spin
        item.transform.Rotate(0,0,1);
    }
}
