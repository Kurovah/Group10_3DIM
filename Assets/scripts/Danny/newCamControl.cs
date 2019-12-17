using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamControl : MonoBehaviour
{
    public Transform target, trueForward, cPoint;
    public float xAngle, yAngle, distance;
    public Vector3 dir;
    public int state;
    private Quaternion rotate;
    // Start is called before the first frame update
    void Start()
    {
        xAngle = 18f;
        yAngle = 90;
        state = 0;
        rotate = Quaternion.Euler(xAngle, yAngle, 0);
        dir = new Vector3(0, 0, -distance);
        transform.position = target.position + rotate * dir;
    }

    // Update is called once per frame
    private void Update()
    {
        
        xAngle = Mathf.Clamp(xAngle, 10, 87);
        trueForward.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        if (Input.GetKey(KeyCode.Q))
        { xAngle--; }
        else if (Input.GetKey(KeyCode.E))
        { xAngle++; }

        //vertical
        if (Input.GetKey(KeyCode.O))
        { yAngle--; }
        else if (Input.GetKey(KeyCode.P))
        { yAngle++; }
           
    }
    void FixedUpdate()
    {
        switch (state)
        {
            case 0://normal state
                rotate = Quaternion.Euler(xAngle, yAngle, 0);
                transform.position = Vector3.Lerp(transform.position,target.position + rotate * dir,0.1f);
                break;
            case 1:
                transform.position = Vector3.Lerp(transform.position, cPoint.position, 0.5f);
                break;
        }
        transform.LookAt(target);
    }
}
