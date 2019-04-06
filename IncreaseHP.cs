using UnityEngine;
using System.Collections;

public class IncreaseHP : MonoBehaviour {
	
	public GameObject kiara;
	public AudioSource pickupSoundEffect;
	public float timeKiss;
	public GameObject Mlg;
	public PlayerController player;
	public float MlgTime;
	private float gravityStore;
	public bool startEverything;
	private Animator anim;

	public string pickupTag;
	public float musicVolumeSave;
	public AudioSource BGmusic;
	void Start ()
	{
		BGmusic = GameObject.FindGameObjectWithTag ("BGmusic").GetComponent<AudioSource> ();
		musicVolumeSave = BGmusic.volume;
		player = FindObjectOfType<PlayerController>();
		startEverything = false;
		anim = player.GetComponent<Animator> ();

		if (PlayerPrefs.GetInt (pickupTag) == null) {
		} else if (PlayerPrefs.GetInt (pickupTag) == 0)
		{
		} else 
		{
			Destroy(gameObject);
		}

	}

	void Update ()
	{
		if (startEverything == true)
		{
			
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			anim.SetFloat ("Speed", player.GetComponent<Rigidbody2D> ().velocity.x); 
			player.enabled = false;
		
			kiara.SetActive (true);
			timeKiss -= Time.deltaTime;

			if (timeKiss < 0) {


				BGmusic.volume = 0f;
				Mlg.SetActive (true);
				MlgTime -= Time.deltaTime;
				if (MlgTime < 0) {

					kiara.SetActive (false);
					Mlg.SetActive (false);
					BGmusic.volume = musicVolumeSave;
					player.enabled = true;
					HealthManager.IncreaseMaxHealth();

					startEverything = false;
					PlayerPrefs.SetInt (pickupTag, 1);
					BGmusic.volume = musicVolumeSave;
					Destroy (gameObject);
				}
			}

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;
		gameObject.GetComponent<Renderer> ().enabled = false;
		pickupSoundEffect.Play ();
		startEverything = true;




	}
}
