using UnityEngine;
using System.Collections;

public class DestroyFinishedAnimation : MonoBehaviour {
	
	public float delay = 0f;

	public GameObject impactEffect;
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
	}
}