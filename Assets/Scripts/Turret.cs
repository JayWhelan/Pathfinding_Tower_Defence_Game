using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject bullet;
    public Transform[] guns;
    GameObject[] enemies;
    bool inRange;
    GameObject target;
    Quaternion defaultRotation;
    Vector3 defaultDirection;
    public float fireRate = 1f;
    float fireReady = 0f;
    float fireReady2 = 0f;
    List<GameObject> targets;
    public float turnSpeed =1;
    public float bulletSpeed = 1500;
    public float damageAmt;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("alien");
        defaultDirection = transform.forward;
        defaultRotation = transform.rotation;
        //target = enemies[0];
        targets = new List<GameObject>();
        foreach(GameObject go in enemies)
        {
            targets.Add(go);
        }
        if(targets.Count > 0) target = enemies[0];
        InvokeRepeating("refreshEnemies", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection;
        float singleStep;
        Vector3 newDirection;
        //Debug.Log(enemies.Length);
        if (targets.Count > 0)
        {
            foreach (GameObject e in targets)
            {
                if (e != null && e.gameObject != null)
                {
                    if (target == null || target.gameObject == null)
                    {
                        target = e;
                    }
                    else if (Vector3.Distance(transform.position, e.transform.position) < Vector3.Distance(transform.position, target.transform.position))
                    {
                        target = e;

                    }
                }
            }

            if (target != null)
            {
                Vector3 targetDir = target.transform.position - transform.position;
                float angle = Vector3.Angle(targetDir, defaultDirection);
               

                //Debug.Log(angle);
                if ((Vector3.Distance(transform.position, target.transform.position) > 12f) || (angle > 100))
                {
                    targetDirection = Vector3.forward;

                    // The step size is equal to speed times frame time.
                    singleStep = turnSpeed * Time.deltaTime;

                    // Rotate the forward vector towards the target direction by one step
                    newDirection = Vector3.RotateTowards(transform.forward, defaultDirection, singleStep, 0.0f);

                    // Calculate a rotation a step closer to the target and applies rotation to this object
                    transform.rotation = Quaternion.LookRotation(newDirection);

                }
                else
                {

                    targetDirection = target.transform.position - transform.position;

                    targetDirection.y = 0.0f;
                    // The step size is equal to speed times frame time.
                    singleStep = 1 * Time.deltaTime;

                    // Rotate the forward vector towards the target direction by one step
                    newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                    // Calculate a rotation a step closer to the target and applies rotation to this object
                    transform.rotation = Quaternion.LookRotation(newDirection);

                    if (Time.time > fireReady)
                    {
                        fireReady = Time.time + fireRate;
                        GameObject bull;
                        foreach (Transform t in guns)
                        {
                            bull = Instantiate(bullet, t.transform.position, Quaternion.identity);
                            bull.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                            bull.GetComponent<Bullet>().damage = damageAmt;
                        }
                    }
                }
            }
            else
            {
                targetDirection = Vector3.forward;

                // The step size is equal to speed times frame time.
                singleStep = 1 * Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                newDirection = Vector3.RotateTowards(transform.forward, defaultDirection, singleStep, 0.0f);

                // Calculate a rotation a step closer to the target and applies rotation to this object
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "alien")
        {
            
            targets.Add(other.gameObject);
        }
    }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "alien")
            {
                targets.Remove(other.gameObject);


            }
        }


        void refreshEnemies()
        {

       // Debug.Log("eemy num"+GameObject.FindGameObjectsWithTag("alien").Length);
            enemies = GameObject.FindGameObjectsWithTag("alien");
        foreach (GameObject go in enemies)
        {
            targets.Add(go);
        }
    }
    }
