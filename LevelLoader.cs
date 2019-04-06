using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string levelToLoad;

	public string levelTag;
	public ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") 
		{
				ScoreManager.saveScore ();
			PlayerPrefs.SetInt (levelTag, 1);
			Application.LoadLevel(levelToLoad);
		}
	}
}
