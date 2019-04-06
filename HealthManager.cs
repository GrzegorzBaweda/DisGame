using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public static int playerHealth;

	public int maxPlayerHealth;

	//Text text;

	public Slider healthBar;

	private LevelManager levelManager;

	public bool isDead;

	private LifeManager lifeSystem;

	public static bool increasingHP;
	public int healthToIncrease;
	public Camera camera;
	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<Camera> ();
		//text = GetComponent<Text> ();
		maxPlayerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");

		healthBar = GetComponent<Slider> ();

		healthBar.maxValue = PlayerPrefs.GetInt ("PlayerMaxHealth");

		playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");

		levelManager = FindObjectOfType<LevelManager> ();

		lifeSystem = FindObjectOfType<LifeManager> ();

		isDead = false;

		increasingHP = false; //W TYM MOMENCIE NIE DZIEJE SIE ZWIEKSZANIE HP


	}

	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;
			playerHealth = maxPlayerHealth;
		}

		if (playerHealth > maxPlayerHealth) {
			playerHealth = maxPlayerHealth;
		}

		//text.text = "x " + playerHealth;

		healthBar.value = playerHealth;
		//ZWIEKSZANIE HP O 1
		if (increasingHP == false) {return; 
		}else {
			maxPlayerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
			maxPlayerHealth += healthToIncrease;
			PlayerPrefs.SetInt ("PlayerMaxHealth", maxPlayerHealth);
			healthBar.maxValue += healthToIncrease;
			increasingHP = false; 
			FullHealth();
		}
	}
	public static void HurtPlayer (int damageToGive)
	{
		if (FindObjectOfType<PlayerController> ().godMode == true) 
		{
			return;
		}
		playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void FullHealth()
	{
		playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", maxPlayerHealth);
	}

	public static void IncreaseMaxHealth ()
	{

		increasingHP = true; 


	}
}
