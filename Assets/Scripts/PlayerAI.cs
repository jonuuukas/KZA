using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {
	public NavMeshAgent playerDps;
	public NavMeshAgent playerHeal;
	public NavMeshAgent playerTank;
	public static GameObject currentPlayer;
	Rigidbody target;


	// Use this for initialization
	void Start () {
		FollowDPS ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FollowDPS(){
		playerDps.enabled = false;
		target = PlayerController.playerBody;
		Debug.Log (target.gameObject.name);

		playerHeal.destination = target.position + new Vector3(1,0,-1);
		playerTank.destination = target.position + new Vector3(-1,0,-1);

	}
	void FollowHeal(){
		playerHeal.enabled = false;
		target = currentPlayer.GetComponent<Rigidbody> ();
		playerDps.destination = target.position + new Vector3(1,0,0);
		playerTank.destination = target.position + new Vector3(-1,0,-1);
		
	}
	void FollowTank(){
		playerTank.enabled = false;
		target = currentPlayer.GetComponent<Rigidbody> ();
		playerHeal.destination = target.position + new Vector3(1,0,-1);
		playerDps.destination = target.position + new Vector3(1,0,0);
		
	}
}
