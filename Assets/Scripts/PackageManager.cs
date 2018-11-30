using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    [SerializeField] Transform axis;

    public Transform Center;
    public Transform P0;
    public Transform P1;
    public Transform P2;
    public Transform P3;
    public Transform DoorA;
    public Transform DoorB;

    public Transform AxisA;
    public Transform AxisXAa;//rotation.x from
    public Transform AxisXAb;

    public Transform AxisB;
    public Transform AxisXBa;//rotation.x from
    public Transform AxisXBb;

    public Transform AxisC;
    public Transform AxisXCa;//rotation.x from
    public Transform AxisXCb;

    public Transform AxisD;
    public Transform AxisXDa;//rotation.x from
    public Transform AxisXDb;

    public Transform AirR1;
    public Transform AirR2;


    // Use this for initialization
    void Start ()
    {
        var v0 = new Vector3(-13, 2, 13);
        var v1 = new Vector3(-13, 2, -13);
        var v2 = new Vector3(0, 2, 0);
       // var v2 = new Vector3(-29.7f, 2, -29.7f);
   

	}

    //for Axis A or B
    float currentAngle;
    float updataAngle;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AxisA.transform.Rotate(Vector3.up * Time.deltaTime * 10);
            AxisB.transform.Rotate(Vector3.up * Time.deltaTime * 10);

            AxisC.transform.Rotate(Vector3.down * Time.deltaTime * -10);
            AxisD.transform.Rotate(Vector3.down * Time.deltaTime * -10);

            AxisXAa.transform.Rotate(Vector3.down * Time.deltaTime * -20);
            AxisXAb.transform.Rotate(Vector3.up * Time.deltaTime * -20);

            AxisXBa.transform.Rotate(Vector3.down * Time.deltaTime * 20);
            AxisXBb.transform.Rotate(Vector3.up * Time.deltaTime * 20);

            AxisXCa.transform.Rotate(Vector3.down * Time.deltaTime * -20);
            AxisXCb.transform.Rotate(Vector3.up * Time.deltaTime * -20);

            AxisXDa.transform.Rotate(Vector3.down * Time.deltaTime * -20);
            AxisXDb.transform.Rotate(Vector3.up * Time.deltaTime * -20);



            // print(AxisA.rotation.x);
        }

        if (Input.GetKey(KeyCode.D))
        {
            AxisA.transform.Rotate(Vector3.up * Time.deltaTime * -10);
            AxisB.transform.Rotate(Vector3.up * Time.deltaTime * -10);

            AxisC.transform.Rotate(Vector3.down * Time.deltaTime * 10);
            AxisD.transform.Rotate(Vector3.down * Time.deltaTime * 10);

            AxisXAa.transform.Rotate(Vector3.down * Time.deltaTime * 20);
            AxisXAb.transform.Rotate(Vector3.up * Time.deltaTime * 20);

            AxisXBa.transform.Rotate(Vector3.down * Time.deltaTime * -20);
            AxisXBb.transform.Rotate(Vector3.up * Time.deltaTime * -20);

            AxisXCa.transform.Rotate(Vector3.down * Time.deltaTime * 20);
            AxisXCb.transform.Rotate(Vector3.up * Time.deltaTime * 20);

            AxisXDa.transform.Rotate(Vector3.down * Time.deltaTime * 20);
            AxisXDb.transform.Rotate(Vector3.up * Time.deltaTime * 20);



            // print(AxisA.rotation.x);
        }

        //for door 
        if (Input.GetKey(KeyCode.P))
        {
            AirR1.transform.Rotate(0, 0,Time.deltaTime * 20);
            AirR2.transform.Rotate(0, 0, Time.deltaTime * 20);

        }
        if (Input.GetKey(KeyCode.O))
        {
            AirR1.transform.Rotate(0, 0, Time.deltaTime * -20);
            AirR2.transform.Rotate(0, 0, Time.deltaTime * -20);

        }


    }

    bool AxisAngle()
    {
        if(AxisA.rotation.x<=-0.65f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
