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
    public Light cone;

    // Start is called before the first frame update
    void Start()
    {
        TurrManager = GameObject.FindGameObjectWithTag("aStar").GetComponent<TurretManager>();
        cone.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(GameObject.ReferenceEquals(hit.transform.gameObject, this.gameObject ))
            {
                Debug.Log(hit.transform.name);
                cone.intensity = 100;
            }
            else
            {
                cone.intensity = 0;
            }
            
        }
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
            //turret already there remove
        }
        //Instantiate(Turrets[1], spawnPoint.transform.position, spawnPoint.transform.rotation);
        //Debug.Log("MAX TURRETS");
    }

}
