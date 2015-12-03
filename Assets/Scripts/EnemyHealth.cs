using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int healthPoints = 100;
	public static bool isDead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (healthPoints <= 0) {
			Destroy (gameObject, 0.5f);
		}
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
