using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private PlayerController player;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	public int pointPenaltyOnDeath;

	private float gravityStore;

	public HealthManager healthManager;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();

		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		if(FindObjectOfType<Camera2DFollow>() != null) FindObjectOfType<Camera2DFollow> ().target = player.gameObject.transform;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		player.enabled = true;
		player.transform.parent = null;
		player.GetComponent<Renderer> ().enabled = true;
		healthManager.FullHealth ();
		//if (FindObjectOfType<AdsOnLvl> ()) 
		//{
		//	FindObjectOfType<AdsOnLvl> ().deaths++;
		//}
		healthManager.isDead = false;

	}
}
