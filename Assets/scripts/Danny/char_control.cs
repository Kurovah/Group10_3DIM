using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class char_control : MonoBehaviour
{
    private Rigidbody rb;
    public Transform cam;
    public Animator anim;
    RaycastHit ray;
    private Vector3 velo, move;
    public float spd = 15;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velo = move  = Vector3.zero;
        canMove = true;
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

    
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down*1.5f);
    }
}
