using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Folding
{
    public class FoldingSystem : MonoBehaviour
    {

        [SerializeField] bool _toInflat;
        [SerializeField] float _inflateSpeed = 5f;
        public Inflation IF;
       

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (_toInflat)
            {
                IF.Inflate(_inflateSpeed);
            }
            else
            {
                IF.OffKinematic();
            }
            
        }

        //divide vertex and lock it



    }
}
