using UnityEngine;
using System.Collections;

public class PlatformRespawnAfterDeath : MonoBehaviour {


	public HealthManager healthManager;
	public Transform platformResetPoint;
	public MovingOnTouch platformScript;
	// Use this for initialization
	void Start () {

		healthManager = FindObjectOfType<HealthManager> ();
		platformScript = GetComponent<MovingOnTouch> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (healthManager.isDead) 
		{
			platformScript.platform.transform.position = platformResetPoint.transform.position;
			platformScript.pointSelection = 0;
			platformScript.On = false;
		}

	}
}
