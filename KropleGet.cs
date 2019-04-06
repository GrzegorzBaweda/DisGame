using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KropleGet : MonoBehaviour {

	public TextBoxManager theTextBox;
	public int order;


	public string levelToLoad;

	public string levelTag;
	public ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxManager> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
			if (theTextBox.generalOrder > order) 
			{
			ScoreManager.saveScore ();
			PlayerPrefs.SetInt (levelTag, 1);
			Application.LoadLevel(levelToLoad);
			}
		}




		
}
