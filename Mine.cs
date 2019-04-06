using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float time;
	public bool isActive;
	public PlayerController player;

	public int damageToGive;
	
	public int pointPenalty;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		isActive = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		time -= Time.deltaTime;
			if(time <= 0)
		{
			isActive = true;
			//GetComponent<AudioSource>().Play;

		}


	}
	//void OnTriggerEnter2D(Collider2D other)
	//{
		
	//	if (other.name == "Player" && isActive == true) {
	//		ScoreManager.AddPoints (-pointPenalty);
	//		HealthManager.HurtPlayer (damageToGive);
	//		player.hitted = true;
	//		Destroy(gameObject);
	//	} else {
	//		return;
	//	}
	//}
	void OnTriggerStay2D(Collider2D other)
	{
		
		if (other.name == "Player" && isActive == true) {
			ScoreManager.AddPoints (-pointPenalty);
			HealthManager.HurtPlayer (damageToGive);
			player.hitted = true;
			isActive = false;
			Destroy(this.gameObject);
		} 
	}
}
