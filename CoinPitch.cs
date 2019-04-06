using UnityEngine;
using System.Collections;

public class CoinPitch : MonoBehaviour {

	public bool took;
	private float pitchEndTime = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!took) 
		{
			GetComponent<AudioSource> ().pitch = 1f;
		}

		if (took)
		{
			pitchEndTime -= Time.deltaTime;

		}

		if (pitchEndTime <= 0)
		{
			took = false;
			pitchEndTime = 2;
		}

	}

	public void managingPitch ()
	{
		if (took) {
			GetComponent<AudioSource> ().pitch += 0.1f;
		
		}
	}

}
