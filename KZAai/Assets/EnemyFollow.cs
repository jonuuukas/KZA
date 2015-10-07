using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {
	Transform target;
	NavMeshAgent navigator;
	SphereCollider trigger;
	bool hasTarget = false;
	// Use this for initialization
	void Start () {
		trigger = GetComponent<SphereCollider> ();
		navigator = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (hasTarget) {
			navigator.destination = target.position;
		}
	}
	void OnTriggerEnter(Collider col){
		Debug.Log ("Entered");
		if (col.gameObject.tag == "Player" && hasTarget==false) {
			target = col.gameObject.transform;
			hasTarget = true;
		}
	}
}
