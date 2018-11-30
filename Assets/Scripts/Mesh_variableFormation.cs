using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh_variableFormation : MonoBehaviour
{
    [SerializeField] Transform VertObj;
    Mesh _mesh;

    public Transform a0;
    public Transform a1;
    public Transform a2;
    public Transform a3;
    public Transform a4;
    public Transform a5;


    List<Vector3> _updataVert;
    List<Transform> _vert;

    private void Awake()
    {
        _updataVert = new List<Vector3>();
        _vert = new List<Transform>();
    }
    // Use this for initialization
    void Start ()
    {
        var vertex = GetComponent<MeshFilter>().mesh.vertices;

        foreach(var v in vertex)
        {
            var obj = Instantiate(VertObj, transform);
            obj.transform.localPosition = v;
            _vert.Add(obj);
        }

        
    }
	
	// Update is called once per frame
	void Update ()
    {

        

        print(_updataVert.Count);

        _mesh = GetComponent<MeshFilter>().mesh;
        _mesh.vertices = new Vector3[]
        {
            a0.position,a1.position,a2.position,a3.position,a4.position,a5.position
        };
        
	}
}
