using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        public float speed = 5f; //ball travel speed

        private Vector3 velocity; // velocity of ball

        // ball in given direction
        public void Fire(Vector3 direction)
        {
            //Calculate velocity
            velocity = direction * speed;
        }
        //Dectect collisions
        void OnCollisionEnter2D(Collision2D other)
        {
            //grab contact point of collision
            ContactPoint2D contact = other.contacts[0];
            //calculate reflection point of ball using velocity and contact
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            //calculate new velocity from reflect multiply by same speed
            velocity = reflect.normalized * velocity.magnitude;

        }
        private void Update()
        {
            //moves ball using velocity and deltatime
            transform.position += velocity * Time.deltaTime;
        }
    }
}
