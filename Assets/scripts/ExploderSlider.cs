using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploderSlider : MonoBehaviour
{
    Animator anim;
    public UnityEngine.UI.Slider slider;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        anim.Play("explode", -1, slider.value);
    }
}
