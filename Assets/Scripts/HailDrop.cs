using UnityEngine;
using System.Collections;

public class HailDrop : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		//Destroy (transform.parent.gameObject,3f);
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
	void OnCollisionEnter(Collision coll)
    {
		if (coll.gameObject.tag == "Enemy") {
			var targetHealth = coll.gameObject.GetComponent<EnemyHealth>();
			targetHealth.healthPoints -= DPSSkills.attackDamage;
		}		
	}
}
