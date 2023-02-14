using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] enemies;
    public int currEnemy = 0;
    public GameObject enemy;
    public Transform spawnPoint;
    public GameLoop gameLoop;
    

    void Start()
    {
        gameLoop = GameObject.FindGameObjectWithTag("aStar").GetComponent<GameLoop>();
    }

    public IEnumerator spawnWave(int numEnemies, int pause)
    {
        //Debug.Log("Spawn");
        for (int i = 0; i < numEnemies; i++)
        {
            spawnAgain();
            yield return new WaitForSeconds(pause);

        }
        gameLoop.levelComplete();

    }

    public IEnumerator spawnWaveRec(int numEnemies, int pause, int numWaves, int pauseWave)
    {
        for (int j = 0; j < numWaves; j++)
        {
           
            yield return new WaitForSeconds(pauseWave);
            for (int i = 0; i < numEnemies; i++)
            {
                spawnAgain();
                yield return new WaitForSeconds(pause);

            }
        }
    }

    public void increaseEnemy()
    {
        if (enemies.Length > currEnemy)
        {
            currEnemy++;
        }
        else
        {
            currEnemy = enemies.Length - 1;
        }
    
    }

    public void spawnAgain()
    {
        GameObject e = Instantiate(enemies[currEnemy], spawnPoint.position,Quaternion.identity);
        
    }
}
