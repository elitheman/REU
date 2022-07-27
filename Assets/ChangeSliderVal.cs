using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeSliderVal : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject Textt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Textt.GetComponent<TMPro.TextMeshProUGUI>().text = System.Convert.ToString(Math.Floor(slider.value));
    }
}
