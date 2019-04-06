using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarthusFix : MonoBehaviour {

	public float time = 0.2f;

	public KarthusUltiStartUp startUp;
	public KarthusManager manager;

	// Use this for initialization
	void Start () {

		startUp = FindObjectOfType<KarthusUltiStartUp> ();
		manager = FindObjectOfType<KarthusManager> ();
	}

	// Update is called once per frame
	void Update () {


		time -= Time.deltaTime;
		if (time <= 0) 
		{
			manager.lifeTime = 0.1f;
			startUp.lifeTime = 11;
			Destroy (gameObject);
		}
	}
}
