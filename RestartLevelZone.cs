using UnityEngine;
using System.Collections;

public class RestartLevelZone : MonoBehaviour {

	public LifeManager lifeManager;

	public bool isInZone;
	public GameObject text;

	// Use this for initialization
	void Start () {
	
		lifeManager = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isInZone && Input.GetButton ("Fire3")) 
		{
			Application.LoadLevel  (lifeManager.mainMenu);
		}
	

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			isInZone = true;
			text.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") {
			isInZone = false;
			text.SetActive(false);
		}
	}
}
