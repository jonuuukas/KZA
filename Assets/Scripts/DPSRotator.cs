using UnityEngine;
using System.Collections;

public class DPSRotator : MonoBehaviour {


	Transform sphere;
	public Transform center;
	// Use this for initialization
	void Start () {
		sphere = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(DPSAttack.passive)
		sphere.RotateAround (center.position, Vector3.up , 180 * Time.fixedDeltaTime );
	}
}
