using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextBoxManager theTextBox;

	public bool destroyWhenActivated;					

	public bool requireButtonPress;
	private bool waitForPress;
	public TouchControls touchControls;
	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxManager> ();
		touchControls = FindObjectOfType<TouchControls> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((waitForPress && Input.GetButtonDown("Jump")) || (waitForPress && touchControls.textBoxAction == true) ) 
		
		{
			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();

			if(destroyWhenActivated)
			{

				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			if(requireButtonPress)
			{
				waitForPress = true;
				return;
			}
			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();

			if(destroyWhenActivated)
			{

				Destroy(gameObject);
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			waitForPress = false;
		}
	}
}
