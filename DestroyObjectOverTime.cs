using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

	public float lifeTime;
	public GameObject impactEffect;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		lifeTime -= Time.deltaTime;

		if (lifeTime < 0) {
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	
	}
}
