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
       // InvokeRepeating("spawnAgain", 1.0f, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnWave(int numEnemies, int pause)
    {
        //Debug.Log("Spawn");
        for (int i = 0; i < numEnemies; i++)
        {
            spawnAgain();
            yield return new WaitForSeconds(pause);

        }
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



    public void spawnAgain()
    {
        GameObject e = Instantiate(enemy, spawnPoint.position,Quaternion.identity);
        
    }
}
