using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideScript : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Slider slider, slider2;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("explode", -1, slider.value);
        transform.localEulerAngles = new Vector3(0, slider2.value, 0);
    }
}
