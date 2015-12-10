using UnityEngine;
using System.Collections;

public class DPSHailAttack : MonoBehaviour {
	public GameObject bullet;
	public int hailCounter = 25;

	private float counter= 0;
	private GameObject clone;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Attack");
	}
	void Update(){
		if (counter >= hailCounter) {
			StopCoroutine ("Attack");
			Destroy (gameObject,0.5f);
		}
	}
	// Update is called once per frame
	IEnumerator Attack(){
		
		while (counter < hailCounter) {
	
			yield return new WaitForSeconds (0.3f);
	
			clone = Instantiate (bullet, transform.position - new Vector3 (Random.Range (-2f, 2f)*3, 0, Random.Range (-2f, 2f)*4), Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce (Vector3.down * 100 );
			counter += 1; 
		}
	}
}
