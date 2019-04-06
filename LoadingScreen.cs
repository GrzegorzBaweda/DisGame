using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

	public string levelToLoad;
	public AudioSource glosLektora;



	// Use this for initialization
	void Start () {
		glosLektora.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (glosLektora.isPlaying == false)
		{
			Application.LoadLevel (levelToLoad);
		}
	}
}
