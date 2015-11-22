using UnityEngine;
using System.Collections;

public class DPSAttack : MonoBehaviour {
	public static bool passive;
	Ray ray;
	RaycastHit hit;
	private float distance;
	public Rigidbody projectile;
	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		passive = true;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == ("Enemy") && getDistance()<=5 )
			{
				//passive = false;
				//PlayerController.playerBody.AddForce(getDirection(hit));
				//Debug.Log(hit.collider.gameObject.transform.position - transform.position);
				Debug.Log("hit");
			}

		}
	}

	float getDistance(){
		
			var dist = Mathf.Abs (transform.position.y - Camera.main.transform.position.y);
			var v3pos = new Vector3 (Input.mousePosition.x,dist, Input.mousePosition.z );
			v3pos = Camera.main.ScreenToWorldPoint (v3pos);
			var distanceBetween = Vector3.Distance (v3pos, transform.position);
		return distanceBetween - Vector3.Distance(transform.position,Camera.main.transform.position);
	}
	Vector3 getDirection(RaycastHit hit){
		//Debug.Log ((hit.collider.gameObject.transform.position - transform.position) * 20);
		return (hit.collider.gameObject.transform.position - this.transform.position) * 25;
	}
}
