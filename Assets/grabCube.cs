using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabCube : MonoBehaviour
{
    public LineRenderer line;
    public float lineDist = 10;

    Transform grabbedObject;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward *lineDist);

        if (Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                if(hit.transform.tag == "Slider"){
                    Vector3 sliderDestination = hit.transform.InverseTransformPoint(hit.point);
                    sliderDestination.z = 0;
                    sliderDestination.y = 0;
                    hit.transform.GetChild(0).localPosition = sliderDestination;
                }
                else{
                hit.transform.parent = transform;
                grabbedObject = hit.transform;
                }
            }

        if(Input.GetButtonUp("Fire1")){
            if(grabbedObject != null){
                grabbedObject.parent = null;
            }
            grabbedObject = null;
        }
        }
    }
}
