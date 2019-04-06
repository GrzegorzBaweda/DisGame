using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	

	public static int score;
	public static int weaponLvl;
	public int weaponPoints;
	public Slider weaponBar;
	public int pointsToNextLvl;
	public GameObject napisMax;
	public int scoreSave;
	void Start ()
	{
		score = 0;
		weaponLvl = 1;
		weaponBar = GetComponent<Slider> ();
		weaponPoints = 0;
		weaponBar.maxValue = pointsToNextLvl;
		napisMax.SetActive (false);
	}

	void Update ()
	{
		weaponBar.value = weaponPoints;
		if (score < 0) {
			score = 0;
			weaponPoints = score;
			napisMax.SetActive (false);
		}



		if (score <= pointsToNextLvl) {
			weaponPoints = score;
			weaponLvl = 1;
			napisMax.SetActive (false);
		}
		if ( score > pointsToNextLvl  && score <= pointsToNextLvl*2) 
		{
			weaponPoints = score-pointsToNextLvl;
			weaponLvl = 2;
			napisMax.SetActive (false);
	
		}
		if (score > pointsToNextLvl*2 && score < pointsToNextLvl*3) {
			weaponPoints = score - pointsToNextLvl*2;
			weaponLvl = 3;
			napisMax.SetActive (false);
		}

		if (score >=pointsToNextLvl*3)
		{
			score = pointsToNextLvl*3;
			weaponPoints = pointsToNextLvl;
			napisMax.SetActive (true);
		}


	}

	public static void AddPoints (int pointsToAdd)
	{
		score += pointsToAdd;
	}

	public static void Reset ()
	{
		score = 0;
	}

	public static void saveScore ()
	{
		PlayerPrefs.SetInt ("WeaponPoints" , score);
	}
}
