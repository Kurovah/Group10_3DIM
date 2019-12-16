using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class char_control : MonoBehaviour
{
    private Rigidbody rb;
    public Transform cam,wheel;
    public Animator anim;
    public GameObject Panel, playerCam;
    public Text PanelText;
    RaycastHit ray;
    private Vector3 velo, move;
    private float spd, jumpPow, grav,offset,camAngle;
    private bool grounded, canMove;
    // Start is called before the first frame update
    void Start()
    {
        spd = 15;
        rb = GetComponent<Rigidbody>();
        velo = move  = Vector3.zero;
        grav = 1;
        jumpPow = 12;
        grounded = false;
        camAngle = 0;
        canMove = true;
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region moving based on where the camera is facing
        move.y = 0;
        move = cam.forward* Input.GetAxis("Vertical")*spd + cam.right* Input.GetAxis("Horizontal")*spd + new Vector3(0,move.y,0);
        #endregion
        velo = Vector3.Lerp(velo, move, 0.5f);
        
        //this is so the player doesn't tilt when jumping
        Vector3 lookVelo = velo - new Vector3(0, velo.y, 0);

        if (canMove)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVelo), 0.1f);
                wheel.Rotate(0, 0, 3);
            }
            rb.velocity = velo;
            float mve = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.z, 2));
            anim.SetFloat("speed", mve);
        } else
        {
            rb.velocity = Vector3.zero;
            anim.SetFloat("speed", 0);
        }
        
    }

    public void OnTriggerStay(Collider col)
    {
        //look for the tube triggers
        if (Input.GetKeyDown(KeyCode.K))
        {
            canMove = !canMove;
            if (playerCam.GetComponent<newCamControl>().state == 0) { 
                playerCam.GetComponent<newCamControl>().state = 1;
                playerCam.GetComponent<newCamControl>().cPoint = col.gameObject.GetComponent<HoldItem>().camP;
                playerCam.GetComponent<newCamControl>().target = col.gameObject.GetComponent<HoldItem>().item.transform;
            }
            else
            {
                playerCam.GetComponent<newCamControl>().state = 0;
                playerCam.GetComponent<newCamControl>().target = this.transform;
            }
            Panel.SetActive(!canMove);
            PanelText.text =  col.gameObject.GetComponent<HoldItem>().description;
            Debug.Log(col.gameObject.GetComponent<HoldItem>().description);
           
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down*1.5f);
    }
}
