using UnityEngine;
using System.Collections;

public class FlyerEnemyMove : MonoBehaviour {

	private PlayerController thePlayer;

	public float moveSpeed;
	public float playerRange;

	public LayerMask playerLayer;

	public bool playerInRange;
	public float lifeTime;
	public GameObject impactEffect;
	// Use this for initialization

	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);

		if (playerInRange) {
			transform.parent = null;
			transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
			lifeTime -= Time.deltaTime;
			
			if (lifeTime < 0) {
				Instantiate (impactEffect, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.DrawSphere(transform.position, playerRange);
	}
}
