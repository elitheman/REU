using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class DragPractice : MonoBehaviour

{

    private Vector3 mOffset;



    private float mZCoord;
    private string Participant;

void Start(){
    if(!(Directory.Exists(Application.streamingAssetsPath+ "/Data_REU/"))){
    Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/");
    string txDoucumentName = Application.streamingAssetsPath + "/Data_REU/" + "Participant_Cur" + ".txt";
    File.WriteAllText(txDoucumentName, "0");
    ;}
    string readFromFilePath = Application.streamingAssetsPath + "/Data_REU/" + "Participant_cur" + ".txt";
    Participant = File.ReadAllLines(readFromFilePath)[0];
    Directory.CreateDirectory(Application.streamingAssetsPath+ "/Data_REU/" + "Participant_" + System.Convert.ToString(System.Convert.ToInt32(Participant) +1 ));
    string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" + "Participant_Cur" + ".txt";
    Participant =System.Convert.ToString(System.Convert.ToInt32(Participant) +1 );
    File.WriteAllText(txtDoucumentName, Participant);

}

    void Update(){
         if(Input.GetButtonDown("Fire2")){
             string txtDoucumentName = Application.streamingAssetsPath + "/Data_REU/" +"Participant_" + System.Convert.ToString(System.Convert.ToInt32(Participant)) + "/" +"Practice_Total_Time" + ".txt";
             File.WriteAllText(txtDoucumentName, System.Convert.ToString(Time.timeSinceLevelLoad));
            SceneManager.LoadScene(1);}
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
        Vector3 joe = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(joe.x, 0, joe.z);
        
    }

}