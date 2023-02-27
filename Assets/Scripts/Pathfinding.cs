using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{

	public Transform seeker, target;
	GridManager grid;
	Node startNode;
	Node targetNode;
	Node nextNode;
	List<Node> openSet;
	HashSet<Node> closedSet;
	List<Node> path;
	public int gridMan = 1;

	void Awake()
	{
		GameObject tmp = GameObject.FindGameObjectWithTag("pathfind"+ gridMan);
		grid = tmp.GetComponent<GridManager>();
		
	}

	void Update()
	{
		//FindPath(seeker.position, target.position);

	}

    private void FixedUpdate()
    {
		/*
		if (path != null && path[0] != null)
		{
			Node curr = path[0];
			Debug.Log(curr.worldPosition);
			seeker.position = Vector3.MoveTowards(seeker.position, curr.worldPosition, 0.1f);
		}
		*/
	}

	

	public List<Node> FindPath(Vector3 startPos, Vector3 targetPos)
	{
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);
		List<Node> targetNodes = new List<Node>();

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

        

		while (openSet.Count > 0)
		{
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
				targetNodes = RetracePath(startNode, targetNode);
				return targetNodes; 
			}

			foreach (Node neighbour in grid.GetNeighbours(node))
			{
				if (!neighbour.walkable || closedSet.Contains(neighbour))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour) + node.jCost;
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
		return null;
	}
	


	List<Node> RetracePath(Node startNode, Node endNode)
	{
		path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		grid.path = path;
		return path;
	}

	public List<Node> getNeighbourNodes(Node n)
    {
		if (n != null) return grid.GetNeighbours(n);
		return null;
    }

	int GetDistance(Node nodeA, Node nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}

   public void addHitOnWorldPoint(Vector3 positionHit)
    {

    }

	public float totalDamageDealt()
    {
		float dmgTaken = 0;
		List<Node> allNodes = new List<Node>();
		allNodes = grid.getAllNodes();
		foreach (Node n in allNodes) { 
			dmgTaken += n.getDmg();
        }
		return dmgTaken;
	}
}