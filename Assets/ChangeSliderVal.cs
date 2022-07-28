using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class ChangeSliderVal : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject Textt;
    
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath+ "/Chat_Logs/");
        
    }

    // Update is called once per frame
    void Update()
    {
        Textt.GetComponent<TMPro.TextMeshProUGUI>().text = System.Convert.ToString(Math.Floor(slider.value));
    }

    public void SetLevel(){
        string txtDoucumentName = Application.streamingAssetsPath + "/Chat_Logs/" + "value" + ".txt";
         SceneManager.LoadScene(2);
         File.WriteAllText(txtDoucumentName, System.Convert.ToString(Math.Floor(slider.value)));

    }
}
