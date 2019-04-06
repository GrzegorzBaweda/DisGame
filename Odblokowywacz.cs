using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odblokowywacz : MonoBehaviour {

	public LevelSelectManager lvlSelect;

	// Use this for initialization
	void Start () {
		lvlSelect = FindObjectOfType<LevelSelectManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < lvlSelect.levelTags.Length; i++) 
		{
			lvlSelect.levelUnlocked [i] = true;
		}
		
	}
}
