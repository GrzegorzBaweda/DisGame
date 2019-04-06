using UnityEngine;
using System.Collections;

public class DestroyObjectOverTimeWithout : MonoBehaviour {

	public float lifeTime;
	private float lifeTimeStore;
	
	// Use this for initialization
	void Start () {
		lifeTimeStore = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		lifeTime -= Time.deltaTime;
		
		if (lifeTime < 0) {
			gameObject.SetActive(false);
			lifeTime = lifeTimeStore;
		}
		
	}
}