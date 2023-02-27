using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{

    public healthBar healthBar;
    public float currHealth = 1000;
    public int level = 0;
    public spawnManager spawnMan;
    private IEnumerator coroutineWait;
    bool spawn1Check, spawn2Check;
    private bool isRushable = true;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(currHealth);
        StartCoroutine(waitStart(3));
        spawn1Check = false;
        spawn2Check = false;
    }

    public void levelComplete(int spawnerID)
    {
        if (spawnerID == 1) spawn1Check = true;
        if (spawnerID == 2) spawn2Check = true;

        if(spawn2Check && spawn1Check)
        {
            level++;
            //Debug.Log("Level Complete starting next level: " + level);
            StartCoroutine(waitLevel(4));

            spawn1Check = false;
            spawn2Check = false;
        }
    }

    public IEnumerator waitLevel(int pause)
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("alien").Length;
        while (enemiesLeft > 0)
        {
            yield return new WaitForSeconds(pause);
            enemiesLeft = GameObject.FindGameObjectsWithTag("alien").Length;
        }
        yield return new WaitForSeconds(pause);
        spawnMan.spawnLevel(level);

    }

    public IEnumerator waitStart(int pause)
    {

        yield return new WaitForSeconds(pause);
        spawnMan.spawnLevel(level);

    }


    public void successPath(List<Node> path, int pathFinderID)
    {
        if (isRushable)
        {
            spawnMan.spawnRush(path, pathFinderID);
            StartCoroutine(waitRush(5));
        }
    }

    public IEnumerator waitRush(int pause)
    {
        isRushable = false;
        yield return new WaitForSeconds(pause);

        isRushable = true;
    }

    public void towerHit(int dmg)
    {
        currHealth -= dmg;
        healthBar.setHealth(currHealth);
    }
}
