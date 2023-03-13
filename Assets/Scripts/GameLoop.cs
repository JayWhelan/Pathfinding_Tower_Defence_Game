using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLoop : MonoBehaviour
{

    public healthBar healthBar;
    public float currHealth = 1000;
    public int level = 0;
    public spawnManager spawnMan;
    private IEnumerator coroutineWait;
    bool spawn1Check, spawn2Check;
    private bool isRushable = true;
    public int deadNum = 0;
    public TMP_Text gameOverText, gameOverStats;
    public GameObject pan;
    private int enemyHits = 0;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(currHealth);
        StartCoroutine(waitStart(3));
        spawn1Check = false;
        spawn2Check = false;
        pan.SetActive(false);
        gameOverText.text = " ";
        gameOverStats.text = " ";
    }

    public void levelComplete(int spawnerID)
    {
        if (spawnerID == 1) spawn1Check = true;
        if (spawnerID == 2) spawn2Check = true;

        if (spawn2Check && spawn1Check)
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
            StartCoroutine(waitRush(6));
        }
        if (level > 4)
        {
            foreach(Node n in path)
            {
                n.decreaseCost();
            }
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
        enemyHits++;

        if (currHealth <= 0)
        {
            endGame();
        }
    }

    public void enemyDeath()
    {
        deadNum++;
    }

    private void endGame()
    {
        Time.timeScale = 0f;
        pan.SetActive(true);
        gameOverText.text = "GAME OVER";
        gameOverStats.text = "You Killed " + deadNum.ToString() + " Enemies!\n"+enemyHits.ToString()+ " Enemies reached your tower.";
    }
}
