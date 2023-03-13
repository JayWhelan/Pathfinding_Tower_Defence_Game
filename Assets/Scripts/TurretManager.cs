using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class TurretManager : MonoBehaviour
{
    public TurretHolder[] turrets;
    public int maxTurrets = 3;
    private int currTurrets;

    public GameObject turr1E,turr1F,turr2E,turr2F,turr3E,turr3F;

    // Start is called before the first frame update
    void Start()
    {
        turr1E.SetActive(false);
        turr2E.SetActive(false);
        turr3E.SetActive(false);
        turr1F.SetActive(true);
        turr2F.SetActive(true);
        turr3F.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool canSpawn()
    {
        turretUpdate();
        

        if (currTurrets < maxTurrets)
        {
            
            return true;
        }
        return false;
    }

    public void turretUpdate()
    {
        currTurrets = GameObject.FindGameObjectsWithTag("turret").Length;
        updateUI();
    }

    public void turretUpdateRemoved()
    {
        currTurrets -= 1;
        updateUI();
    }

    public void updateUI()
    {

        if(currTurrets == 0)
        {
            turr1E.SetActive(false);
            turr2E.SetActive(false);
            turr3E.SetActive(false);
            turr1F.SetActive(true);
            turr2F.SetActive(true);
            turr3F.SetActive(true);
        }
        else if (currTurrets == 1)
        {
            turr1E.SetActive(false);
            turr2E.SetActive(false);
            turr3E.SetActive(true);
            turr1F.SetActive(true);
            turr2F.SetActive(true);
            turr3F.SetActive(false);
        }
        else if (currTurrets == 2)
        {
            turr1E.SetActive(false);
            turr2E.SetActive(true);
            turr3E.SetActive(true);
            turr1F.SetActive(true);
            turr2F.SetActive(false);
            turr3F.SetActive(false);
        }
        else if (currTurrets == 3)
        {
            turr1E.SetActive(true);
            turr2E.SetActive(true);
            turr3E.SetActive(true);
            turr1F.SetActive(false);
            turr2F.SetActive(false);
            turr3F.SetActive(false);
        }
    }
}
