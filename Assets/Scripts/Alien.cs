using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public Pathfinding pf;
    public Transform target;
    GameLoop gm;
    public List<Node> path,prevPath;
    Node curr;
    int index;
    public int health = 10;
    public int damageDealt = 10;
    public int attackDmg = 10;
    public float speed = 1;
    public int pathFinder = 1;
    public int updatePath = 0;
    public bool rush = false;
    public bool isRushable = false;
    private IEnumerator updatePathTimer;

    // Start is called before the first frame update
    void Start()
    {
        
        gm = GameObject.FindGameObjectWithTag("aStar").GetComponent<GameLoop>();
        target = GameObject.FindGameObjectWithTag("target").GetComponent<Transform>();
        pf = GameObject.FindGameObjectWithTag("pathfind"+ pathFinder).GetComponent<Pathfinding>();
        //getPath();
        prevPath = new List<Node>();
        if (!rush)
        {
            getPath();
            prevPath.Add(path[0]);
            if (updatePath > 0)
            {
                StartCoroutine(updatePathCall(updatePath));
            }
        }
       
        index = 0;
        //InvokeRepeating("getPath", 2.0f, 2.0f);
     
    }

    public IEnumerator updatePathCall(int time)
    {
        yield return new WaitForSeconds(time);

        getPath();

        StartCoroutine(updatePathCall(updatePath));
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        transform.LookAt(target);

        // Debug.Log("work");
        if (path != null && path.Count > 0 && path.Count > index)
        {
            
            if (Vector3.Distance(transform.position, path[index].worldPosition) < 1f)
            {
                prevPath.Add(path[index]);
                index++;
            }
            if (path.Count > index)
            {
                curr = path[index];

               // Debug.Log("ALIEN CURR jCost: " + curr.jCost + " fcost  "+ curr.gCost+" world pos  " + curr.worldPosition);
                //Debug.Log(curr.worldPosition);
                transform.position = Vector3.MoveTowards(transform.position, curr.worldPosition, speed/10);
            }
        }


        //getPath();
        if (transform.position != null && target.position != null)
        {
            if (Vector3.Distance(transform.position, target.position) < 3f)
            {
                prevPath.Add(path[index]);
                //damage here
                if (isRushable)
                {
                    gm.successPath(prevPath, pathFinder);
                }

                gm.towerHit(attackDmg);
                Destroy(this.gameObject);
            }
        }
    }

    void getPath()
    {
       
        index = 0;  
        path = pf.FindPath(transform.position, target.position);

    }


        public void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "bullet")
            {
            if (curr != null)
            {
                //Debug.Log("DYING  CURR jCost: " + curr.jCost + " fcost  " + curr.gCost + " world pos  " + curr.worldPosition);
                // health -= 5;
                float damage = other.GetComponent<Bullet>().damage;
                health -= (int)damage;
                curr.addHit();
                //Debug.Log("HIT");
            }
               
            if (health <= 0)
            {
                if (curr != null)
                {
                    //Debug.Log("DYING CURR jCost: " + curr.jCost + " fcost  " + curr.gCost + " world pos  " + curr.worldPosition);
                    // health -= 5;
                    float damage = other.GetComponent<Bullet>().damage;
                    health -= (int)damage;
                    curr.addHit();
                    bigHit();
                    //Debug.Log("HITD");
                }
                Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
           
    }

    public void bigHit()
    {
        if (curr != null)
        {
            //Debug.Log("DYING  CURR jCost: " + curr.jCost + " fcost  " + curr.gCost + " world pos  " + curr.worldPosition);
           
            curr.addHit();
            List<Node> nodeN = pf.getNeighbourNodes(curr);
            foreach (Node node in nodeN)
            {
                node.addSecondaryHit();
            }
        }
    }

}
