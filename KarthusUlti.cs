using UnityEngine;
using System.Collections;

public class KarthusUlti : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		{

			if (other.tag == "Enemy") {
				//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
				//Destroy(other.gameObject);
				//ScoreManager.AddPoints(pointsForKill);
				
				other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			}

		}
	}
}
