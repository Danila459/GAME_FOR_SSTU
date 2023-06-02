using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	public float enemyhealth;
	public Slider enemyHealthBar;
	float currhealth;
	public bool drops;
	public GameObject thedrop;
	public AudioClip deathKnell;

	void Start () {
		currhealth = enemyhealth;
		enemyHealthBar.maxValue = currhealth;
		enemyHealthBar.value = currhealth;
	}

	void Update () {

	}
	public void DiDor(float damage){
		currhealth = currhealth - damage;
		enemyHealthBar.value = currhealth;
		if(currhealth<=0){
			makeDead();
		}
	}
	public void makeDead(){
		AudioSource.PlayClipAtPoint(deathKnell, transform.position);
		Destroy(gameObject);
		 if(drops) Instantiate(thedrop,transform.position, transform.rotation);

	}
}
