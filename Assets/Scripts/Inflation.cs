using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Folding
{
    public class Inflation : MonoBehaviour
    {

        [SerializeField] GameObject _shell;
        [SerializeField] GameObject _vertPrefab;
        public PackageManager PK;

        public Material m1;
        public Material m2;
        //[SerializeField] bool _toInflat;
        //[SerializeField] float _inflateSpeed = 5f;
        Mesh _originalMesh;
        Mesh _mesh;

        public List<Vector3> _updateVerts;

        public List<Transform> _vertRig;

       

        // Use this for initialization
        void Start()
        {
            _originalMesh = _shell.GetComponent<MeshFilter>().sharedMesh;
            _updateVerts = new List<Vector3>();
            _vertRig = new List<Transform>();
          

            foreach (var v in _originalMesh.vertices)
            {
                var vrig = Instantiate(_vertPrefab, transform);

                vrig.transform.localPosition = v;

                _vertRig.Add(vrig.transform);
                _updateVerts.Add(v);
                // _VertObj.Add(v, vrig.transform);

                DividedVertex(v,vrig);
            }


        }

        void DividedVertex(Vector3 v, GameObject o)
        {
            //For center
            if (v.z > -13.6f & v.x < 13 & v.x > -13 & v.z < 13.6f && v.y < 3)
            {
                Fix(o, PK.Center.gameObject);

            }

            //for P0
            if (v.x < -13 & v.z < 13.6f & v.z > -13.6f& v.y < 3)
            {
                Fix(o, PK.P0.gameObject);
            }

            //for P1
            if (v.x < -13 & v.x >13 & v.z > 13.6f & v.y < 3)
            {
                Fix(o, PK.P1.gameObject);
            }

            //for p2
            if (v.x >13 & v.z < 13.6f & v.z > -13.6f & v.y < 3)
            {
                Fix(o, PK.P2.gameObject);
            }

            //for p3
            if (v.x < -13 & v.x > 13 & v.z < -13.6f & v.y < 3)
            {
                Fix(o, PK.P3.gameObject);
            }

            //for DoorA
            if (v.x < -41f & v.z < 13.6f & v.z > -13.6f & v.y < 25 & v.y > 2)
            {
                Fix(o, PK.DoorA.gameObject);
              
            }

            //for DoorB
            if (v.x > 41f & v.z < 13.6f & v.z > -13.6f & v.y < 25 & v.y > 2)
            {
                Fix(o, PK.DoorB.gameObject);
               
            }

            
        }

        public FixedJoint Fix(GameObject a, GameObject b)
        {
            var f = a.AddComponent<FixedJoint>();
            f.connectedBody = b.GetComponent<Rigidbody>();
            return f;
        }






        // Update is called once per frame
        void Update()
        {
            UpdateMesh();
            //if (Input.GetKey(KeyCode.P))
            //{
            //    GetComponent<MeshRenderer>().material = m1;
            //}
        }

        public void UpdateMesh()
        {
            for (int i = 0; i < _updateVerts.Count; i++)
            {
                _updateVerts[i] = _vertRig[i].position;
            }

            _mesh = new Mesh
            {
                vertices = _updateVerts.ToArray(),
                triangles = _originalMesh.triangles
            };

            GetComponent<MeshFilter>().mesh = _mesh;
            

        }

       public void Inflate(float s)
        {
            var _inflateSpeed = s;
            for (int i = 0; i < _updateVerts.Count; i++)
            {
                var rig = _vertRig[i].GetComponent<Rigidbody>();
                if (!rig.isKinematic)
                {
                    rig.isKinematic = true;
                }
                var p = Vector3.Lerp(rig.transform.position, _originalMesh.vertices[i], Time.deltaTime * _inflateSpeed);

                rig.MovePosition(p);
            }
        }

        public void OffKinematic()
        {
            for (int i = 0; i < _updateVerts.Count; i++)
            {
                var rig = _vertRig[i].GetComponent<Rigidbody>();
                if (rig.isKinematic)
                {
                    rig.isKinematic = false;
                }

            }



            // StartCoroutine(VertFalling());

        }

        //IEnumerator VertFalling()
        //{
        //    for (int i = 0; i < _updateVerts.Count; i++)
        //    {
        //        var rig = _vertRig[i];
        //        rig.Translate(0, -3f * Time.deltaTime, 0);
               

        //    }
        //    yield return new WaitUntil(TouchGround);


        //    for (int i = 0; i < _updateVerts.Count; i++)
        //    {
        //        var rig = _vertRig[i];
        //        rig.Translate(0, 0, 0);


        //    }

        //}

        //List<Vector3> CheckVertices = new List<Vector3>();
        //void CheckVert()
        //{
        //    foreach(var v in _updateVerts)
        //    {
        //        if (v.y > 3)
        //        {
        //            CheckVertices.Add(v);
        //        }
        //    }
        //}

        //bool TouchGround()
        //{
        //    if(CheckVertices.Count>0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        
            
        
    }
}
