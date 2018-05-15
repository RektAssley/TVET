using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Paddle : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public Ball currentBall;
        //directions array defaults to two values
        public Vector2[] directions = new Vector2[]
        {
            new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f)
        };
        void Start()
        {
            currentBall = GetComponentInChildren<Ball>();

        }
        void Fire()
        {
            //detach as child
            currentBall.transform.SetParent(null);
            // generate random direct from list of directs
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            // Fire off ball in random direction
            currentBall.Fire(randomDir);
        }
        void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
        void Movement()
        {
            //getinput on x axis
            float inputH = Input.GetAxis("Horizontal");
            // set force to direction (inputH to decide)
            Vector3 force = transform.right * inputH;
            // apply movementSPD
            force *= Time.deltaTime;
            //apply delta time to force
            force *= Time.deltaTime;
            // addforce to position
            transform.position += force;


        }
        void Update()
        {
            CheckInput();
            Movement();

        }

    }
}