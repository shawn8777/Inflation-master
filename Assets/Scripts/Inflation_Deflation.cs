using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflation_Deflation : MonoBehaviour
{
    [SerializeField] GameObject Inflated;
    [SerializeField] GameObject Deflated;
    [SerializeField] Transform Vertex;
    public Transform Door01;
    public Transform Door02;
    public Transform Door03;
    public Transform Center;


    [SerializeField] bool _toInflat;


    Mesh _Inflated;
    Mesh _Deflated;
    Mesh _current;

    List<Vector3> updataVert;//Inflated state
   

    List<Transform> Vert;//vertices on mesh

    private void Awake()
    {
        updataVert = new List<Vector3>();
   

        Vert = new List<Transform>();
    }

    int index = 0;
    // Use this for initialization
    void Start ()
    {
        _Inflated = Inflated.GetComponent<MeshFilter>().mesh;
        _Deflated = Deflated.GetComponent<MeshFilter>().mesh;
        

        foreach(var v in _Inflated.vertices)
        {
            var vObj = Instantiate(Vertex, transform);
            vObj.localPosition = v;
            Vert.Add(vObj);
            updataVert.Add(v);
            vObj.parent = this.transform;
            vObj.name = "Vert" + index;
            index++;
        }
        
	}

   


    Mesh m;
    float _inflateSpeed = 1.2f;
    int b = 0;
    float S = 0;
    // Update is called once per frame
    void Update ()
    {
        UpdataMeshState();

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Inflate(1.25f, _Deflated);
            StartCoroutine(Deflation());
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
           // Inflate(1.25f, _Inflated);
            StartCoroutine(Inflation());
        }

     
        if(b==0)
        {
            m = _current;
        }
        if (b == 1)
        {
            m = _Deflated;
        }
        if (b == 2)
        {
            m = _Inflated;
        }
        
        for (int i = 0; i < updataVert.Count; i++)
        {
            var rig = Vert[i].GetComponent<Rigidbody>();

            if (!rig.isKinematic)
            {
                rig.isKinematic = true;
            }

            var p = Vector3.Lerp(rig.transform.position, m.vertices[i], Time.deltaTime * _inflateSpeed);

            rig.MovePosition(p);
        }

        Moving(Door01, S);
        Moving(Door02, S);
        Moving(Door03, S);
    }

    void Moving(Transform D, float S)
    {
        var dir = Center.position - D.transform.position;
        D.transform.Translate(dir * Time.deltaTime * S);
    }

    IEnumerator Deflation()
    {
        b = 1;
        S = 0.45f;
        _inflateSpeed = 1.2f;
        yield return new WaitUntil(IsConnect);
        S = 0;
        b = 0;
        _inflateSpeed = 0;
    }
    IEnumerator Inflation()
    {
        S = -8*Time.deltaTime;
        b = 2;
        _inflateSpeed = 9*Time.deltaTime;
        yield return new WaitUntil(IsArrivedHalf);
        S = -0.3f;
        _inflateSpeed = 16 * Time.deltaTime;
        yield return new WaitUntil(IsArrivedHalf2);
        S = -0.1f;
        _inflateSpeed = 20 * Time.deltaTime;
        yield return new WaitUntil(IsArrived);
      
        b =0;
        S = 0;
        _inflateSpeed = 0;
    }

  
   

    

    bool IsConnect()
    {
        if(Door01.position.z>=-8f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsArrived()
    {
        if (Door01.position.z <-19f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsArrivedHalf()
    {
        if (Door01.position.z < -13f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsArrivedHalf2()
    {
        if (Door01.position.z < -16f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UpdataMeshState()
    {
        for(int i =0; i<updataVert.Count;i++)
        {
            updataVert[i] = Vert[i].position;
        }

        _current = new Mesh
        {
            vertices = updataVert.ToArray(),
            triangles = _Deflated.triangles
        };

        GetComponent<MeshFilter>().mesh = _current;
    }

    public void Inflate(float s, Mesh m)
    {
        var _inflateSpeed = s;
        for (int i = 0; i < updataVert.Count; i++)
        {
            var rig = Vert[i].GetComponent<Rigidbody>();

            if (!rig.isKinematic)
            {
                rig.isKinematic = true;
            }

            var p = Vector3.Lerp(rig.transform.position, m.vertices[i], Time.deltaTime * _inflateSpeed);

            rig.MovePosition(p);
        }
    }


   

    public void FixedUpdate()
    {
       
    }
}
