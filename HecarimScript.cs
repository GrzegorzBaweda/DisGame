using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HecarimScript : MonoBehaviour {

	public int drawInt;
	public int timeDraw;
	public float iddleTime;
	private float waitTime;

	private Animator anim;

	public GameObject heca;

	public int tipInt;


	public float moveSpeed;
	public float moveSpeedUlti;
	public float moveSpeedSlow;

	public Transform currentPoint;

	public Transform[] points;

	public int pointSelection;

	public PlayerController player;

	public GameObject przydupasy;

	//

	public EnemyHealthManager switchHealth1;
	public EnemyHealthManager switchHealth2;
	public EnemyHealthManager hecarimHealth1;

	public Transform vulnerablePoint1;
	public Transform vulnerablePoint2;

	private bool hecaStop;

	public float vulnerableTime;
	private bool startedVulnerableCo;

	public GameObject switch1;
	public GameObject switch2;
	public Transform switchPositionSave1;
	public Transform switchPositionSave2;
	public int tip2;
	private bool onceDestroyed;
	private int realSwitchLife1;
	private int realSwitchLife2;
	public GameObject switchLast1;
	public GameObject switchLast2;


	public GameObject KotBoss;
	public GameObject wybuchy;

	public string levelToLoad;

	private int rewards;

	public GameObject blokada1;
	public GameObject blokada2;
	public GameObject blokada3;
	public GameObject blokada4;

	public GameObject bolPartia1;
	public GameObject bolPartia2;
	public GameObject bolPartia3;
	public GameObject bolPartia4;

	public ParticleSystem lightEyes;

	public bool ChargeBlockade;

	public int maxHP;
	public AudioSource palSieKoniu;
	// Use this for initialization
	void Start () {

		maxHP = KotBoss.GetComponent<EnemyHealthManager> ().enemyHealth;
		KotBoss.GetComponent<Collider2D> ().enabled = false;
		przydupasy.SetActive (false);
		anim = heca.GetComponent<Animator> ();
		currentPoint = points [pointSelection];
		waitTime = iddleTime;
		heca.transform.localScale = new Vector3 (2f, 2f, 2f);
		pointSelection = 1;
		player = FindObjectOfType<PlayerController> ();
		drawInt =0;
		hecaStop = false;
	}

	// Update is called once per frame
	void Update () {


		if (rewards >= 1) 
		{
			Destroy (blokada1);
			bolPartia1.SetActive (true);
		}
		if (rewards >= 2) 
		{
			Destroy (blokada2);
			bolPartia2.SetActive (true);
		}
		if (rewards >= 3) 
		{
			Destroy (blokada3);
			bolPartia3.SetActive (true);
		}
		if (rewards >= 4) 
		{
			Destroy (blokada4);
			bolPartia4.SetActive (true);
		}



		if (GameObject.Find ("Wybuchy")) 
		{
			wybuchy.transform.position = heca.transform.position;
			anim.SetInteger ("State", 7);
		}

		if (KotBoss.GetComponent<EnemyHealthManager> ().enemyHealth <= maxHP * 0.35) 
		{
			palSieKoniu.enabled = true;
		}

		if (KotBoss.GetComponent<EnemyHealthManager> ().enemyHealth <= 0) 
		{
			drawInt = 7;
		}

		if (onceDestroyed == true) {

			if (hecaStop == false)
			{
				if (switchLast1 != isActiveAndEnabled && switchLast2 != isActiveAndEnabled)
				{
					realSwitchLife1 = 0;
					realSwitchLife2 = 0;
				}  

			}
	
		} else {
			
			realSwitchLife1 = switchHealth1.enemyHealth;
			realSwitchLife2 = switchHealth2.enemyHealth;
		}

		if (pointSelection == 0) {
			heca.transform.localScale = new Vector3 (2f, 2f, 2f);

		}
		if (pointSelection == 1) {
			heca.transform.localScale = new Vector3 (-2f, 2f, 2f);
		}


		if (waitTime <= 0) 
		{
			if (ChargeBlockade == false) {


				przydupasy.SetActive (false);
				drawInt = Random.Range (1, 6);
				print (drawInt);
				timeDraw = Random.Range (0, 2);
				print (timeDraw);
				iddleTime = timeDraw;
				waitTime = iddleTime;
				przydupasy.SetActive (false);


				tip2 = switchHealth1.enemyHealth;


				if (realSwitchLife1 <= 0) {
					if (realSwitchLife2 <= 0) {

						drawInt = 6;
					}
				}
				
			} else 
			{
				przydupasy.SetActive (false);
				drawInt = Random.Range (5, 6);
				print (drawInt);
				timeDraw = Random.Range (0, 2);
				print (timeDraw);
				iddleTime = timeDraw;
				waitTime = iddleTime;
				przydupasy.SetActive (false);
				ChargeBlockade = false;

				tip2 = switchHealth1.enemyHealth;


				if (realSwitchLife1 <= 0) {
					if (realSwitchLife2 <= 0) {

						drawInt = 6;
					}
				}
			}
		}

		if (drawInt == 0) 
		{
			
			waitTime -= Time.deltaTime;

		}

		if (drawInt == 1) 
		{
			DownCharge();
		}
		if (drawInt == 2) 
		{
			MiddleCharge();
		}
		if (drawInt == 3) 
		{
			UpCharge();
		}
		if (drawInt == 4) 
		{
			SpinCharge();
		}
		if (drawInt == 5) 
		{
			SlowCharge();
		}

		if (drawInt == 6) 
		{

			Vulnerable ();
		}

		if (drawInt == 7) 
		{

			Explosion ();
		}


	}
	public void DownCharge ()
	{
		przydupasy.SetActive (false);
		tipInt = 1;
		anim.SetInteger ("State", 1);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(heca.transform.position == currentPoint.position)
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
	public void MiddleCharge ()
	{
		przydupasy.SetActive (true);
		tipInt = 2;
		anim.SetInteger ("State", 2);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeedUlti);
		if(heca.transform.position == currentPoint.position)
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
	public void UpCharge ()
	{
		przydupasy.SetActive (false);
		tipInt = 3;
		anim.SetInteger ("State", 3);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(heca.transform.position == currentPoint.position)
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

	public void SpinCharge ()
	{
		przydupasy.SetActive (false);
		tipInt = 4;
		anim.SetInteger ("State", 4);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * 35);
		if(heca.transform.position == currentPoint.position)
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
	public void SlowCharge ()
	{
		przydupasy.SetActive (false);
		tipInt = 5;
		anim.SetInteger ("State", 5);
		heca.transform.position = Vector3.MoveTowards (heca.transform.position, currentPoint.position, Time.deltaTime * moveSpeedSlow);
		if(heca.transform.position == currentPoint.position)
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
	public void Vulnerable ()
	{
		if (pointSelection == 1)
		{
			heca.transform.position = Vector3.MoveTowards (heca.transform.position, vulnerablePoint2.position, Time.deltaTime * moveSpeed);


		}
		if (pointSelection == 0) 
		{
			heca.transform.position = Vector3.MoveTowards (heca.transform.position, vulnerablePoint1.position, Time.deltaTime * moveSpeed);

		}
		if (heca.transform.position == vulnerablePoint1.position)
		{
			hecaStop = true;
		}
		if (heca.transform.position == vulnerablePoint2.position)
		{
			hecaStop = true;
		}

		if (hecaStop == true)
		{
			if (startedVulnerableCo == false) {
				StartCoroutine ("VulnerableCo");
				startedVulnerableCo = true;

			}
		}


		
	}
	public IEnumerator VulnerableCo()
	{
		ChargeBlockade = true;
		KotBoss.GetComponent<Collider2D> ().enabled = true;
		anim.SetInteger ("State", 6);
		yield return new WaitForSeconds (0.38f);
		anim.SetInteger ("State", 7);
		yield return new WaitForSeconds (4f);
		Instantiate (lightEyes, KotBoss.transform.position, KotBoss.transform.rotation);
		yield return new WaitForSeconds (1f);
		anim.SetInteger ("State", 8);
		yield return new WaitForSeconds (0.38f);
		if (GameObject.Find ("KotCollider")) 
		{
			KotBoss.GetComponent<Collider2D> ().enabled = false;
		}
		anim.SetInteger ("State", 9);
		yield return new WaitForSeconds (2f);
		anim.SetInteger ("State", 1);
		switchLast1 = Instantiate(switch1, switchPositionSave1.transform.position, switchPositionSave1.transform.rotation);
		switchLast2 = Instantiate(switch2, switchPositionSave2.transform.position, switchPositionSave2.transform.rotation);
		switchLast1.transform.localScale = new Vector3 (-1f, 1f, 1f);
		switchHealth1.enemyHealth = switch1.GetComponent<EnemyHealthManager> ().enemyHealth;
		switchHealth2.enemyHealth = switch2.GetComponent<EnemyHealthManager> ().enemyHealth;
		realSwitchLife1 = 1;
		realSwitchLife2 = 1;
		rewards++;
		onceDestroyed = true;

		waitTime = 0;
		startedVulnerableCo = false;
		hecaStop = false;
		if (moveSpeed <= 34) 
		{
			moveSpeed = moveSpeed + 5;
		}



			
	}

	public void Explosion ()
	{
		anim.SetInteger ("State", 7);
		StartCoroutine ("ExplosionCo");

	}

	public IEnumerator ExplosionCo()
	{
		Instantiate (wybuchy, heca.transform.position, wybuchy.transform.rotation);
		yield return new WaitForSeconds(4f);
		Application.LoadLevel (levelToLoad);
	}
}
