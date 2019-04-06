using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOnContact : MonoBehaviour {

	public HurtPlayerOnContact hurtScript;


	// Use this for initialization
	void Start () {
		hurtScript = GetComponent<HurtPlayerOnContact> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hurtScript.hittedPlayer == true) {
			hurtScript.enabled = false;
			Destroy (gameObject);
		}
	}
}
