using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;
	public float waitForAnotherHit;
	
	private float waitSetting = 0.1f;
	public int pointPenalty;

	public float invicibleTimeAfterHurt;
	public bool hittedPlayer;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		waitForAnotherHit -= Time.deltaTime;
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") 
		{
			if(waitForAnotherHit <0) 
			{
				hittedPlayer = true;
				ScoreManager.AddPoints (-pointPenalty);
				HealthManager.HurtPlayer(damageToGive);
				//playercontroler.HurtCollider(cośtam);
				hittedPlayer = false;
				waitForAnotherHit = waitSetting;

			}
			other.GetComponent<AudioSource>().Play ();

			var player = other.GetComponent<PlayerController> ();

			player.hitted = true;

				player.knockbackCount = player.knockbackLength;

			if(other.transform.position.x  < transform.position.x)
			{
				player.knockFromRight = true;

			}
			else
			{
				player.knockFromRight = false;

			}
		}
	}



}
