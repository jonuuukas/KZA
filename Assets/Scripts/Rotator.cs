using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public float speed = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.up, speed * Time.fixedDeltaTime);
	}
}
