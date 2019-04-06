using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float JumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool grounded;

	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject bullet;
	public float shotDelay;
	private float shotDelayCounter;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	private Rigidbody2D myrigidbody2d;

	public bool shooted;
	public bool ulted;
	public bool hitted;
	public float hurtTime;

	public bool canMove;

	public AudioSource jumpSound;

	public float accelerationFactor;
	public float acceleration;
	public bool beastMode;

	public int collisionCount;

	public GameObject downLook;
	public Camera camera;


	public bool godMode;

	// Use this for initialization
	void Start () {
		downLook = new GameObject();
		camera = FindObjectOfType<Camera> ();
		if (beastMode == true) {
			moveSpeed = 8f;
			acceleration = 1f;
			accelerationFactor = 0f;
		} else {
			moveSpeed = 10f;
		}
		anim = GetComponent<Animator> ();

		myrigidbody2d = GetComponent<Rigidbody2D> ();
	
	}

	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle (groundCheck.position , groundCheckRadius, whatIsGround);
		if (grounded)
		{
			Collider2D cols = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
			if(cols.gameObject.tag == "MovingPlatform")
			{
				transform.parent = cols.gameObject.transform;
			}
			else
			{
				transform.parent = null;
			}
		}
		else
		{
			transform.parent = null;
		}

	}

	// Update is called once per frame
	void Update () {

		if(beastMode == true){

			accelerationFactor = acceleration + acceleration* Mathf.Log(1+Time.timeSinceLevelLoad/8, 2);

			
			if (!canMove) 
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
				anim.SetFloat ("Speed",0); 
				return;
				
			}
			
			if (grounded) {
				doubleJumped = false;
				
			}
			
			anim.SetBool ("Grounded", grounded);
			
			if (Input.GetButtonDown("Jump") && grounded)
			{
				jumpSound.pitch = 1f;
				Jump ();
				
				
			}

			
			//moveVelocity = 0f;
			
			moveVelocity = moveSpeed * accelerationFactor;
			
			if (knockbackCount <= 0)
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
			} else {
				if(knockFromRight)
					myrigidbody2d.velocity = new Vector2(-knockback, knockback);
				if (!knockFromRight)
					myrigidbody2d.velocity = new Vector2(knockback, knockback);
				knockbackCount -= Time.deltaTime;
				
				
			}
			
			anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x)); 
			anim.speed = 1f * accelerationFactor*0.8f;
			if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			{
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}

			#if UNITY_STANDALONE || UNITY_WEBPLAYER
			
			if (Input.GetButtonDown("Fire1") && FindObjectOfType<PauseMenu>().isPaused == false)
			{
				//shooted = true;
				Flame();
				//Instantiate(bullet, firePoint.position, firePoint.rotation);
				shotDelayCounter = shotDelay;
			} 
			
			if(Input.GetButton("Fire1") && FindObjectOfType<PauseMenu>().isPaused == false)
			{
				shotDelayCounter -= Time.deltaTime;
				
				if(shotDelayCounter <= 0)
				{
					shotDelayCounter = shotDelay;
					//Instantiate(bullet, firePoint.position, firePoint.rotation);
					//shooted = true;
					Flame();
					
				}
			}
			if(Input.GetButton("Fire2"))
			{
				ulted = true;
				
			}
			#endif
			
			
			//START KORUTYNY MIGANIA
			if (hitted == true) {
				StartCoroutine ("HurtBlinker");
				hurtTime -= Time.deltaTime;
				if(hurtTime <0)
				{
					hurtTime = 1;
					hitted = false;
				}
			}
		} else {

		if (!canMove) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetFloat ("Speed",0); 
			return;

		}

		if (grounded) {
			anim.SetBool ("Swirl", false);
			doubleJumped = false;

		}

		anim.SetBool ("Grounded", grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown("Jump") && grounded)
		{
			jumpSound.pitch = 1f;
			Jump ();


		}

		if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded) 
		{
			anim.SetBool ("Swirl", true);
			jumpSound.pitch = 1.2f;
			Jump ();



			doubleJumped = true;
		}

		//moveVelocity = 0f;

		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");
			Move(Input.GetAxisRaw ("Horizontal"));
			#endif
		if (knockbackCount <= 0)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			if(knockFromRight)
				myrigidbody2d.velocity = new Vector2(-knockback, knockback);
			if (!knockFromRight)
				myrigidbody2d.velocity = new Vector2(knockback, knockback);
			knockbackCount -= Time.deltaTime;


		}

		anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x)); 

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
		{
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

			if (Input.GetButtonDown("Fire1") && FindObjectOfType<PauseMenu>().isPaused == false)
		    {
			shooted = true;
			//Instantiate(bullet, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
			} 

			if(Input.GetButton("Fire1") && FindObjectOfType<PauseMenu>().isPaused == false)
		{
			shotDelayCounter -= Time.deltaTime;

			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				//Instantiate(bullet, firePoint.position, firePoint.rotation);
				shooted = true;

			}
		}

			#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if(Input.GetButton("Fire2"))
		{
			ulted = true;
				
			}
			#endif

		//START KORUTYNY MIGANIA
		if (hitted == true) {
				moveSpeed = 10f;
				accelerationFactor = 0;
				acceleration =1;
			StartCoroutine ("HurtBlinker");
			hurtTime -= Time.deltaTime;
				if(hurtTime <0)
			{
				hurtTime = 1;
				hitted = false;
			}
		}
	}

		if (Input.GetButton("Down") && beastMode == false)
		{
			
			downLook.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 7, gameObject.transform.position.z);
			camera.gameObject.GetComponent<Camera2DFollow> ().target = downLook.transform;
		} 
		if (Input.GetButtonUp("Down") && beastMode == false)
		{
			camera.GetComponent<Camera2DFollow> ().target = this.gameObject.transform;
		}

		//if (Input.GetKey("f"))
		//{
		//	this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
			//this.GetComponent<SpriteRenderer> ().enabled = false;
			//this.moveSpeed = 3f;

		//	godMode = true;

		//}
			


		//if (godMode) 
		//{
		//	this.GetComponent<Rigidbody2D> ().transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		//	this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
		//	if (Input.GetKey ("w")) 
		//	{
		//		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
		//	}

		//	if (Input.GetKey ("s")) 
		//	{
		//		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 0.1f, this.transform.position.z);
		//	}

		//	if (Input.GetKey ("g")) 
		//	{
		//		this.GetComponent<Rigidbody2D> ().transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		//		this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		//		godMode = false;
		//	}
				
		//}



	}






	public void Move(float moveInput)
	{
		moveVelocity = moveSpeed * moveInput;
	}

	public void Flame()
	{
		shooted = true;
	}

	public void Ultimate()
	{
		ulted = true;
	}


	public void Jump()
	{
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, JumpHeight);
		jumpSound.Play();

		if ( grounded)
		{
			jumpSound.pitch = 1f;
			//Jump ();
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, JumpHeight);


		}

		if ( !doubleJumped && !grounded) 
		{
			anim.SetBool ("Swirl", true);
			jumpSound.pitch = 1.2f;
			//Jump ();
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, JumpHeight);



			doubleJumped = true;
		}


	}

	//void OnCollisionEnter2D(Collision2D other)
	//{

	//	if (other.transform.tag == "MovingPlatform") 
	//	{
	//		collisionCount++;
	//		transform.parent = other.transform;

	//	}


	//}
//
	//void OnCollisionExit2D(Collision2D other)
	//{

	//	if (other.transform.tag == "MovingPlatform") 
		//{
		//	collisionCount--;
		//	if (collisionCount == 0) 
		//	{
		//		transform.parent = null;
		//	}
		//}

	//}

	// public void HurtCollider (cośtam)
	//{
	//	Start Courutine HurtBlinker(cośtam) czy jakoś takk
	//}

	//W TYM NADOLE HurtBlinker()  powinno być HurtBlinker(cośtam) a w yieldzie zamiast hurtTime to w nawiasie cośtam

	public IEnumerator HurtBlinker()
	{
		//ignore collision with enemys
		int enemyLayer = LayerMask.NameToLayer ("Enemy");
		int playerLayer = LayerMask.NameToLayer ("Player");

		Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer);

		//start looping blink anim
		anim.SetLayerWeight (1, 1);
		//wait to end unvulnevjdsnble
		yield return new WaitForSeconds(hurtTime);
		//stop blinging and re-enable collision

		Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);
		anim.SetLayerWeight (1, 0);

		hitted = false;
	}
}
