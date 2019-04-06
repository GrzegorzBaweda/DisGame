using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {

	public GameObject pierwszyCredits;
	public GameObject drugiCredits;
	public GameObject obrazekMnie;

	public GameObject player;
	public float waitTime;
	public float timeValue;
	public float moveSpeed;
	public float blackScreenWaitTime;
	public float secondBlackScreenWaitTime;
	public Transform currentPoint;

	public Transform[] points;

	public int pointSelection;

	public bool On;
	public bool startMovement;

	public GameObject muzyka;
	public GameObject lektor;

	public string LevelToLoad;

	// Use this for initialization
	void Start () {
		
		waitTime = timeValue;
		muzyka = GameObject.FindGameObjectWithTag ("Music");

	}
	
	// Update is called once per frame
	void Update () {
		
	
		blackScreenWaitTime -= Time.deltaTime;
		if (blackScreenWaitTime <= 0) 
		{
			pierwszyCredits.SetActive (false);
			obrazekMnie.SetActive (false);
			secondBlackScreenWaitTime -= Time.deltaTime;
		}

		if (secondBlackScreenWaitTime <= 0) 
		{
			drugiCredits.SetActive (false);
			startMovement = true;
		}

		if (startMovement == true) {
			muzyka.GetComponent<AudioSource> ().volume = 0.1f;
			lektor.SetActive (true);
			player.transform.position = Vector3.MoveTowards (player.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

			if (player.transform.position == currentPoint.position) {
				if (currentPoint.tag == "Credits") {
					On = false;
					waitTime -= Time.deltaTime;
					if (waitTime <= 0) {
						waitTime = timeValue;
						currentPoint.tag = "Untagged";
						On = true;
					}

				} else {
					On = true;
				}
				if (On == true) {
					pointSelection++;
					if (pointSelection == points.Length) {
						pointSelection = 0;
					}
					currentPoint = points [pointSelection];
				}
			}
		}
			
		if (pointSelection >= 73) 
		{
			timeValue =  3.2f;
		}

		if (pointSelection >= 88) 
		{
			muzyka.GetComponent<AudioSource> ().volume -= 0.01f;
		}	

		if (pointSelection >= 89) 
		{
			
			muzyka.GetComponent<AudioSource>().volume = 0;
			Destroy (muzyka);
			Application.LoadLevel (LevelToLoad);
		}
			
	}
	}

