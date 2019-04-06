using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AndroidSwitch : MonoBehaviour {



	public GameObject[] buttons;

	public GameObject textBox;
	private bool koniec;
	// Use this for initialization
	void Start () {
		
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		foreach (GameObject i in buttons) 
		{
			i.SetActive (false);
		}

		#endif



		#if UNITY_ANDROID || UNITY_IOS
		textBox = GameObject.Find ("TextBox");
		RectTransform rct = textBox.GetComponent<RectTransform>();

		rct.anchoredPosition3D = new Vector3 (rct.anchoredPosition3D.x, Screen.height - 52, rct.anchoredPosition3D.z);
		textBox.GetComponent<Image>().color = new Vector4 (255, 255, 255, 255);
		#endif
	}

	// Update is called once per frame
	void Update () {

		#if UNITY_ANDROID || UNITY_IOS

		if(!textBox)
		{
			textBox = GameObject.Find ("TextBox");
			if(textBox) 
			{
			RectTransform rct = textBox.GetComponent<RectTransform>();
			rct.anchoredPosition3D = new Vector3 (rct.anchoredPosition3D.x, Screen.height - 52, rct.anchoredPosition3D.z);
			textBox.GetComponent<Image>().color = new Vector4 (255, 255, 255, 255);
			}
		}

		if(!koniec)
			{
			if(textBox == null) textBox = GameObject.Find ("TextBox");
			//RectTransform rct = textBox.GetComponent<RectTransform>();
			//rct.anchoredPosition3D = new Vector3 (rct.anchoredPosition3D.x, Screen.height - 52, rct.anchoredPosition3D.z);
			//textBox.GetComponent<Image>().color = new Vector4 (255, 255, 255, 255);
			koniec = true;;
			}


		#endif

	}
}
