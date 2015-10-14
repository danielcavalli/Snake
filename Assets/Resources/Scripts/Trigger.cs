using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour 
{

	GameObject Head;
	int res;
	
	void Start () 
	{
		Head = GameObject.Find("SnakeHead");
		res = Head.GetComponent<HeadMove>().parts;
	}
	
	void Update () 
	{
		if(res <= 0)
		{
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.name == "SnakeBody")
		{
			res--;
		}
	}
}
