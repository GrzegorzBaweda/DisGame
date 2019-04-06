using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour {

	public GameObject music;
	public bool usuwanie;
	public bool nieusuwanieTaguMusic2;
	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

		if (usuwanie == false) {
			if (GameObject.FindGameObjectsWithTag ("Music").Length == 0) {
				Instantiate (music, this.transform.position, this.transform.rotation);
			} else {
			}
		}

		if (usuwanie == true) 
		{
			Destroy (GameObject.FindGameObjectWithTag ("Music"));
		}
		if (nieusuwanieTaguMusic2 == false) 
		{
			Destroy (GameObject.FindGameObjectWithTag ("Music2"));
		}

	}
}
