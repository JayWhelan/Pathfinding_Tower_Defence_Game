using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{

    public int money = 0;
    // list 1 = turret 1, 2 = turret 2, 3 = turret 3.
    public List<int> turrets = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        turrets.Add(1);
        turrets.Add(3);
        Debug.Log("len"+turrets.Count);
        Debug.Log(turrets);
        foreach(int i in turrets)
        {
            //Debug.Log(i + " a  ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
