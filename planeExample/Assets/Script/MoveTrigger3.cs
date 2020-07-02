using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger3 : MonoBehaviour
{

    private GameObject myCharacter;
    private GameObject plane1;
    private GameObject plane2;
    private GameObject plane3;


    void Start()
    {
        myCharacter = GameObject.Find("MyCharacter");

        plane1 = GameObject.Find("Plane1");
        plane2 = GameObject.Find("Plane2");
        plane3 = GameObject.Find("Plane3");


    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = this.transform.position + new Vector3(120, 0, 0) * Time.deltaTime;

    }

    public void OnTriggerEnter(Collider other)
    {






        if (other.gameObject.name == "SPARTA PLANE BODY")
        {
            this.transform.position = this.transform.position + new Vector3(-4500, 0, 0)  ;
            plane3.transform.position = plane3.transform.position + new Vector3(-4500, 0, 0);
            


        }
      
    }
}
