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
    public int spawnNumber;
    

    void Start()
    {
        gameLoop = GameObject.FindGameObjectWithTag("aStar").GetComponent<GameLoop>();
    }

    
    public IEnumerator spawnWave(int numEnemies, float pause)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            spawnAgain();
            yield return new WaitForSeconds(pause);

        }
        gameLoop.levelComplete(spawnNumber);
        
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
    }

    public IEnumerator spawnRush(List<Node> setPath, int numEnemies, float pause)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            spawnRushAgain(setPath);
            yield return new WaitForSeconds(pause);

        }    
    }

    public void spawnRushAgain(List<Node> setPath)
    {
        GameObject e = Instantiate(enemies[currEnemy], spawnPoint.position, Quaternion.identity);
        Alien tmp = e.GetComponent<Alien>();
        tmp.path = setPath;
        tmp.rush = true;
    }

    public void spawnAgain()
    {
        GameObject e = Instantiate(enemies[currEnemy], spawnPoint.position,Quaternion.identity);
        Alien tmp = e.GetComponent<Alien>();
        tmp.rush = false;
    }
}
