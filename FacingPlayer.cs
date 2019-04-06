using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour {

	public Transform playerTarget;

	// Use this for initialization
	void Start () {
		this.transform.localScale = new Vector3 (-1f, -1f, 1f);
	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = playerTarget.position - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
