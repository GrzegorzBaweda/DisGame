using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour {

	public GameObject music;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag ("Music2").Length == 0) 
		{
			Instantiate (music, this.transform.position, this.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
