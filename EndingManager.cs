using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour {

	public GameObject pic;
	public GameObject napis;
	public Sprite spr1;
	public Sprite spr2;
	public Sprite spr3;

	public float theTime;
	public float time1;
	public float time2;
	public float time3;
	public float time4;
	public float time5;
	public GameObject sound;
	public byte alfa;
	public GameObject endingdialog;
	public GameObject elevator;
	// Use this for initialization
	void Start () {
		pic.GetComponent<Image> ().color = new Color32 (255, 255, 255, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		theTime += Time.deltaTime;
		if (alfa != 255) {
			
			alfa += 1;
			pic.GetComponent<Image> ().color = new Color32 (255, 255, 255, alfa);
		}
		if (alfa == 255) {
			pic.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		}

		if (theTime >= time1) 
		{
			endingdialog.SetActive (true);
			pic.GetComponent<Image> ().sprite = spr1;
		}

		if (theTime >= time2) 
		{
			pic.GetComponent<Image> ().sprite = spr2;
		}

		if (theTime >= time3) 
		{
			elevator.GetComponent<AudioSource> ().volume -= 0.01f;
			pic.GetComponent<Image> ().sprite = spr3;
		}

		if (theTime >= time4) 
		{
			sound.SetActive (true);	
			napis.SetActive (true);

		}

		if (theTime >= time5) 
		{
			Application.LoadLevel ("MainMenu");
		}
	}
}
