using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {

	public string doMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;




	public bool movedMouse;
	private Vector3 mousePos;


	public bool isPressed;




	public EventSystem eventSystem;



	public GameObject[] buttons;
	public int selectedButton;
	private bool pobranoMyszke;
	private bool czasPrzywrocono;
	// Use this for initialization

	
	// Update is called once per frame


	void Start()
	{
		eventSystem = FindObjectOfType<EventSystem> ();

	}



	void Update () 
	{
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			czasPrzywrocono = false;

			if(GameObject.FindGameObjectWithTag ("BGmusic") )
			{
				GameObject.FindGameObjectWithTag ("BGmusic").GetComponent<AudioSource> ().Pause();
			}
			else if ( GameObject.FindGameObjectWithTag ("Music") )
			{
				GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource> ().Pause();
			}
			else if ( GameObject.FindGameObjectWithTag ("Music2") )
			{
				GameObject.FindGameObjectWithTag ("Music2").GetComponent<AudioSource> ().Pause();
			}



			
			Time.timeScale = 0f;


			if (pobranoMyszke == false) {
				mousePos = Input.mousePosition;
				pobranoMyszke = true;
			}




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
					Cursor.visible = false;
					isPressed = true;

					if (eventSystem.currentSelectedGameObject == null) {
						eventSystem.SetSelectedGameObject (buttons [0]);
					} else {
						if (selectedButton == 2) {
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
							selectedButton = 2;
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


















		} else {
			pauseMenuCanvas.SetActive (false);

			pobranoMyszke = false;
			if(GameObject.FindGameObjectWithTag ("BGmusic") )
			{
				GameObject.FindGameObjectWithTag ("BGmusic").GetComponent<AudioSource> ().UnPause();
			}
			else if ( GameObject.FindGameObjectWithTag ("Music") )
			{
				GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource> ().UnPause();
			}
			else if ( GameObject.FindGameObjectWithTag ("Music2") )
			{
				GameObject.FindGameObjectWithTag ("Music2").GetComponent<AudioSource> ().UnPause();
			}


			Cursor.visible = false;
			if (czasPrzywrocono == false) {
				Time.timeScale = 1f;
				czasPrzywrocono = true;
			}
		}

		if (Input.GetButtonDown("Cancel")) 
		{
			isPaused = !isPaused;
			Cursor.visible = false;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void Menu()
	{
		Application.LoadLevel (doMenu);
	}

	public void KoniecGry()
	{
		Debug.Log ("Game Exited");
		Application.Quit ();
	}


}
