using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace InflationManager
{
    public class EdgeObjetcs : MonoBehaviour
    {
        public List<Edge> edges;

        public void Awake()
        {
            edges = new List<Edge>();
        }

        public List<Edge> GetMeshEdges(Mesh mesh)
        {
            //HashSet<Edge> edges = new HashSet<Edge>();

            for (int i = 0; i < mesh.triangles.Length; i+= 3)
            {
                var v1 = mesh.vertices[mesh.triangles[i]];
                var v2 = mesh.vertices[mesh.triangles[i + 1]];
                var v3 = mesh.vertices[mesh.triangles[i + 2]];

                edges.Add(new Edge(v1, v2));
                edges.Add(new Edge(v1, v3));
                edges.Add(new Edge(v2, v3));
            }

            return edges;
        }
    }
}