using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EntryScreen : MonoBehaviour {

	public Image acer;
	public Image krople;
	public Text tekst;

	public float time;

	public float acerOn;
	public float acerOff;

	public float kropleOn;
	public float kropleOff;

	public float endTime;

	public bool sponsorzyOn;
	public Image mojeLogo;

	public float mojeOff2;
	public float mojeOff;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!sponsorzyOn) {
			time += Time.deltaTime;

			if (time < mojeOff) {
				var kolor = mojeLogo.color;
				kolor.a += Time.deltaTime;
				mojeLogo.color = kolor;
			}
			if (time > mojeOff && time < mojeOff2) {
				var kolor = mojeLogo.color;
				kolor.a -= Time.deltaTime;
				mojeLogo.color = kolor;
		
			}

			if (time > mojeOff2) {
				time = 0;
				sponsorzyOn = true;
			
			}
		}

		if (sponsorzyOn) {
			time += Time.deltaTime;
		 	var kolor = tekst.color;

			if (time > acerOn && time < acerOff) {
				kolor = acer.color;
				kolor.a += Time.deltaTime;
				acer.color = kolor;
			}

			if (time > acerOff && time < kropleOn) {
				kolor = acer.color;
				kolor.a -= Time.deltaTime;
				acer.color = kolor;
			}

			if (time > kropleOn && time < kropleOff) {
				kolor.a += Time.deltaTime;
				tekst.color = kolor;
				kolor = krople.color;
				kolor.a += Time.deltaTime;
				krople.color = kolor;
			}

			if (time > kropleOff && time < endTime) {
				kolor = krople.color;
				kolor.a -= Time.deltaTime;
				krople.color = kolor;
				tekst.color = kolor;
			}

			if (time > endTime) {
				Application.LoadLevel ("MainMenu");
			}

		}




	}
}

