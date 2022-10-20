using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHolder : MonoBehaviour
{
    public GameObject[] Turrets;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(Turrets[1], spawnPoint.transform.position, spawnPoint.transform.rotation);
       // Debug.Log("working");
    }
}
