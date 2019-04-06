using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KarthusManager : MonoBehaviour {

	public static int score;
	public GameObject empty;
	public GameObject oneball;
	public GameObject twoballs;
	public GameObject threeballs;
	public GameObject ultiKarthus;
	public PlayerController playerController;
	public GameObject haloKarthus;
	public float lifeTime;
	public GameObject redScreen;
	private PlayerController player;
	public GameObject ultiSound;
	public bool ultiStartup;
	public float slowingTime;
	// Use this for initialization
	void Start () {
		score = 0;
		empty.SetActive (true);
		oneball.SetActive (false);
		twoballs.SetActive (false);
		threeballs.SetActive (false);
		playerController.ulted = false;
		player = FindObjectOfType<PlayerController>();
		ultiStartup = false;


		if (lifeTime != 0.1f) 
		{
			lifeTime = 0.1f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (score <= 0) 
		{
			score = 0;
			oneball.SetActive (false);
			twoballs.SetActive (false);
			threeballs.SetActive (false);
			playerController.ulted = false;
		}
		if (score == 1)
		{
			oneball.SetActive (true);
			twoballs.SetActive (false);
			threeballs.SetActive (false);
			playerController.ulted = false;
		}
		if (score == 2) 
		{
			oneball.SetActive (false);
			twoballs.SetActive (true);
			threeballs.SetActive (false);
			playerController.ulted = false;
		}
		if (score >= 3) 
		{

			score =3;
			oneball.SetActive (false);
			twoballs.SetActive (false);
			threeballs.SetActive (true);
			if (playerController.ulted == true &&  player.grounded == false)
			{
				playerController.ulted = false;
				return;
			}
			if (playerController.ulted == true && player.grounded == true)
			{
				

				haloKarthus.SetActive(true);
				playerController.GetComponent<Animator>().SetBool("Calling", true);

				player.enabled = false;

				player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

				lifeTime -= Time.deltaTime;
				if (lifeTime <= 0) {

					slowingTime += Time.fixedDeltaTime/2;
					Time.timeScale = Mathf.Lerp (Time.timeScale, 0f, slowingTime);
				


					if (haloKarthus.GetComponent<AudioSource> ().isPlaying == false) {

						playerController.ulted = false;
				
						score = 0;
						playerController.GetComponent<Animator> ().SetBool ("Calling", false);

						haloKarthus.SetActive (false);
						player.enabled = true;
						redScreen.SetActive (true);
						ultiSound.SetActive (true);
						ultiStartup = true;
						//slowingTime = 0f;
						Time.timeScale = 0f;
						lifeTime = 0.1f;
						//zrobić osobny obiekt, a w tym skrypcie bool i dać go na true tutaj zaraz wyżej, w obiekcie tym nowym wyszukać ten
						//bool odczekac 4 sekundy i odpalic ulti.
					}
				}
			}


		}
	}

	public static void AddPoints (int pointsToAdd)
	{

		score += pointsToAdd;


	}
		


	
}
