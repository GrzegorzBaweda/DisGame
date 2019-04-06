using UnityEngine;
using System.Collections;

public class Explosions : MonoBehaviour {

	public GameObject explosion;
	public Transform point1;
	public Transform point2;
	public Transform point3;
	public Transform point4;
	public Transform point5;
	public Transform point6;
	public Transform point7;
	public Transform point8;
	public Transform point9;
	public Transform point10;


	// Use this for initialization
	void Start () {
		StartCoroutine ("ExplodeCo");
	}
	void Update ()
	{
		transform.position = FindObjectOfType<EnemyHealthManager> ().transform.position;
	}
	
	// Update is called once per frame

	public IEnumerator ExplodeCo()
	{
		yield return new WaitForSeconds(0.5f);
		Instantiate(explosion, point1.transform.position, point1.transform.rotation);
		yield return new WaitForSeconds(0.5f);
		Instantiate(explosion, point2.transform.position, point2.transform.rotation);
		yield return new WaitForSeconds(0.5f);
		Instantiate(explosion, point3.transform.position, point3.transform.rotation);
		yield return new WaitForSeconds(0.4f);
		Instantiate(explosion, point4.transform.position, point4.transform.rotation);
		yield return new WaitForSeconds(0.4f);
		Instantiate(explosion, point5.transform.position, point5.transform.rotation);
		yield return new WaitForSeconds(0.3f);
		Instantiate(explosion, point6.transform.position, point6.transform.rotation);
		yield return new WaitForSeconds(0.3f);
		Instantiate(explosion, point7.transform.position, point7.transform.rotation);
		yield return new WaitForSeconds(0.2f);
		Instantiate(explosion, point8.transform.position, point8.transform.rotation);
		yield return new WaitForSeconds(0.2f);
		Instantiate(explosion, point9.transform.position, point9.transform.rotation);
		Instantiate(explosion, point10.transform.position, point10.transform.rotation);
		yield return new WaitForSeconds(0.1f);
		Instantiate(explosion, point5.transform.position, point5.transform.rotation);
		Instantiate(explosion, point1.transform.position, point1.transform.rotation);
		yield return new WaitForSeconds(0.1f);
		Instantiate(explosion, point2.transform.position, point2.transform.rotation);
		Instantiate(explosion, point3.transform.position, point3.transform.rotation);
		Instantiate(explosion, point4.transform.position, point4.transform.rotation);
		Instantiate(explosion, point5.transform.position, point5.transform.rotation);

	}
}
