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
    public string trial;
    void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Chat_Logs/" + "value" + ".txt";
        trial = File.ReadAllLines(readFromFilePath)[0];
        if(System.Convert.ToInt32(trial) > 4){
            transform.position = new Vector3(11, 0 , 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3")){
            SceneManager.LoadScene(3);
        }
        if(Input.GetButtonDown("Fire2")){
            Application.LoadLevel(Application.loadedLevel);}

        if(Input.GetButtonDown("Fire1")){
            start = true;}


        switch(trial){
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
