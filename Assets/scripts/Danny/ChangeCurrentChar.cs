using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCurrentChar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player,ship,cam;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (cam.GetComponent<newCamControl>().target == ship.transform)
            {
                
                player.GetComponent<char_control>().canMove = true;
                ship.GetComponent<AirLockCharControl>().active = false;
                cam.GetComponent<newCamControl>().distance = 10;
                cam.GetComponent<newCamControl>().dir = new Vector3(0, 0, -cam.GetComponent<newCamControl>().distance);
                cam.GetComponent<newCamControl>().target = player.transform;
            }
            else
            {
                
                player.GetComponent<char_control>().canMove = false;
                ship.GetComponent<AirLockCharControl>().active = true;
                
                cam.GetComponent<newCamControl>().distance = 50;
                cam.GetComponent<newCamControl>().dir = new Vector3(0, 0, -cam.GetComponent<newCamControl>().distance);
                cam.GetComponent<newCamControl>().target = ship.transform;
            }
        }
    }
}
