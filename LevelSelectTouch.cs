using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectTouch : MonoBehaviour {


	public LevelSelectManager theLevelSelectManager;
	public GameObject loadCanvas;
	// Use this for initialization
	void Start () {
		theLevelSelectManager = FindObjectOfType<LevelSelectManager> ();
		//loadCanvas = GameObject.Find("LoadCanvas");
		loadCanvas.SetActive (false);
		theLevelSelectManager.touchMode = true;
	}
	
	// Update is called once per frame
	public void MoveLeft()
	{
		theLevelSelectManager.sound.Play ();
		theLevelSelectManager.positionSelector -= 1;

		if (theLevelSelectManager.positionSelector < 0)
		{
			theLevelSelectManager.positionSelector = 0;
		}
	}

	public void MoveRight()
	{
		theLevelSelectManager.sound.Play ();
		theLevelSelectManager.positionSelector += 1;

		if (theLevelSelectManager.positionSelector >= theLevelSelectManager.levelTags.Length)
		{
			theLevelSelectManager.positionSelector = theLevelSelectManager.levelTags.Length - 1;
		}
	}

	public void LoadLevel()
	{
		

		if (theLevelSelectManager.levelUnlocked [theLevelSelectManager.positionSelector] ) {
			theLevelSelectManager.choiceClick.Play ();
			loadCanvas.SetActive (true);
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", theLevelSelectManager.positionSelector);
			Application.LoadLevel (theLevelSelectManager.levelName [theLevelSelectManager.positionSelector]);
		} else 
		{
			theLevelSelectManager.lockedClick.Play ();
		}




	}
}
