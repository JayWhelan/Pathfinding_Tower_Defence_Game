using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 startPos;

    public float damage = 5;
    public int travelDistance = 8;


    void Start()
    {
        startPos = this.transform.position;
    }

   
    void Update()
    {
        if( Vector3.Distance(startPos, transform.position) > travelDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
