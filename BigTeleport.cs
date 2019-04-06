using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTeleport : MonoBehaviour {

	public GameObject diody;
	public Sprite[] diodyTab;

	public int points;
	public string levelToLoad;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (points >= 3) 
		{
			if (other.name == "Player") 
			{
				Application.LoadLevel (levelToLoad);
			}
		}

	}


	 public void addPoint()
	{
		points++;
		diody.GetComponent<SpriteRenderer> ().sprite = diodyTab [points];
		if (points >= 3) 
		{
			this.GetComponent<Animator> ().SetBool ("On", true);
		}

	}

}
