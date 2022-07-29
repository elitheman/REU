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
        //string readFromFilePath = Application.streamingAssetsPath + "/Chat_Logs/" + "value" + ".txt";
        //string trial = File.ReadAllLines(readFromFilePath)[0];
        //Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + "");
        
    }

    // Update is called once per frame
    void Update()
    {
        Textt.GetComponent<TMPro.TextMeshProUGUI>().text = System.Convert.ToString(Math.Floor(slider.value));
    }

    public void SetLevel(){
        string readFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";
        string Participant = File.ReadAllLines(readFromFilePath)[0];
        string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Speed_Condition" + ".txt";
         SceneManager.LoadScene(2);
         File.WriteAllText(txtDoucumentName, System.Convert.ToString(Math.Floor(slider.value)));

    }
}
