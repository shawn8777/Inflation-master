using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoving : MonoBehaviour
{
    public Transform MovingCenter;
   
	// Use this for initialization
	void Start ()
    {
	   
	}

    // Update is called once per frame
    void Update()
    {
        var dir = MovingCenter.position - transform.position;


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(dir * Time.deltaTime*0.5f);
            print("Move");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-dir * Time.deltaTime*0.5f);
            print("Move");
        }
    }
}
