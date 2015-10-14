using UnityEngine;
using System.Collections;

public class BodyMove : MonoBehaviour 
{

	public bool[] move;
	GameObject Controller;
	GameObject Head;
	SnakeControl snake;
	float speed = 0.1f;

	void Start () 
	{
		Controller = GameObject.Find ("GameManager");
		snake = Controller.GetComponent<SnakeControl> ();
		Head = GameObject.Find ("SnakeHead");
		move = new bool[4];
		move[0] = Head.GetComponent<HeadMove>().move[0];
		move[1] = Head.GetComponent<HeadMove>().move[1];
		move[2] = Head.GetComponent<HeadMove>().move[2];
		move[3] = Head.GetComponent<HeadMove>().move[3];
	}
	
	void Update () 
	{
		if(move [0] && transform.position.x >= -2){
			transform.position -= new Vector3(speed,0,0);
		}else if(transform.position.x < -2){
			transform.position = new Vector3(snake.gridX[31]+2, 1, transform.position.z);
		}
		if(move [1] && transform.position.x <= snake.gridX[31]+2){
			transform.position += new Vector3(speed,0,0);
		}else if(transform.position.x > snake.gridX[31]+2){
			transform.position = new Vector3(snake.gridX[0]-2, 1, transform.position.z);
		}
		if(move [2] && transform.position.z <= snake.gridY[16]+2){
			transform.position += new Vector3(0,0,speed);
		}else if(transform.position.z > snake.gridY[16]+2){
			transform.position = new Vector3(transform.position.x, 1, snake.gridY[0]-2);
		}
		if(move [3] && transform.position.z >= snake.gridY[0]-2){
			transform.position -= new Vector3(0,0,speed);
		}else if(transform.position.z < snake.gridY[0]-2){
			transform.position = new Vector3(transform.position.x, 1,  snake.gridY[16]+2);
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Trigger1")
		{
			move[0] = true;
			move[1] = false;
			move[2] = false;
			move[3] = false;
		}
		if(coll.gameObject.tag == "Trigger2")
		{
			move[0] = false;
			move[1] = true;
			move[2] = false;
			move[3] = false;
		}
		if(coll.gameObject.tag == "Trigger3")
		{
			move[0] = false;
			move[1] = false;
			move[2] = true;
			move[3] = false;
		}
		if(coll.gameObject.tag == "Trigger4")
		{
			move[0] = false;
			move[1] = false;
			move[2] = false;
			move[3] = true;
		}
	}
}
