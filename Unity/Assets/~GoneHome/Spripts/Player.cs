using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[] - Brackets
{} - Braces
() - Prenthesis
clean code = CTRL + K + D
Fold code =  CTRL + M + O
Unfold code = CTRL + M + P
*/
namespace GoneHome
{
    public class Player : MonoBehaviour
    {
        public string message = "hello world";
        public Rigidbody rigid;

        float speed = 5;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                rigid.AddForce(Vector3.forward * speed);
            }

        }

    }
}