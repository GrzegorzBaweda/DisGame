using UnityEngine;
using System.Collections;

public class BossFightRewards : MonoBehaviour {

	public GameObject barrier1;
	public GameObject barrier2;
	public GameObject barrier3;
	public GameObject barrier4;


	public EnemyHealthManager bossHealth;
	private int maxHealth;
	// Use this for initialization
	void Start () {
		maxHealth = bossHealth.enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (bossHealth.enemyHealth <= maxHealth * 0.9) 
		{
			Destroy(barrier1);
		}

		if (bossHealth.enemyHealth <= maxHealth * 0.75) 
		{
			Destroy(barrier2);
		}
		if (bossHealth.enemyHealth <= maxHealth * 0.5 && FindObjectOfType<CassiopeiaScript> ().fazeSwitch == false ) 
		{
			Destroy(barrier3);
			FindObjectOfType<CassiopeiaScript>().nitroFaze = true;
			Destroy(gameObject);
		}

		if (bossHealth.enemyHealth <= 0) 
		{
			FindObjectOfType<CassiopeiaScript>().deadEnd = true;
		}
	}
}
