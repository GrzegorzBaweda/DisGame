using UnityEngine;
using System.Collections;

public class DestroyBulletOnCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		{
			if (other.tag == "Projectile")
			{
				//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
				//Destroy(other.gameObject);
				//ScoreManager.AddPoints(pointsForKill);
				Destroy(other);

			}


		}
}
}
