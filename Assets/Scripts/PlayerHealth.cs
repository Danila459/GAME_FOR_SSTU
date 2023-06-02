using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	public float fullHealth;
	float currentHealth;
	public AudioClip playerHurt;
	AudioSource playerAS;

	PlayerController playerControl;

	public Slider heartBar;
	public Image damageScreen;
	bool damaged = false;
	Color damagedColour = new Color(5f,5f,0f,0.5f);
	float smoothColour = 5f;

	void Start () {
		currentHealth = fullHealth;
		playerControl = GetComponent<PlayerController>();

		heartBar.maxValue=fullHealth;
		heartBar.value=fullHealth;

		playerAS =GetComponent<AudioSource>();

		damaged = false;
	}

	void Update () {
		if(damaged){
			damageScreen.color = damagedColour;
		}else{
			damageScreen.color = Color.Lerp(damageScreen.color, Color.clear,smoothColour*Time.deltaTime);
		}
		damaged = false;

	}

	public void addDamage(float damage){
		if(damage<=0) return;
		currentHealth = currentHealth - damage;
		playerAS.PlayOneShot(playerHurt);
		heartBar.value = currentHealth;
		damaged = true;

		if(currentHealth<=0){
			makeDead();
		}
	}
	public void addHealth(float health){
		currentHealth += health;
		if(currentHealth>fullHealth) currentHealth=fullHealth;
		heartBar.value =currentHealth;
	}
	public void makeDead(){
		SceneManager.LoadScene(3);
	}
}
