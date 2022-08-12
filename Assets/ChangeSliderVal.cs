using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class ChangeSliderVal : MonoBehaviour
{
    // Start is called before the first frame update

    public string Participant;
    public string trial;
    
    void Start()
    {
        //string readFromFilePath = Application.streamingAssetsPath + "/Chat_Logs/" + "value" + ".txt";
        //string trial = File.ReadAllLines(readFromFilePath)[0];
        //Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + "");
    string readFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";

       Participant = File.ReadAllLines(readFromFilePath)[0];

       string speed_con_stk= File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "SpeedCur" + ".txt")[0];
        if(speed_con_stk== "8"){
           stopApplication();
           return;
       }

   
       
    }


    public void SetLevel(){

    string speed_con_st= File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "SpeedCur" + ".txt")[0];
       if(speed_con_st == "8"){
           return;
       }
       else{
        string speedCon = getSpeedCondition();
        
        Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + Participant + "/" +"Condition_" + speedCon+ "/"+"Trial_" + trial);
        string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/"+"Speed_Condition" + ".txt";
        File.WriteAllText(txtDoucumentName, speedCon); //this is the problem 
         SceneManager.LoadScene(2);}
        

    }

    private string getSpeedCondition(){
        List<string> speed_cons = File.ReadLines(Application.streamingAssetsPath + "/Data_REU/" + "Input.txt").ToList();
        //Debug.Log(String.Join("\n", speed_cons));
   
       // List<string> speed_con_arr = speed_con_arrs.ToList();

        //List<List<string>> speed_cons = new List<List<string>>();

       // for(int i = 0; i < speed_con_arr.Count; i++){
       //     speed_cons.AddRange(speed_con_arr[i].Split(',').ToList());
       //     Debug.Log(speed_con_arr[i]);
       // }

        //Debug.Log(speed_cons.Count);
       string speed_con_str = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "SpeedCur" + ".txt")[0];
       string speed_condition_return = System.Convert.ToString(speed_cons[System.Convert.ToInt32(Participant) -1][System.Convert.ToInt32(speed_con_str)]); 
        if(Directory.Exists(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + Participant + "/" +"Condition_" + speed_condition_return)==false){
            Debug.Log(speed_condition_return);
            Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + Participant + "/" +"Condition_" + speed_condition_return);
        }
        if(File.Exists(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Condition_" + speed_condition_return + "/" + "Trial_Cur"  + ".txt") == false){
            string trackedTrial = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Condition_" + speed_condition_return+ "/" + "Trial_Cur"  + ".txt";
            File.WriteAllText(trackedTrial, "0");
        }
    trial = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Condition_" + speed_condition_return+ "/" + "Trial_Cur"  + ".txt")[0];
    File.WriteAllText(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Condition_" +  speed_condition_return+ "/" + "Trial_Cur"  + ".txt", System.Convert.ToString(System.Convert.ToInt32(trial)+1) );
    trial = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Condition_" + speed_condition_return+ "/" + "Trial_Cur"  + ".txt")[0];
       if(System.Convert.ToInt32(System.Convert.ToString(trial)) == 3){

           File.WriteAllText(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "SpeedCur" + ".txt", System.Convert.ToString(System.Convert.ToInt32(speed_con_str) +1 ));
       }
       return speed_condition_return;
       


        // read from file that says current trial number and use the current participant number
        // if trial is 3, move on to next speed condition, create new folder with the speed condition 
        // set trial number to 1
        // 
        // 

    }

    private void stopApplication(){

        string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" +"Participant_" + Participant + "/" + "Total_Application_Time" + ".txt";
        File.WriteAllText(txtDoucumentName, System.Convert.ToString(Time.time));


    }
}
