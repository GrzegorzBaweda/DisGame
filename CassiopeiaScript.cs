using UnityEngine;
using System.Collections;

public class CassiopeiaScript : MonoBehaviour {

	public ScoreManager scoreManager;

	public int drawInt;

	public float iddleTime;
	private float waitTime;

	public int tipInt;

	public GameObject cassio;
	public GameObject dust;
	private Animator anim;
	//RAMMING

	public float moveSpeed;

	public Transform currentPoint;
	
	public Transform[] points;
	
	public int pointSelection;

	//SHOOTING

	public Transform shootPoint;
	public GameObject projectile;
	public GameObject projectile2;
	private bool startedShootingCo;

	//BOMBING
	public PlayerController player;
	public GameObject bomb;
	private bool startedBombingCo;
	public GameObject magicParticle;


	//NITRO FAZE
	public EnemyHealthManager cassioHealth;
	public bool nitroFaze;
	public bool startedShootingNitroCo;
	public bool startedShootingNitroCo2;
	public GameObject explosions;
	public string levelToLoad;
	public string levelTag;
	public bool deadEnd;


	public bool fazeSwitch;

	// Use this for initialization
	void Start () {
		anim = cassio.GetComponent<Animator> ();
		currentPoint = points [pointSelection];
		waitTime = iddleTime;
		cassio.transform.localScale = new Vector3 (1f, 1f, 1f);
		pointSelection = 1;
		dust.SetActive (false);
		player = FindObjectOfType<PlayerController> ();
		drawInt =3;
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fazeSwitch == false) {
			Faze1 ();
		} else {
			Faze2 ();
		}
	}
		public void Faze1 ()
		{

		//Prawidlowy LocalScale CassioPei
		if (pointSelection == 0) {
			cassio.transform.localScale = new Vector3 (-1f, 1f, 1f);

		}
		if (pointSelection == 1) {
			cassio.transform.localScale = new Vector3 (1f, 1f, 1f);

		}
		//Koniec PrawidlowegoLocalScale CassioPei

		if (waitTime <= 0) 
		{
			drawInt = Random.Range (0, 4);
			print (drawInt);
			waitTime = iddleTime;


		}
	if (drawInt == 0) 
		{
			anim.SetBool ("Run", false);
			anim.SetBool ("Shoot", false);
			dust.SetActive (false);
			waitTime -= Time.deltaTime;
		}

		if (drawInt == 1) 
		{
			Shooting();
		}
		if (drawInt == 2) 
		{
			Bombing();
		}
		if (drawInt == 3) 
		{
			Ramming();
		}
		

		if (nitroFaze == true) 
		{
			StartCoroutine("ExplosionsCo");
			drawInt = 0;
			nitroFaze = false;



		}
	}
	public void Faze2 ()
	{
		anim.SetBool ("Nitro", true);
		cassio.transform.localScale = new Vector3 (-1f, 1f, 1f);
		if (waitTime <= 0) {
			drawInt = Random.Range (0, 4);
			print (drawInt);
			waitTime = iddleTime;
			
			
		}
		if (drawInt == 0) {
			anim.SetBool ("Run", false);
			anim.SetBool ("Shoot", false);
			dust.SetActive (false);
			waitTime -= Time.deltaTime;
		}
		
		if (drawInt == 1) {
			ShootingNitro ();
		}
		if (drawInt == 2) {
			Bombing ();
		}
		if (drawInt == 3) {
			ShootingNitro2 ();
		}

		if (deadEnd == true) {
			StartCoroutine ("ExplosionsCo");
			drawInt = 0;
			deadEnd = false;
		}
	}
	

	public IEnumerator ExplosionsCo()
	{
			deadEnd = false;
		nitroFaze = false;
			Instantiate (explosions, cassio.transform.position, cassio.transform.rotation);
			deadEnd = false;
			nitroFaze = false;
		nitroFaze = false;
		yield return new WaitForSeconds(4f);
		PlayerPrefs.SetInt (levelTag, 1);
		ScoreManager.saveScore ();

		Application.LoadLevel (levelToLoad);
	}

	public void Shooting ()
	{
		anim.SetBool ("Shoot", true);
		tipInt = 1;
		if (startedShootingCo == false) {
			StartCoroutine ("ShootingCo");
			startedShootingCo = true;
		}

	}

	public IEnumerator ShootingCo()
	{
		yield return new WaitForSeconds(0.5f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.5f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.5f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.5f);
		startedShootingCo = false;
		drawInt = 0;
	}

	public void Bombing ()
	{
		anim.SetBool ("Shoot", true);

		if (startedBombingCo == false) {
			StartCoroutine ("BombingCo");
			startedBombingCo = true;
		}
		tipInt = 2;
	}

	public IEnumerator BombingCo ()
	{
		yield return new WaitForSeconds(0.5f);
		Instantiate (magicParticle, shootPoint.transform.position, shootPoint.transform.rotation);
		Instantiate(bomb, player.transform.position, player.transform.rotation);
		drawInt = 0;
		startedBombingCo = false;

	}

	public void Ramming ()
	{

		tipInt = 3;
		anim.SetBool ("Run", true);
		dust.SetActive (true);
		cassio.transform.position = Vector3.MoveTowards (cassio.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(cassio.transform.position == currentPoint.position)
		{
			pointSelection ++;

			if(pointSelection == points.Length)
			{
				pointSelection =0;
			}
			currentPoint = points[pointSelection];
			drawInt = 0;
		}
	}

	public void ShootingNitro ()
	{
		if (startedShootingNitroCo == false) {
			StartCoroutine ("ShootingNitroCo");
			startedShootingNitroCo = true;
		}
	}

	public IEnumerator ShootingNitroCo()
	{
		yield return new WaitForSeconds(0.3f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.3f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.3f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.3f);
		Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds(0.3f);
		startedShootingNitroCo = false;
		drawInt = 0;
	}

	public void ShootingNitro2 ()
	{
		if (startedShootingNitroCo2 == false) {
			StartCoroutine ("ShootingNitroCo2");
			startedShootingNitroCo2 = true;
		}
	}

	public IEnumerator ShootingNitroCo2()
	{
		yield return new WaitForSeconds (0.3f);
		Instantiate (projectile2, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds (0.3f);
		Instantiate (projectile2, shootPoint.transform.position, shootPoint.transform.rotation);
		yield return new WaitForSeconds (0.3f);
		startedShootingNitroCo2 = false;
		drawInt = 0;
	}
	public void Ultimate ()
	{
		drawInt = 0;
	}

	public void BombingNitro()
	{
		drawInt = 0;
	}

}
