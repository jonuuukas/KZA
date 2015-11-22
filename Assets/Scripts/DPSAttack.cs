using UnityEngine;
using System.Collections;

public class DPSAttack : MonoBehaviour {
	public static bool passive;
	Ray ray;
	RaycastHit hit;
	private float distance;

	// Use this for initialization
	void Start () {
		passive = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.Log(getDistance ());
			//Debug.Log(Vector3.Distance(transform.position,Camera.main.transform.position));
			/*Debug.Log (ray.origin.x - parentTransform.position.x);
			Debug.Log(ray.origin.z - parentTransform.position.z);*/
			/*Debug.Log (ray.origin);
			Debug.Log (parentTransform.position);
			Debug.Log (parentTransform.gameObject.name);*/
			//Debug.Log (Vector3.Distance(Camera.main.transform.position, parentTransform.position));
			getDistance();
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == ("Enemy") && getDistance()<=5 )
			{

				Debug.Log("hit");
			}

		}
	}

	float getDistance(){
			var dist = Mathf.Abs (transform.position.y - Camera.main.transform.position.y);
		var v3pos = new Vector3 (Input.mousePosition.x,dist, Input.mousePosition.z );
			v3pos = Camera.main.ScreenToWorldPoint (v3pos);
			var distanceBetween = Vector3.Distance (v3pos, transform.position);
		//Debug.Log (distanceBetween - Vector3.Distance(transform.position,Camera.main.transform.position));
		return distanceBetween - Vector3.Distance(transform.position,Camera.main.transform.position);
	}
}
