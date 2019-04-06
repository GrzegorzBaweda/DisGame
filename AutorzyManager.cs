using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutorzyManager : MonoBehaviour {

	public string mainMenu;
	public string myYoutube;
	public string myFacebook;

	public string hisYoutube;
	public string hisFacebook;

	public GameObject scroll;


	public bool isPressed;
	public bool movedMouse;
	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		mousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Fire1") || Input.GetKeyDown (KeyCode.Escape)) {
			Back ();
		}



		if(Input.mousePosition != mousePos)
		{
			movedMouse = true;
			Cursor.visible = true;
		}


			if (Input.GetAxisRaw ("Horizontal") > 0.1f || Input.GetAxisRaw ("Vertical") < -0.1f) {
				scroll.transform.position = new Vector2(scroll.transform.position.x ,scroll.transform.position.y + 3f);
				Cursor.visible = false;
				isPressed = true;

				//scroll.

			}
			if (Input.GetAxisRaw ("Horizontal") < -0.1f || Input.GetAxisRaw ("Vertical") > 0.1f) {
				scroll.transform.position = new Vector2(scroll.transform.position.x ,scroll.transform.position.y - 3f);
				Cursor.visible = false;
				isPressed = true;


			}


		mousePos = Input.mousePosition;



	}





	public void Back()
	{
		Application.LoadLevel (mainMenu);
	}

	public void MyYoutube()
	{
		Application.OpenURL (myYoutube);
	}

	public void MyFacebook()
	{
		Application.OpenURL (myFacebook);
	}

	public void HisYoutube()
	{
		Application.OpenURL (hisYoutube);
	}

	public void HisFacebook()
	{
		Application.OpenURL (hisFacebook);
	}


}
