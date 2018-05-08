using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour

    {

        public GameObject bulletPrefab;
        public float bulletspeed = 20f;
        public float shootrate = 0.2f;

        private float shootTimer = 0f;


        void Shoot()
        {
            // Create bullet clone
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //grab rigidbod from clone
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
            // Add a force to bullet (bulletspeed)
            rigid.AddForce(transform.up * bulletspeed, ForceMode2D.Impulse);
        }
        void Update()
        {
            // SET shoottimer = shoottimer + delta time
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootrate) ;
            {
                //spacebar is down
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //call shot()
                    Shoot();
                    shootTimer = 0f;
                }
            }
        }

    }
}
