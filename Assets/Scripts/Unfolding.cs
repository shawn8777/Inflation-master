using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfolding : MonoBehaviour
{
    [SerializeField] Transform Axis;
    public Transform TriAxis0;
    public Transform TriAxis1;
    public Transform TriAxis2;
   
	// Use this for initialization
	void Start ()
    {
        //for triangle piceses
        //var v0 = new Vector3(36.37f, 2, 21);
      
        //var v1 = new Vector3(-36.37f, 2, 21);
        //var a = Instantiate(Axis, transform);
        //a.localPosition = (v0 + v1) / 2;
        //a.localRotation = Quaternion.LookRotation(a.up,v1-v0);
        //a.localScale = new Vector3(1f, (v1 - v0).magnitude / 2, 1f);
        //a.name = "RotatingAxis";

        
    }

    float currentAngle;
    float updataAngle;



	// Update is called once per frame
	void Update ()
    {
        currentAngle = Mathf.Lerp(currentAngle, updataAngle, Time.deltaTime * 0.15f);
       // TriAxis0.transform.rotation.x = TriAxis1.transform.rotation.x = TriAxis2.transform.rotation.x = currentAngle;



        if (Input.GetKey(KeyCode.A))
        {
            updataAngle = 0.1258f;
            //if(IsKinematic())
            //{
            //    Unfold();
            //}
            //else
            //{
            //    UnlockAxis();
            //    Unfold();
            //}       
        }

        //if(TriAxis0.transform.rotation.x >=0.1258f || TriAxis0.transform.rotation.x<=-0.5f)
        //{
        //    LockAxis();
        //}
        //LockAxis();

        print(TriAxis0.transform.rotation.x);
        if (Input.GetKey(KeyCode.D))
        {
            updataAngle = -0.5f;
            //if (IsKinematic())
            //{
            //    fold();
            //}
            //else
            //{
            //    UnlockAxis();
            //    fold();
            //}
        }
        //for triaxis, their rotation degree is (19,x,x) when they touch ground[TriAxis0.rotation.x=0.1258f], their rotation degree is(-90,x,x) when they folding up[TriAxis0.rotation.x=-0.5f]


    }

    void Unfold()
    {
        TriAxis0.transform.Rotate(0, -0.5f, 0);
        TriAxis1.transform.Rotate(0, -0.5f, 0);
        TriAxis2.transform.Rotate(0, -0.5f, 0);
    }

    void fold()
    {
        TriAxis0.transform.Rotate(0, 0.5f, 0);
        TriAxis1.transform.Rotate(0, 0.5f, 0);
        TriAxis2.transform.Rotate(0, 0.5f, 0);
    }

    ///Using physicalEffects
    //void UnlockAxis()
    //{
    //    TriAxis0.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //    TriAxis1.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //    TriAxis2.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //}

    //void LockAxis()
    //{
    //    TriAxis0.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //    TriAxis1.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //    TriAxis2.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //}

    //bool IsKinematic()
    //{
    //    if(TriAxis0.gameObject.GetComponent<Rigidbody>().isKinematic == false &&
    //       TriAxis1.gameObject.GetComponent<Rigidbody>().isKinematic == false &&
    //       TriAxis2.gameObject.GetComponent<Rigidbody>().isKinematic == false )
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
        
    //}
}
