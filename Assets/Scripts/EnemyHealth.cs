﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int healthPoints;
    public int maxHealthPoints = 100;
    private Image healthBar;
	public bool isDead = false;
    // Use this for initialization
    void Start () {
        healthPoints = maxHealthPoints;
        healthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBG").FindChild("Health").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (healthPoints <= 0) {
			Destroy (gameObject, 0.2f);
		}
        healthBar.fillAmount = (float)healthPoints / (float)maxHealthPoints;
    }

	void getDamage(int damagePoints){
		healthPoints -= damagePoints;
	}

	void OnCollisionEnter(Collision coll){
		if (coll.transform.tag == "Projectile" && !isDead) {
			Debug.Log ("hit");	
			getDamage (10);
		}
	
	}
}
