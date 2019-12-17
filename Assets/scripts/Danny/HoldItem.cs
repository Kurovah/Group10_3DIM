using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldItem : MonoBehaviour
{
    
    public TubeSO tubeSO;
    public GameObject Player;
    public GameObject Panel, playerCam;
    public Text PanelText;
    public Transform camP;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tubeSO.item);
        tubeSO.item.transform.position = transform.position + new Vector3(0,5);
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //make itmem spin
        tubeSO.item.transform.Rotate(0,0,1);
    }
    public void OnCollisionStay(Collision col)
    {
        //look for the tube triggers
        if (Input.GetKeyDown(KeyCode.K))
        {
            Player.GetComponent<char_control>().canMove = !Player.GetComponent<char_control>().canMove;
            if (playerCam.GetComponent<newCamControl>().state == 0)
            {
                playerCam.GetComponent<newCamControl>().state = 1;
                playerCam.GetComponent<newCamControl>().cPoint = camP;
                playerCam.GetComponent<newCamControl>().target = tubeSO.item.transform;
            }
            else
            {
                playerCam.GetComponent<newCamControl>().state = 0;
                playerCam.GetComponent<newCamControl>().target = Player.transform;
            }
            Panel.SetActive(!Player.GetComponent<char_control>().canMove);
            PanelText.text = col.gameObject.GetComponent<HoldItem>().tubeSO.description;
            Debug.Log(col.gameObject.GetComponent<HoldItem>().tubeSO.description);

        }
    }
}
