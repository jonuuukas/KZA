using UnityEngine;
using System.Collections;

public class DPSAttack : MonoBehaviour {

	public static bool passive = true;
	private float distance;
	public float projSpeed = 600f;
	public Rigidbody projectile;
	public GameObject projectileObject;
	GameObject clone;
	Ray ray;
	RaycastHit hit;

	void Start () {
		passive = true;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == ("Enemy") && getDistance()<=5 && !EnemyHealth.isDead)
			{

				Shoot ();
				Debug.Log (hit.transform.name);
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
		return (hit.collider.gameObject.transform.position - this.transform.position);

	}

	Vector3 getPosition(RaycastHit hit){
		return (hit.collider.gameObject.transform.position - (transform.position - projectile.transform.position)* 3);
	}

	void Shoot(){
		clone = Instantiate(projectileObject, getPosition(hit), transform.rotation) as GameObject;
		clone.GetComponent<Rigidbody> ().AddForce (-(clone.transform.position-hit.collider.transform.position) * projSpeed);
		Destroy (clone, 0.2f);
	}
}
