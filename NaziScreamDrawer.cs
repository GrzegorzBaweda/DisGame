using UnityEngine;
using System.Collections;

public class NaziScreamDrawer : MonoBehaviour {


	public GameObject audioSource1;
	public GameObject audioSource2;
	public int drawInt;
	// Use this for initialization
	void Start () {
		drawInt = Random.Range (0,2);

		if (drawInt == 0) 
		{
			audioSource1.SetActive (true);
		}

		if (drawInt == 1) 
		{
			audioSource2.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {


	}
}
