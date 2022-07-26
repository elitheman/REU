using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 5f;
    public bool start = false;
    public string speedCon;
    public bool track_time = false;
    public float time;
    public string trialNum;
    void Start()
    {
        string reaFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";
        string Participant = File.ReadAllLines(reaFromFilePath)[0];
        string readFromFilePathSpeed = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/"+"Speed_Condition" + ".txt";
        speedCon = File.ReadAllLines(readFromFilePathSpeed)[0];
        trialNum = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + Participant + "/" + "Condition_" + speedCon + "/" + "Trial_Cur"  + ".txt")[0];
        //trial = readFromFilePath[0];
        if(System.Convert.ToInt32(speedCon) > 4){
            transform.position = new Vector3(11, 0 , 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(track_time && transform.position.x < 11){
            time+=Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire3")){
            SceneManager.LoadScene(3);
        }
        if(Input.GetButtonDown("Fire2")){
            Application.LoadLevel(Application.loadedLevel);}

        if(Input.GetButtonDown("Fire1")){
            track_time = true;
            start = true;}


        switch(speedCon){
        case "1": 
            if(start && transform.position.x <11){
            transform.Translate(Vector3.right * speed * Time.deltaTime);}
            break;
        case "2": 
            if(start && transform.position.x <11){
            transform.Translate(Vector3.right * speed * Time.deltaTime);}
            break;
        case "3": 
            if(start && transform.position.x <11){
            transform.Translate(Vector3.right * speed * Time.deltaTime);}
            break;
        case "4": 
            if(start && transform.position.x <11){
            transform.Translate(Vector3.right * speed * Time.deltaTime);}
            break;
        case "5": 
            if(start && transform.position.x > -11){
            transform.Translate(Vector3.left * speed * Time.deltaTime);}
                break;
        case "6": 
            if(start && transform.position.x > -11){
            transform.Translate(Vector3.left * speed * Time.deltaTime);}
            break;
        case "7": 
                    if(start && transform.position.x > -11){
            transform.Translate(Vector3.left * speed * Time.deltaTime);}
            
            break;
        case "8":
            if(start && transform.position.x > -11){
            transform.Translate(Vector3.left * speed * Time.deltaTime);}
            break;
            


        }
        
    }
}
