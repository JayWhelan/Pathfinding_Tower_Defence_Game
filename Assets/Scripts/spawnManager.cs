using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public Spawner spawn1, spawn2, spawn3;
    public Pathfinding pf1, pf2, pf3;
    public int level;
    float timeTaken, initTime;
    float damageTaken;
    private IEnumerator coroutine1;

    // Start is called before the first frame update
    void Start()
    {
        coroutine1 = spawn1.spawnWave(5, 3);
        StartCoroutine(coroutine1);
        coroutine1 = spawn1.spawnWaveRec(10, 1, 10,2);
        StartCoroutine(coroutine1);
        coroutine1 = spawn2.spawnWaveRec(10, 1, 10, 2);
        StartCoroutine(coroutine1);
        coroutine1 = spawn3.spawnWaveRec(10, 1, 10, 2);
        StartCoroutine(coroutine1);

    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(totalDamageDealt);
    }
}
