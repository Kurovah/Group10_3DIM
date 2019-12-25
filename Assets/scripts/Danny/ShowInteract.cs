using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, textPanel;
    public string textToShow;
    public Text panelText;
    private void Start()
    {
        textPanel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //only display this if the player can move
        if (player.GetComponent<char_control>().canMove)
        {
            textPanel.SetActive(true);
            panelText.text = textToShow;
        } else
        {
            textPanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textPanel.SetActive(false);
    }
}
