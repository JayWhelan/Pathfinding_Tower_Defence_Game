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

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(currHealth);
        StartCoroutine(waitStart(4));
    }

    public void levelComplete()
    {
        level++;
        
        StartCoroutine(waitLevel(4));
    }

    public IEnumerator waitLevel(int pause)
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("alien").Length;
        while (enemiesLeft > 0)
        {
            yield return new WaitForSeconds(pause);
            enemiesLeft = GameObject.FindGameObjectsWithTag("alien").Length;
        }
        Debug.Log("KILLED ALL");
        yield return new WaitForSeconds(pause);
        spawnMan.spawnLevel(level);

    }

    public IEnumerator waitStart(int pause)
    {

        yield return new WaitForSeconds(pause);
        spawnMan.spawnLevel(level);

    }


    public void towerHit(int dmg)
    {
        currHealth -= dmg;
        healthBar.setHealth(currHealth);
    }
}
