using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

	public EnemyHealthManager enemyHealthScript;
	public Slider healthBar;


	// Use this for initialization
	void Start () {
		healthBar.maxValue = enemyHealthScript.enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = enemyHealthScript.enemyHealth;
	}
}
