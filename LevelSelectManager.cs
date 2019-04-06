using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelectManager : MonoBehaviour {


	public string[] levelTags;

	public GameObject[] locks;

	public bool[] levelUnlocked;

	public int positionSelector;

	public string[] levelName;

	public float moveSpeed;

	private bool isPressed;

	public float distanceBelowLock;

	public Sprite[] spritesy;
	public GameObject img;

	public GameObject tlo1;
	public GameObject bg;

	public Sprite tlo1sprite;
	public Sprite tlo1bg;

	public Sprite tlo2sprite;
	public Sprite tlo2bg;

	public Sprite tlo3sprite;
	public Sprite tlo3bg;

	public AudioSource sound;
	public AudioSource choiceClick;
	public AudioSource lockedClick;

	public bool touchMode;
	public GameObject loadCanvas;
	// Use this for initialization
	void Start () 
	{
		loadCanvas = GameObject.Find ("LoadCanvas");
		loadCanvas.SetActive (false);

		for (int i = 0; i < levelTags.Length; i++) 
		{
			if (PlayerPrefs.GetInt (levelTags [i]) == null) {
				levelUnlocked [i] = false;
			} else if (PlayerPrefs.GetInt (levelTags [i]) == 0) {
				levelUnlocked [i] = false;
			} else 
			{
				levelUnlocked [i] = true;
			}

			if (levelUnlocked [i]) 
			{
				locks [i].SetActive (false);
			}
		}

		positionSelector = PlayerPrefs.GetInt ("PlayerLevelSelectPosition");


		//-----------------

		transform.position = locks [positionSelector].transform.position + new Vector3 (0, -distanceBelowLock, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isPressed) 
		{
			if (Input.GetAxis ("Horizontal") > 0.0f) 
			{
				sound.Play ();
				positionSelector += 1;
				isPressed = true;
			}

			if (Input.GetAxis ("Horizontal") < -0.0f) 
			{
				sound.Play ();
				positionSelector -= 1;
				isPressed = true;
			}

			if (positionSelector >= levelTags.Length)
			{
				positionSelector = levelTags.Length - 1;
			}

			if (positionSelector < 0)
			{
				positionSelector = 0;
			}
		}

		if (isPressed) 
		{
			if (Input.GetAxis("Horizontal") < 0.001f && Input.GetAxis("Horizontal") > -0.001f)
				{
					isPressed = false;
				}
		}

		transform.position = Vector2.MoveTowards (transform.position, locks [positionSelector].transform.position + new Vector3 (0, -distanceBelowLock, 0), moveSpeed * Time.deltaTime);


		if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Jump")) 
		{
			

			if (levelUnlocked [positionSelector] ) {
				choiceClick.Play ();
				loadCanvas.SetActive (true);
				PlayerPrefs.SetInt ("PlayerLevelSelectPosition", positionSelector);
				Application.LoadLevel (levelName [positionSelector]);
			} else if (!levelUnlocked [positionSelector] )
			{
				lockedClick.Play ();
			}

		
		}

		img.GetComponent<Image> ().sprite = spritesy [positionSelector];

		if (positionSelector < 6 && positionSelector >= 0) 
		{
			tlo1.GetComponent<SpriteRenderer>().sprite = tlo1sprite;
			bg.GetComponent<SpriteRenderer>().sprite = tlo1bg;
		}
		if (positionSelector > 5 && positionSelector < 11) 
		{
			tlo1.GetComponent<SpriteRenderer>().sprite = tlo2sprite;
			bg.GetComponent<SpriteRenderer>().sprite = tlo2bg;
		}

		if (positionSelector > 10) 
		{
			tlo1.GetComponent<SpriteRenderer>().sprite = tlo3sprite;
			bg.GetComponent<SpriteRenderer>().sprite = tlo3bg;
		}
	}
}
