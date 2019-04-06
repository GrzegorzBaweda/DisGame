using UnityEngine;
using System.Collections;

public class NewLvlAfterDialogue : MonoBehaviour {

	public TextBoxManager theTextBox;
	public int order;
	public string levelToLoad;
	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (theTextBox.generalOrder == order) 
		{
			return;
			
		} 
		else
		{

			Application.LoadLevel (levelToLoad);
		}
	}

	}

