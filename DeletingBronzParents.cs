using UnityEngine;
using System.Collections;

public class DeletingBronzParents : MonoBehaviour {

	public GameObject Bronz;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	if(Bronz == !isActiveAndEnabled)
			{
			Destroy(gameObject);
			}
	}
}
