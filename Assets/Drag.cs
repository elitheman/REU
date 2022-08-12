using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;




public class Drag : MonoBehaviour

{

    private Vector3 mOffset;

    public float time;
    private bool started = false;



    private float mZCoord;

    private string participant;

   public int trial;
   public string speedCon;
   public string trialNum;
   void Update(){
       if(Input.GetButtonDown("Fire2")){
           string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" +"Participant_" + participant + "/" +"Condition_" + speedCon +  "/"+"Trial_" + trialNum + "/" + "User_Move_Time" + ".txt";
           File.WriteAllText(txtDoucumentName, System.Convert.ToString(time));
            SceneManager.LoadScene(3);
       }

       if(Input.GetButtonDown("Jump")){
           string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" +"Participant_" + participant + "/" +"Condition_" + speedCon +  "/"+"Trial_" + trialNum + "/" + "User_Move_Time" + ".txt";
           File.WriteAllText(txtDoucumentName, System.Convert.ToString(time));
           SceneManager.LoadScene(1);


       }
   }
    void Start()
    {
        string reaFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";
        participant = File.ReadAllLines(reaFromFilePath)[0];
        string readFromFilePathSpeed = Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + participant + "/"+"Speed_Condition" + ".txt";
        speedCon = File.ReadAllLines(readFromFilePathSpeed)[0];
        trialNum = File.ReadAllLines(Application.streamingAssetsPath + "/Data_REU/" + "Participant_" + participant + "/" + "Condition_" + speedCon + "/" + "Trial_Cur"  + ".txt")[0];
        trial = System.Convert.ToInt32(File.ReadAllLines(readFromFilePathSpeed)[0]);
        if(trial > 4){
            transform.position = new Vector3(11, 0 , 0);
        }
    }
    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    { 
        if(trial < 4){
        if(transform.position.x < 11){
            time+=Time.deltaTime;
        Vector3 joe = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(joe.x, 0, joe.z);}}
        else{
        if(transform.position.x > -11){
            time+=Time.deltaTime;
        Vector3 joe = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(joe.x, 0, joe.z);}}

        }
        

}