using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public Spawner spawn1;
    public Pathfinding pf1;
    float timeTaken, initTime;
    float damageTaken;
    private IEnumerator coroutine1;

    // Start is called before the first frame update
    void Start()
    {
        //coroutine1 = spawn1.spawnWave(5, 3);
        //StartCoroutine(coroutine1);


    }

    public void spawnLevel(int level)
    {
        switch (level)
        {
            case 0:
                Debug.Log("level 0 ");
                Debug.Log(spawn1.currEnemy);
                coroutine1 = spawn1.spawnWave(2, 1);
                break;
            case 1:
                spawn1.increaseEnemy();
                Debug.Log("level 1");
                coroutine1 = spawn1.spawnWave(2, 1);
                break;
        }



        StartCoroutine(coroutine1);

    }
}
