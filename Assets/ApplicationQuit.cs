using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ApplicationQuit : MonoBehaviour
{
    // Start is called before the first frame update

    string participant;
    void Start()
    {
        string reaFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";
        participant = File.ReadAllLines(reaFromFilePath)[0];
        
    }

    void OnApplicationQuit(){

        string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" +"Participant_" + participant + "/" + "Total_Application_Time" + ".txt";
        File.WriteAllText(txtDoucumentName, System.Convert.ToString(Time.time));

    }
}
