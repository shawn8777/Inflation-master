using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InflationManager
{
    public struct Edge
    {
        public Vector3 a;
        public Vector3 b;


        public Edge(Vector3 v1, Vector3 v2)
        {            
            if (v1.x < v2.x || (v1.x == v2.x && (v1.y < v2.y || (v1.y == v2.y && v1.z <= v2.z))))
            {
                a = v1;
                b = v2;
                
            }
            else
            {
                a = v2;
                b = v1;
                
            }

           
        }

        //private float _scale;


        ///// <summary>
        ///// 
        ///// </summary>
        //public float Scale
        //{
        //    get { return _scale; }
        //    set
        //    {
        //        _scale = value;
        //        OnSetScale();
        //    }
        //}

    }
}
