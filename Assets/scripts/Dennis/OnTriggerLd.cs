using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class OnTriggerLd : MonoBehaviour
{
    public GameObject guiObject;
    public string levelToLoad;
    // Use this for initialization
    void Start()
    {
        guiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
            
        }
    }

    void Update()
    {
        if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
        {
            SceneManager.LoadScene("planets");
        }
    }
    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}
