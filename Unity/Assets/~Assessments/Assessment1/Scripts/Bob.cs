﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BobsMarvellousAdventure

{
    public class Bob : MonoBehaviour
    {
        public float bobspeed; //Player speed
        public Vector2 jumpHeight; //jump height
        public float maxSpeed = 5;
        private Rigidbody2D rb2d;

        private bool isGrounded = false;

        private void Start()
        {
            //reference to rigidbody2d
            rb2d = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            if (isGrounded == true)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
                }
            }

            Vector3 force = Vector3.right * Input.GetAxis("Horizontal") * maxSpeed;
            rb2d.AddForce(force);

        }
        void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
        void OnCollisionExit2D (Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }



    }
}
