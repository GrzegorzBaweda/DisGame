using UnityEngine;
using System.Collections;

public class DisapearOfNPC : MonoBehaviour {

	public TextBoxManager theTextBox;
	public int npcOrder;
	private SpriteRenderer thisSpriteRenderer;

	public Sprite npcSprite;
	public Sprite spriteOfNothing;
	public GameObject activationScript;
	
	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxManager> ();
		thisSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (theTextBox.generalOrder == npcOrder) 
		{
			thisSpriteRenderer.sprite = npcSprite;
			if (activationScript) {
				activationScript.SetActive (true);
			}

		} 
		else
			{
				thisSpriteRenderer.sprite = spriteOfNothing;
			if (activationScript) {
				activationScript.SetActive (false);
			}
			}
		}

	}

