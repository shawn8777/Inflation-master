using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflated : MonoBehaviour
{
    public Transform Cube_A;
    public Transform Ground;
    public Mesh mesh;
    public bool inflateMesh;
    

	// Use this for initialization
	void Start ()
    {
        Cube_A.transform.localScale = new Vector3(1, 1, 0.1f);

      
	}

    float CurrentState = 0.1f;
    float FutureState = 0.1f;
    static float t = 0.0f;


    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FutureState = 1;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            FutureState = 0.1f;

            var f = Cube_A.gameObject.AddComponent<FixedJoint>();
            f.connectedBody = Ground.GetComponent<Rigidbody>();
        }      
        if(Input.GetKeyDown(KeyCode.I))
        {
           //check gameobject A
           if(Cube_A.gameObject.GetComponent<FixedJoint>()==null)
            {
                print("Press R");
            }
           else
            {
              if(!Cube_A.gameObject.GetComponent<FixedJoint>()== null)
              {
                 var f = Cube_A.gameObject.GetComponent<FixedJoint>();
                 Destroy(f);
              }
            }
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Cube_A.gameObject.GetComponent<MeshCollider>().inflateMesh = mesh;
        }     
    }

    private void FixedUpdate()
    {
        Cube_A.transform.localScale = new Vector3(1, 1, Mathf.Lerp(CurrentState, FutureState, t));

        // .. and increase the t interpolater
        t += 0.1f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = FutureState;
            CurrentState = FutureState;
            CurrentState = temp;
            t = 0.0f;
        }
    }
}
