using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroManager : MonoBehaviour {

	//public Sprite obrazek1;
	public Sprite obrazek2;
	public Sprite obrazek3;
	public Sprite obrazek4;
	public Sprite obrazek5;
	public Sprite obrazek6;
	public Sprite obrazek7;
	public Sprite obrazek8;
	public Sprite obrazek9;
	public Sprite obrazek10;
	public Sprite nerva;
	private float effectivePauseTime;
	public float theTime;
	private bool start;
	public GameObject lektor;
	public GameObject music;
	public GameObject ladowanie;

	public GameObject pic;
	public string levelToLoad;
	public GameObject skipCanvas;
	public string levelTag;
	// Use this for initialization
	void Start () {
		theTime = 0f;
		effectivePauseTime = 3f;
	}
	
	// Update is called once per frame
	void Update () {

		effectivePauseTime -= Time.deltaTime;

		if(effectivePauseTime <= 1f)
			music.SetActive (true);
		if (effectivePauseTime <= 0f) 
			start = true;
		
		
		if (start == true)
		{
			lektor.SetActive (true);
			skipCanvas.SetActive (true);
			Cursor.visible = true;
			theTime += Time.deltaTime;


			if (theTime >= 28f) 
			{
				ladowanie.SetActive (false);

			}

			if (theTime >= 40f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek2;
			}

			if (theTime >= 45f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek3;
			}

			if (theTime >= 50f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek4;
			}

			if (theTime >= 53f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek5;
			}

			if (theTime >= 67f) 
			{
				pic.GetComponent<Image> ().sprite = nerva;
			}

			if (theTime >= 73f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek6;
			}

			if (theTime >= 77f) 
			{
				pic.GetComponent<Image> ().sprite = nerva;
			}

			if (theTime >= 79.5f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek6;
			}

			if (theTime >= 81f) 
			{
				pic.GetComponent<Image> ().sprite = nerva;
			}
			if (theTime >= 83.5f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek6;
			}

			if (theTime >= 86f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek7;
			}

			if (theTime >= 88.5f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek8;
			}

			if (theTime >= 91f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek9;
			}

			if (theTime >= 95f) 
			{
				pic.GetComponent<Image> ().sprite = obrazek10;
			}

			if (theTime >= 113f) 
			{
				PlayerPrefs.SetInt (levelTag, 1);
				Cursor.visible = false;
				Application.LoadLevel (levelToLoad);
			}
		}
	}

	public void Pomin()
	{
		Cursor.visible = false;
		PlayerPrefs.SetInt (levelTag, 1);
		Application.LoadLevel (levelToLoad);
	}
}
