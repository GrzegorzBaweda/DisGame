using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HecaKopia : MonoBehaviour {

	public int drawInt;

	public float iddleTime;
	private float waitTime;

	private Animator anim;

	public GameObject heca;

	public int tipInt;


	public float moveSpeed;

	public Transform currentPoint;

	public Transform[] points;

	public int pointSelection;

	public PlayerController player;

	// Use this for initialization
	void Start () {

		anim = heca.GetComponent<Animator> ();
		currentPoint = points [pointSelection];
		waitTime = iddleTime;
		heca.transform.localScale = new Vector3 (2f, 2f, 2f);
		pointSelection = 1;
		player = FindObjectOfType<PlayerController> ();
		drawInt =0;
	}

	// Update is called once per frame
	void Update () {

		if (pointSelection == 0) {
			heca.transform.localScale = new Vector3 (-2f, 2f, 2f);

		}
		if (pointSelection == 1) {
			heca.transform.localScale = new Vector3 (2f, 2f, 2f);
		}

		if (waitTime <= 0) 
		{
			drawInt = Random.Range (0, 3);
			print (drawInt);
			waitTime = iddleTime;


		}

		if (drawInt == 3) 
		{
			anim.SetBool ("Run", false);
			waitTime -= Time.deltaTime;
		}

		if (drawInt == 0) 
		{
			DownCharge();
		}
		if (drawInt == 1) 
		{
			MiddleCharge();
		}
		if (drawInt == 2) 
		{
			UpCharge();
		}


	}
	public void DownCharge ()
	{
		tipInt = 1;
		anim.SetBool ("Run", true);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(heca.transform.position == currentPoint.position)
		{
			pointSelection ++;

			if(pointSelection == points.Length)
			{
				pointSelection =0;
			}
			currentPoint = points[pointSelection];
			drawInt = 3;
		}
	}
	public void MiddleCharge ()
	{
		tipInt = 1;
		anim.SetBool ("Run", true);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(heca.transform.position == currentPoint.position)
		{
			pointSelection ++;

			if(pointSelection == points.Length)
			{
				pointSelection =0;
			}
			currentPoint = points[pointSelection];
			drawInt = 3;
		}
	}
	public void UpCharge ()
	{
		tipInt = 1;
		anim.SetBool ("Run", true);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(heca.transform.position == currentPoint.position)
		{
			pointSelection ++;

			if(pointSelection == points.Length)
			{
				pointSelection =0;
			}
			currentPoint = points[pointSelection];
			drawInt = 3;
		}
	}
}
