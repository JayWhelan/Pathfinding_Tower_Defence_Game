using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Transform spawnPoint;
    public float spawnTime;

    void Start()
    {
        InvokeRepeating("spawnAgain", 1.0f, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnAgain()
    {
        GameObject e = Instantiate(enemy, spawnPoint.position,Quaternion.identity);
        
    }
}
