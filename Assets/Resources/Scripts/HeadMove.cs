using UnityEngine;
using System.Collections;

public class HeadMove : MonoBehaviour {

	GameObject Controller;
	SnakeControl snake;
	int ActualPos = 0;
	int ActualZ = 0;
	int[] timer;
	bool[] move;

	void Start ()
	{
		Controller = GameObject.Find ("GameManager");
		timer = new int[100];
		move = new bool[4];
		snake = Controller.GetComponent<SnakeControl> ();
	}

	void Update () 
	{
		timer[0]--;
		timer[1]--;
		timer[2]--;
		timer[3]--;
		if(move [0] && ActualPos > 0 && timer[0] <= 0) 
		{
			ActualPos -= 1;
			timer[0] = 10;
		}
		else if(move [1] && ActualPos < 31 && timer[1] <= 0)
		{
			ActualPos += 1;
			timer[1] = 10;
		}
		else if(move [2]  && ActualZ < 16 && timer[2] <= 0)
		{
			ActualZ += 1;
			timer[2] = 10;
		}
		else if(move [3]  && ActualZ > 0 && timer[3] <= 0)
		{
			ActualZ -= 1;
			timer[3] = 10;
		}
		transform.position = new Vector3 (snake.gridX[ActualPos], 1, snake.gridY[ActualZ]);
		if(Input.GetKey (KeyCode.A) && ActualPos > 0 && timer[0] <= 0)
		{
			move[0] = true;
			move[1] = false;
			move[2] = false;
			move[3] = false;
		}
		if(Input.GetKey (KeyCode.D) && ActualPos < 31 && timer[1] <= 0)
		{
			move[0] = false;
			move[1] = true;
			move[2] = false;
			move[3] = false;
		}
		if(Input.GetKey (KeyCode.W) && ActualZ < 16 && timer[2] <= 0)
		{
			move[0] = false;
			move[1] = false;
			move[2] = true;
			move[3] = false;
		}
		if(Input.GetKey (KeyCode.S) && ActualZ > 0 && timer[3] <= 0)
		{
			move[0] = false;
			move[1] = false;
			move[2] = false;
			move[3] = true;
		}

		Debug.Log("X: " + ActualPos + " Y: " + ActualZ);
	}
}
