using UnityEngine;
using System.Collections;

public class KarthusPickup : MonoBehaviour {

	public int pointsToAdd;
	
	public AudioSource coinSoundEffect;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;
		if (KarthusManager.score ==3) 
		{
			return;
		}
		
		KarthusManager.AddPoints (pointsToAdd);
		pointsToAdd = 0;
		coinSoundEffect.Play ();
		Destroy (gameObject);
	}
}