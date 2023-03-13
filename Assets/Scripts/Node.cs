using UnityEngine;
using System.Collections;

public class Node
{

	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public int dCost;
	public int jCost; //damage cost
	public Node parent;
	public int DamageAmount =200;
	public int DamageSecondary = 100;

	public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
	{
		walkable = _walkable;
		worldPosition = _worldPos;
		gridX = _gridX;
		gridY = _gridY;
		dCost = 0;
	}

	public int fCost
	{
		get
		{
			return gCost + hCost + dCost + jCost;
		}
	}

	public void addHit()
    {
		
		jCost += DamageAmount;
		//Debug.Log(jCost);
	}

	public void addHit(int Damage)
	{
		jCost += Damage;
	}

	public void addSecondaryHit()
	{
		//Debug.Log("HITTING");
		jCost += DamageSecondary;
	}

	public int getDmg()
    {
		return jCost;
    }

	public void decreaseCost()
    {
		jCost = jCost / 2;
    }

}