using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class TurretManager : MonoBehaviour
{
    public TurretHolder[] turrets;
    public int maxTurrets = 3;
    private int currTurrets;

    // Start is called before the first frame update
    void Start()
    {
        
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

    private void turretUpdate()
    {
        currTurrets = GameObject.FindGameObjectsWithTag("turret").Length;
    }
}
