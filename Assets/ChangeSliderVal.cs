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
    public string Participant;
    
    void Start()
    {
        //string readFromFilePath = Application.streamingAssetsPath + "/Chat_Logs/" + "value" + ".txt";
        //string trial = File.ReadAllLines(readFromFilePath)[0];
        //Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + "");
        string readFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";

        Participant = File.ReadAllLines(readFromFilePath)[0];
    }

    // Update is called once per frame
    void Update()
    {
        Textt.GetComponent<TMPro.TextMeshProUGUI>().text = System.Convert.ToString(Math.Floor(slider.value));
    }

    public void SetLevel(){
        if(File.Exists(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_Cur" + ".txt" ) == false){
            string trackedTrial = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_Cur" + ".txt";
            File.WriteAllText(trackedTrial, "0");
        }

        string curtrial = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_Cur" + ".txt")[0];
        File.WriteAllText(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_Cur" + ".txt", System.Convert.ToString(System.Convert.ToInt32(curtrial) +1 ));
        string trial = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_Cur" + ".txt")[0];
        Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_" + trial);
        string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Trial_"+trial+ "/" + "Speed_Condition" + ".txt";
         File.WriteAllText(txtDoucumentName, System.Convert.ToString(Math.Floor(slider.value)));
         SceneManager.LoadScene(2);

    }
}
