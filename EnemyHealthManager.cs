using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	public GameObject deathEffect;

	public int pointsOnDeath;

	private bool died;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0 && died == false)
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(pointsOnDeath);
			GetComponent<AudioSource> ().pitch = 1f;
			if (this.GetComponent<EnemyHealthBar> ()) {
				this.GetComponent<EnemyHealthBar> ().giveDmg (0);
			}
			died = true;
			Destroy(gameObject);
		}
	
	}

	public void giveDamage (int damageToGive)
	{
		
		enemyHealth -= damageToGive;
		GetComponent<AudioSource> ().pitch += 0.1f;
		GetComponent<AudioSource> ().Play ();

		if (this.GetComponent<EnemyHealthBar> () == true)
		{
			if(this.GetComponent<EnemyHealthBar> ().hitted != true) //jesli pierwszy raz
			{
				
				this.GetComponent<EnemyHealthBar> ().hitted = true;
			}

			this.GetComponent<EnemyHealthBar> ().giveDmg (enemyHealth);

		}
	}
}
