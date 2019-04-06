using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour {

	public string start;
	public string wczytaj;
	public string autorzy;
	public int playerHealth;
	public int playerMaxHealth;
	public string levelTag;
	public NewAndro json;
	private string levelTag1 = "Kroplelock";
	public GameObject loadingCanvas;


	public EventSystem eventSystem;
	public GameObject[] buttons;
	public int selectedButton;


	public bool movedMouse;
	private Vector3 mousePos;


	public bool isPressed;
	void Start()
	{
		loadingCanvas = GameObject.Find("LoadCanvas");
		loadingCanvas.SetActive(false);
		json = FindObjectOfType<NewAndro> ();
		Cursor.visible = true;
		mousePos = Input.mousePosition;
	}

	public void StartGame()
	{
		loadingCanvas.SetActive(true);
		//PlayerPrefs.DeleteAll();
		if (PlayerPrefs.GetInt ("FirstTimeRunning") == null) 
		{
			PlayerPrefs.SetInt ("PlayerCurrentHealth" , playerHealth);
			PlayerPrefs.SetInt ("PlayerMaxHealth" , playerMaxHealth);

			PlayerPrefs.SetInt ("FirstTimeRunning", 1);
		} 
		else if (PlayerPrefs.GetInt ("FirstTimeRunning") == 0) 
		{
			PlayerPrefs.SetInt ("PlayerCurrentHealth" , playerHealth);
			PlayerPrefs.SetInt ("PlayerMaxHealth" , playerMaxHealth);

			PlayerPrefs.SetInt ("FirstTimeRunning", 1);
		} 
		else 
		{
		}




		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		Cursor.visible = false;
		Application.LoadLevel (start);
	}

	public void LoadGame()
	{
		
		if(PlayerPrefs.GetInt (levelTag) == 1)
		{
		if (PlayerPrefs.GetInt ("FirstTimeRunning") == null) 
		{
			PlayerPrefs.SetInt ("PlayerCurrentHealth" , playerHealth);
			PlayerPrefs.SetInt ("PlayerMaxHealth" , playerMaxHealth);

			PlayerPrefs.SetInt ("FirstTimeRunning", 1);
		} 
		else if (PlayerPrefs.GetInt ("FirstTimeRunning") == 0) 
		{
			PlayerPrefs.SetInt ("PlayerCurrentHealth" , playerHealth);
			PlayerPrefs.SetInt ("PlayerMaxHealth" , playerMaxHealth);

			PlayerPrefs.SetInt ("FirstTimeRunning", 1);
		} 
		else 
		{
		}


		if (!PlayerPrefs.HasKey ("PlayerLevelSelectPosition")) 
		{
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		}
			loadingCanvas.SetActive(true);
		Cursor.visible = false;
		Application.LoadLevel (wczytaj);
		}
	}

	public void QuitGame()
	{
		Debug.Log ("Koniec programu");
		Application.Quit ();
	}

	public void Autorzy()
	{
		Application.LoadLevel (autorzy);
	}
		
	public void Android()
	{
		Application.OpenURL (json.gpLink);
	}



	//public void Start()
	//{
		//ustawienie pozycji kursora na start game
		//invisible kurwa
	//}


	void Update()
	{

		if(Input.mousePosition != mousePos)
		{
			movedMouse = true;
			Cursor.visible = true;
			eventSystem.SetSelectedGameObject (null);
		}


		if ( ( Input.GetButtonDown ("Jump") ) && eventSystem.currentSelectedGameObject != null) 
		{
			Cursor.visible = false;
			isPressed = false;
			eventSystem.currentSelectedGameObject.GetComponent<Button> ().onClick.Invoke ();
		}

		if (!isPressed) {
			if (Input.GetAxisRaw ("Horizontal") > 0.1f || Input.GetAxisRaw ("Vertical") < -0.1f) {
				Debug.Log ("Guwno");
				Cursor.visible = false;
				isPressed = true;

				if (eventSystem.currentSelectedGameObject == null) {
					eventSystem.SetSelectedGameObject (buttons [0]);
				} else {
					if (selectedButton == 4) {
						selectedButton = 0;
					} else {
						selectedButton++;
					}
					eventSystem.SetSelectedGameObject (buttons [0 + selectedButton]);
				}

			}


			if (Input.GetAxisRaw ("Horizontal") < -0.1f || Input.GetAxisRaw ("Vertical")  > 0.1f) {
				Cursor.visible = false;
				isPressed = true;

				if (eventSystem.currentSelectedGameObject == null) {
					eventSystem.SetSelectedGameObject (buttons [0]);
				} else {
					if (selectedButton == 0) {
						selectedButton = 4;
					} else {
						selectedButton--;
					}
					eventSystem.SetSelectedGameObject (buttons [0 + selectedButton]);
				}

			}





		}

		if (isPressed) 
		{
			if (Input.GetAxisRaw("Horizontal") < 0.001f && Input.GetAxisRaw("Horizontal") > -0.001f && Input.GetAxisRaw("Vertical") < 0.001f && Input.GetAxisRaw("Vertical") > -0.001f)
			{
				isPressed = false;
			}
		}
		//eventSystem.SetSelectedGameObject (buttons [0]);
		mousePos = Input.mousePosition;

	}
		



}
