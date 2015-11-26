using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	int playerCounter = 0;
	public GameObject[] characterSet;
	public static GameObject currentPlayer;
	public static Rigidbody playerBody;
	float maxSpeed = 8;

	// Use this for 	initialization
	void Start () {
		AssignPlayer (playerCounter);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up") || Input.GetKey("w")) {
			playerBody.AddForce(Vector3.forward);
		}
		if (Input.GetKey ("down")|| Input.GetKey("s")) {
			playerBody.AddForce(Vector3.back);
		}
		if (Input.GetKey ("left") || Input.GetKey("a")) {
			playerBody.AddForce(Vector3.left);
		}
		if (Input.GetKey ("right") || Input.GetKey("d")) {
			playerBody.AddForce(Vector3.right);
		}
		if (Input.GetKeyDown ("q")) {
			playerCounter-=1;
			if (playerCounter < 0) {
				playerCounter=2;
			}
			AssignPlayer(playerCounter);
		}
		if (Input.GetKeyDown ("e")) {
			playerCounter+=1;
			if(playerCounter>2){
				playerCounter=0;
			}
			AssignPlayer(playerCounter);
		}
		if (playerBody.velocity.magnitude > maxSpeed) {
			playerBody.velocity = playerBody.velocity.normalized * maxSpeed;
		}
	}
	
	void AssignPlayer(int i){
		currentPlayer = characterSet [i];
		playerBody = currentPlayer.GetComponent<Rigidbody> ();

	}
	void OnCollisionEnter(Collision coll){
		Debug.Log (coll.gameObject.name);
		}
}
