using UnityEngine;
using System.Collections;

public class HeadMove : MonoBehaviour {
	
	GameObject Controller;
	SnakeControl snake;
	GameObject Body;
	GameObject[] Trigger;
	int ActualPos = 0;
	int ActualZ = 0;
	int[] timer;
	public bool[] move;
	float speed = 0.1f;
	public int parts = 1;
	
	void Start ()
	{
		Controller = GameObject.Find ("GameManager");
		Trigger = new GameObject[5];
		Body = Resources.Load ("Prefabs/SnakeBody") as GameObject;
		Trigger[1] = Resources.Load ("Prefabs/Trigger1") as GameObject;
		Trigger[2] = Resources.Load ("Prefabs/Trigger2") as GameObject;
		Trigger[3] = Resources.Load ("Prefabs/Trigger3") as GameObject;
		Trigger[4] = Resources.Load ("Prefabs/Trigger4") as GameObject;
		timer = new int[100];
		move = new bool[4];
		snake = Controller.GetComponent<SnakeControl> ();
		move[0] = false;
		move[1] = false;
		move[2] = false;
		move[3] = false;
	}
	
	void Update () 
	{
		//|||||||||||||||||||||||||||||||||||||||
		if(move [0] && transform.position.x >= -2)
		{
			transform.position -= new Vector3(speed,0,0);
		}
		else if(transform.position.x < -2)
		{
			transform.position = new Vector3(snake.gridX[31]+2, 1, transform.position.z);
		}
		//|||||||||||||||||||||||||||||||||||||||
		if(move [1] && transform.position.x <= snake.gridX[31]+2)
		{
			transform.position += new Vector3(speed,0,0);
		}
		else if(transform.position.x > snake.gridX[31]+2)
		{
			transform.position = new Vector3(snake.gridX[0]-2, 1, transform.position.z);
		}
		
		//|||||||||||||||||||||||||||||||||||||||
		//|||||||||||||||||||||||||||||||||||||||
		//|||||||||||||||||||||||||||||||||||||||
		
		if(move [2] && transform.position.z <= snake.gridY[16]+2)
		{
			transform.position += new Vector3(0,0,speed);
		}
		else if(transform.position.z > snake.gridY[16]+2)
		{
			transform.position = new Vector3(transform.position.x, 1, snake.gridY[0]-2);
		}
		//|||||||||||||||||||||||||||||||||||||||
		if(move [3] && transform.position.z >= snake.gridY[0]-2)
		{
			transform.position -= new Vector3(0,0,speed);
		}
		else if(transform.position.z < snake.gridY[0]-2)
		{
			transform.position = new Vector3(transform.position.x, 1,  snake.gridY[16]+2);
		}
		if(Input.GetKeyDown (KeyCode.A) && !move[1] && !move[0])
		{
			move[0] = true;
			move[1] = false;
			move[2] = false;
			move[3] = false;
			if(parts >0)
				Instantiate(Trigger[1], transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown (KeyCode.D) && !move[0] && !move[1])
		{
			move[0] = false;
			move[1] = true;
			move[2] = false;
			move[3] = false;
			if(parts >0)
				Instantiate(Trigger[2], transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown (KeyCode.W) && !move[3] && !move[2])
		{
			move[0] = false;
			move[1] = false;
			move[2] = true;
			move[3] = false;
			if(parts >0)
				Instantiate(Trigger[3], transform.position, Quaternion.identity);
		}
		if(Input.GetKeyDown (KeyCode.S) && !move[2] && !move[3])
		{
			move[0] = false;
			move[1] = false;
			move[2] = false;
			move[3] = true;
			if(parts >0)
				Instantiate(Trigger[4], transform.position, Quaternion.identity);
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Point")
		{
			parts++;
			if(move[0])
			{
				Instantiate(Body, new Vector3(transform.position.x + (transform.localScale.x*parts), 1, transform.position.z), Quaternion.identity);
			}
			if(move[1])
			{
				Instantiate(Body, new Vector3(transform.position.x - (transform.localScale.x*parts), 1, transform.position.z), Quaternion.identity);
			}
			if(move[2])
			{
				Instantiate(Body, new Vector3(transform.position.x, 1, transform.position.z-parts), Quaternion.identity);
			}
			if(move[3])
			{
				Instantiate(Body, new Vector3(transform.position.x, 1, transform.position.z+parts), Quaternion.identity);
			}
			Instantiate(coll.gameObject, new Vector3(Random.Range(5,35.5f), 1, Random.Range (1,19)), Quaternion.identity);
			Destroy(coll.gameObject);
		}
	}
}
