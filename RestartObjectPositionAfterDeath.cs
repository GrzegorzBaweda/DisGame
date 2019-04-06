using UnityEngine;
using System.Collections;

public class RestartObjectPositionAfterDeath : MonoBehaviour {

	public HealthManager healthManager;
	public Transform respawnPoint;
	// Use this for initialization
	void Start () {

		healthManager = FindObjectOfType<HealthManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (healthManager.isDead)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.transform.position = respawnPoint.transform.position;
			gameObject.transform.rotation = respawnPoint.transform.rotation;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D> ().isKinematic = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D> ().angularVelocity = 0;
			GetComponent<Rigidbody2D> ().isKinematic = false;
		}

	}
}
