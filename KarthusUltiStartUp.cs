using UnityEngine;
using System.Collections;

public class KarthusUltiStartUp : MonoBehaviour {

	public GameObject ultiKarthus;
	public float lifeTime;
	private float lifeTimeStore;
	public KarthusManager karthusScript;
	// Use this for initialization
	void Start () {
		karthusScript = FindObjectOfType<KarthusManager> ();
		lifeTimeStore = lifeTime;

		if (lifeTime != 10) 
		{
			lifeTime = 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (karthusScript.ultiStartup == true)
		{
			//Time.timeScale = 0.5f;
			lifeTime -= Time.fixedDeltaTime;
			if (lifeTime < 0) {
				Time.timeScale = 1f;
			ultiKarthus.SetActive(true);
			karthusScript.ultiStartup = false;

				lifeTime = lifeTimeStore;
			}
		}
	}
}
