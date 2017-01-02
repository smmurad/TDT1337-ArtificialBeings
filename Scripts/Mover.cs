using UnityEngine;
using System.Collections;
using System.Collections.Generic;		//Allows us to use Lists. 

namespace Done
{
    public class Hazard
    {
        public Vector3 speed;
        public string tag;

    }

    public class Mover : MonoBehaviour
    {
        private Rigidbody rb;

        public float down_speed;
        private float r_speed;
        private Vector3 new_speed;

        List<Vector3> hazards;

        void Awake()
        {
            hazards = new List<Vector3>();
        }

        void Start()
        {   
            rb = GetComponent<Rigidbody>();
            new_speed = transform.forward * down_speed;
            if (rb.tag == "Asteroid")
            {
                r_speed = Random.Range(-4, 4);
                new_speed += transform.right * r_speed;
            }
            //hazards.Add()
            rb.velocity = new_speed;
        }

    }
}