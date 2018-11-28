using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InflationManager
{
    public class InflationManager : MonoBehaviour
    {
        public Transform Shell;

        public Transform Center;

        public Transform p0;
        public Transform p1;
        public Transform p2;
        public Transform p3;
        
        Mesh Main;
        private Vector3[] vertices;
        private Vector2[] UV;
        private int[] Tri;
        List<Vector3> V;
        // List<Vector2> UV;
        List<VertObjects> BottomVert;
        List<VertObjects> DoorVert;
      

        public SpringObject Sb;
        public VertObjects Vb;
        public EdgeObjetcs Eb;

        Dictionary<int, VertObjects> LVb;
        Dictionary<Vector3, VertObjects> VVb;


        private void Awake()
        {
      
            V = new List<Vector3>();

            LVb = new Dictionary<int, VertObjects>();
            VVb = new Dictionary<Vector3, VertObjects>();
            BottomVert = new List<VertObjects>();
            DoorVert = new List<VertObjects>();
        }


        // Use this for initialization
        void Start()
        {
            //Get array
            Main = Shell.gameObject.GetComponent<MeshFilter>().mesh;
            vertices = Main.vertices;
            // UV = Main.uv;
            // Tri = Main.triangles;
            
           

            //get list
            for (var i = 0; i < vertices.Length; i++)
            {
                V.Add(vertices[i]);
            }


            //Add Object
             AddVertObjects();
             AddSpring(Main);
        }


        void AddVertObjects()
        {
            for (var i = 0; i < V.Count; i++)
            {
                
                var o = Instantiate(Vb);
                o.transform.localPosition = V[i];
                o.transform.name = "Vert" + i;
                o.transform.parent = this.transform.Find("MeshVertices");
                LVb.Add(i, o);
                VVb.Add(V[i], o);
            }
            
        }

        int index = 0;
        void AddSpring(Mesh m)
        {
            DivideVertex();
            AddRigidbody();
            var E = Eb.GetMeshEdges(m);
            foreach(var e in E)
            {
                index++;
                //get two obj
                var v0 = VVb[e.a];
                var v1 = VVb[e.b];
                //add configurable joint
                var v = Instantiate(Sb);             
                var p = (e.a + e.b) / 2;
                v.transform.localPosition = p;
                v.name = "Spring" + index + "_" + v0.name + "&" + v1.name;
                v.transform.parent = this.transform.Find("SpringVertices");

                //joint A for v0
                var A = v.gameObject.AddComponent<ConfigurableJoint>();
                A.connectedBody = v0.gameObject.GetComponent<Rigidbody>();
                A.autoConfigureConnectedAnchor = false;
                A.connectedAnchor = Vector3.zero;
                A.secondaryAxis = Vector3.zero;
                A.axis = Vector3.zero;
                A.anchor = new Vector3((e.a - p).magnitude, 0, 0);

                //joint B for v1
                var B = v.gameObject.AddComponent<ConfigurableJoint>();
                B.connectedBody = v1.gameObject.GetComponent<Rigidbody>();
                B.autoConfigureConnectedAnchor = false;
                B.connectedAnchor = Vector3.zero;
                B.secondaryAxis = Vector3.zero;
                B.axis = Vector3.zero;
                B.anchor = new Vector3((e.b - p).magnitude, 0, 0);
            }
            LockVert();
        }


        void DivideVertex()
        {
            foreach(var v in V)
            {
                if(v.y<2)
                {
                    BottomVert.Add(VVb[v]);                 
                }

                if(v.x<-41.7f&v.z<13.6f&v.z>-13.6f&v.y<25&v.y>2)
                {
                    DoorVert.Add(VVb[v]);
                }

                if (v.x > -41.7f & v.z < 13.6f & v.z > -13.6f & v.y < 25 & v.y > 2)
                {
                    DoorVert.Add(VVb[v]);
                }
            }
        }

        void AddRigidbody()
        {
            foreach(var v in V)
            {
                VVb[v].gameObject.AddComponent<Rigidbody>();
            }
        }

        void LockVert()
        {
            foreach(var v in BottomVert)
            {
                var p = v.transform.localPosition;
                if(p.x<13&p.x>-13&p.z<13&p.z>-13)
                {
                    var f = v.gameObject.AddComponent<FixedJoint>();
                    f.connectedBody = Center.GetComponent<Rigidbody>();
                }
            }
        }




        List<Vector3> currentPosition = new List<Vector3>();

        // Update is called once per frame
        void Update()
        {
           
            


        }

        private void FixedUpdate()
        {
            for (var i = 0; i < V.Count; i++)
            {
                var v = LVb[i];
                currentPosition.Add(v.transform.localPosition);
            }

            Main.vertices = currentPosition.ToArray();
            Shell.GetComponent<MeshFilter>().sharedMesh = Main;
        }
    }

   
}
