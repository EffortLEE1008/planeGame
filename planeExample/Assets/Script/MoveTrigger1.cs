using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger1 : MonoBehaviour
{

   
    private GameObject plane1;
    private GameObject plane2;
    private GameObject plane3;
       

    void Start()
    {
        

        plane1 = GameObject.Find("Plane1");
        plane2 = GameObject.Find("Plane2");
        plane3 = GameObject.Find("Plane3");


    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = this.transform.position + new Vector3(120, 0, 0) * Time.deltaTime;            

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SPARTA PLANE BODY")
        {
            this.transform.position = this.transform.position + new Vector3(-4500, 0, 0);
            plane1.transform.position = plane1.transform.position + new Vector3(-4500, 0, 0);
            
        }


    }
}
