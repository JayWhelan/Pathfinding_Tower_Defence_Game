using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHolder : MonoBehaviour
{
    public GameObject[] Turrets;
    public Transform spawnPoint;
    TurretManager TurrManager;
    bool TurretActive = false;
    GameObject thisTurret;

    // Start is called before the first frame update
    void Start()
    {
        TurrManager = GameObject.FindGameObjectWithTag("aStar").GetComponent<TurretManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!TurretActive)
        {
            if (TurrManager != null)
            {
                if (TurrManager.canSpawn())
                {
                    thisTurret = Instantiate(Turrets[1], spawnPoint.transform.position, spawnPoint.transform.rotation);
                    TurretActive = true;
                }
            }

        }
        else
        {
                
            Destroy(thisTurret);
            thisTurret = null;
            TurretActive = false;
            Debug.Log(" TURRETS spawn aleady");
        }
        //Instantiate(Turrets[1], spawnPoint.transform.position, spawnPoint.transform.rotation);
        //Debug.Log("MAX TURRETS");
    }
}
