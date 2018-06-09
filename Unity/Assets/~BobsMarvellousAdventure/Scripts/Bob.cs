using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BobsMarvellousAdventure

{
    public class Bob : MonoBehaviour
    {
        public float bobspeed; //Player speed
        public Vector2 jumpHeight; //jump height
        public float maxSpeed;
        private Rigidbody2D rb2d;

        private void Start()
        {
            //reference to rigidbody2d
            rb2d = GetComponent<Rigidbody2D>();
           
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Input.GetAxis("Horizontal"), 0, 0);

            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity.magnitude, maxSpeed);
        }

    }
}
