using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour 
{

	int ActualPosition;
	int nextPosition;
	int rows = 32;
	int columns = 17;

	public GameObject Snake;

	public float[] gridX;
	public float[] gridY;


	
	void Start () 
	{
		gridX = new float[rows];
		gridY = new float[columns];
		for (int i = 0; i < rows; i++)
		{
			for(int j = 0;j < columns;j++)
			{
				gridX[i] = 1.1f * i;
				gridY[j] = 1.1f * j;
			}
		}
	}

	void Update () 
	{
	}
}
