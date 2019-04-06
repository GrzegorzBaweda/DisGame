using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKey : MonoBehaviour {

	public AudioSource sound;
	public GameObject blokada;
	public Sprite newSprite;
	private bool done;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		{

			if (other.tag == "Projectile")
			{
				if (!done) 
				{
					
					sound.Play ();
					Destroy (blokada);
					this.GetComponent<SpriteRenderer> ().sprite = newSprite;
					done = true;
				}

			}
		}
	}

}
