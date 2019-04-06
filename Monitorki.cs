using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitorki : MonoBehaviour {

	public GameObject canvas;
	public Text theText; 

	public int number;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Untagged")
		{
			switch (number) 
			{
			case 0: 
				theText.text = "Góra";
				break;
			case 1:
				theText.text = "Lewo";
				break;
			case 2: 
				theText.text = "Tak samo jak wcześniej";
				break;
			case 3: 
				theText.text = "Tak samo jak na początku";
				break;
			case 4:
				theText.text = "Prawo";
				break;
			case 5:
				theText.text = "Tak samo jak przed poprzednim pomieszczeniem";
				break;
			}

			canvas.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.tag == "Untagged")
		{
			canvas.SetActive (false);

		}
	}
}
