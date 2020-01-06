using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
/*{
    public bool open = false;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Debug.Log("GOT THE ANIMATOR");
    }

    void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("open", true);
            Debug.Log("OPENING THE DOOR");
        }

    }

    void OnTriggerExit(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("open", false);
            Debug.Log("OPENING THE DOOR");
        }
    }
}*/
{
    public GameObject DoorButton;
    public GameObject Door;
    public float smooth;

    private Quaternion DoorOpen;
    private Quaternion DoorClosed;

    void Start()
    {

        Door = GameObject.Find("Object001");
        DoorButton = GameObject.Find("DoorButton");
        DoorButton.SetActive(false);
    }

    void OnTriggerEnter(Collider cube)
    {

        if (cube.tag == "DoorButton")
            DoorButton.SetActive(true);
        Debug.Log("button activated");

        DoorOpen = Door.transform.rotation = Quaternion.Euler(0, -90, 0);
        DoorClosed = Door.transform.rotation;

        Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
        Debug.Log("Door Opened");
    }
}