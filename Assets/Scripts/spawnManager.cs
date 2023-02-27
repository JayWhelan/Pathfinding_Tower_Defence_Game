using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public Spawner spawn1, spawn2;
    public Pathfinding pf1, pf2;
    float timeTaken, initTime;
    float damageTaken;
    private IEnumerator coroutine1, coroutine2, coroutine3;
    int rushSpawnAmount = 3;

    // Start is called before the first frame update
    void Start()
    {
        //coroutine1 = spawn1.spawnWave(5, 3);
        //StartCoroutine(coroutine1);


    }

    public void spawnRush(List<Node> path, int pathFinder)
    {
        if(pathFinder == 1)
        {
            coroutine3 = spawn2.spawnRush(path, rushSpawnAmount, (float).5);
        }else if(pathFinder == 2)
        {
            coroutine3 = spawn1.spawnRush(path, rushSpawnAmount, (float).5);
        }
        StartCoroutine(coroutine3);
    }

    public void spawnLevel(int level)
    {
        switch (level)
        {
            case 0:
                coroutine1 = spawn1.spawnWave(5, 1);
                coroutine2 = spawn2.spawnWave(5, 1);
                break;
            case 1:
                coroutine1 = spawn1.spawnWave(12, 1);
                coroutine2 = spawn2.spawnWave(12, 1);
                break;
            case 2:
                spawn1.increaseEnemy();
                spawn2.increaseEnemy();
                coroutine1 = spawn1.spawnWave(14, 2);
                coroutine2 = spawn2.spawnWave(14, 2);
                break;
            case 3:
                coroutine1 = spawn1.spawnWave(18, 1);
                coroutine2 = spawn2.spawnWave(18, 1);
                break;
            case 4:
                spawn1.increaseEnemy();
                spawn2.increaseEnemy();
                coroutine1 = spawn1.spawnWave(20, (float)1.7);
                coroutine2 = spawn2.spawnWave(20, (float)1.7);
                break;
            case 5:
                coroutine1 = spawn1.spawnWave(23, 1);
                coroutine2 = spawn2.spawnWave(23, 1);
                break;
            case 6:
                spawn1.increaseEnemy();
                spawn2.increaseEnemy();
                coroutine1 = spawn1.spawnWave(27, (float)1.4);
                coroutine2 = spawn2.spawnWave(27, (float)1.4);
                break;
            case 7:
                coroutine1 = spawn1.spawnWave(31, 1);
                coroutine2 = spawn2.spawnWave(31, 1);
                break;

        }


        StartCoroutine(coroutine2);
        StartCoroutine(coroutine1);

    }
}
