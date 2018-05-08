using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        public float speed = 20f;
        public float rotationSpeed = 360f;

        private Rigidbody2D rigid;

        void Start()
        {

            rigid = GetComponent<Rigidbody2D>();

        }


        // Update is called once per frame

        void Update()
        {
            //Check if a pressed
            if (Input.GetKey(KeyCode.A))
            {
                //Rotate left
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            //Check if d pressed
            if (Input.GetKey(KeyCode.D))
            {
                //Rotate Right
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
            //Check if w pressed
            if (Input.GetKey(KeyCode.W))
            {
                //Move in facing direction
                rigid.AddForce(transform.up * speed);
            }
            //Check if s pressed
            if (Input.GetKey(KeyCode.S))
            {
                rigid.AddForce(-transform.up * speed);
            }
        }
    }
}
