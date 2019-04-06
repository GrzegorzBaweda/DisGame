using UnityEngine;
using System.Collections;

public class MovingOnTouch : MonoBehaviour {

	public GameObject platform;
	
	public float moveSpeed;
	
	public Transform currentPoint;
	
	public Transform[] points;
	
	public int pointSelection;

	public bool On;
	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
		
	}
	
	// Update is called once per frame
	void Update () {
		if (On == true) {

		
		
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		
			if (platform.transform.position == currentPoint.position) {
				pointSelection ++;
				if (pointSelection == points.Length) {
					pointSelection = 0;
				}
				currentPoint = points [pointSelection];
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

			if (other.name == "Player")
			{
			

				On = true;}

		
	}
}
