using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] asteroidPrefabs; // the asteroid sprites
        public float spawnrate = 1f; //spawnrate
        public float spawnradius = 5f; // radius of spawn

        void Spawn()
        {
            //randomise position
            Vector3 rand = Random.insideUnitSphere * spawnradius;
            //Cancel z axis
            rand.z = 0f;
            // Generate position Random
            Vector3 position = transform.position + rand;
            // Generate number into prefabs
            int randIndex = Random.Range(0, asteroidPrefabs.Length);
            // Get Rand asteroid
            GameObject randAsteroid = asteroidPrefabs[randIndex];
            // clone rand asteroid
            GameObject clone = Instantiate(randAsteroid);
            // Clone position
            clone.transform.position = position;


        }
        void Start()
        {
            // Calls a function a specified amount of times
            InvokeRepeating("Spawn", 0, spawnrate);
        }
    }

}

