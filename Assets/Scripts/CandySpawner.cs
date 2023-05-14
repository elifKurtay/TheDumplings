using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawners;
    [SerializeField] List<GameObject> candies;

    //private float spawnLevel = 0f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn() {
        // check spawn level to decide amount of candies
        for (int i = 0; i < 5; i++)
        {
            int spawnerInd = Random.Range(0, spawners.Count);
            int candyInd = Random.Range(0, candies.Count);
            Instantiate(candies[candyInd], spawners[spawnerInd].position, Quaternion.identity);
        }
    }
}
