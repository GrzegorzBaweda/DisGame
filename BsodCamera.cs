using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class BsodCamera : MonoBehaviour {

	public GameObject player;
	public GameObject camera;
	public Transform cameraPlace;
	static bool blocked;
	static float saveSize;
	public GameObject mainHUD;
	public bool unlocking;
	public bool OnOff;
	public AudioSource muzyka;
	public static float muzykaVolume;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		camera = GameObject.Find ("Main Camera");
		mainHUD = GameObject.Find ("Main HUD");
		muzykaVolume = muzyka.volume;
	}
	
	// Update is called once per frame
	void Update () {

		if (blocked) 
		{
			camera.transform.position = cameraPlace.transform.position;
			camera.GetComponent<Camera> ().orthographicSize = 21f;
			camera.GetComponent<Camera2DFollow> ().enabled = false;
			mainHUD.SetActive (false);
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.name == "Player")
		{
			if (OnOff == true) 
			{
				
				muzyka.volume = 0f;
				saveSize = camera.GetComponent<Camera> ().orthographicSize;
				camera.transform.position = cameraPlace.transform.position;
				camera.transform.parent = cameraPlace.transform;
				blocked = true;
			}

			if (OnOff == false) 
			{
				muzyka.volume = muzykaVolume;
				blocked = false;
				camera.transform.position = player.transform.position;
				camera.transform.parent = null;
				camera.GetComponent<Camera> ().orthographicSize = saveSize;
				camera.GetComponent<Camera2DFollow> ().enabled = true;
				mainHUD.SetActive (true);
			}

		}

	}
}
