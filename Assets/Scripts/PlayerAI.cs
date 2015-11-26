using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {
	public Rigidbody playerDps;
	public Rigidbody playerHeal;
	public Rigidbody playerTank;
	public static GameObject currentPlayer;
	Rigidbody target;
	float K;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.currentPlayer.name == "PlayerDPS")
			FollowDPS ();
		else if (PlayerController.currentPlayer.name == "PlayerHealer")
			FollowHeal ();
		else if (PlayerController.currentPlayer.name == "PlayerTank")
			FollowTank();
	}
	void FollowDPS(){

		playerHeal.AddForce (getDirection(playerDps,playerHeal));
		playerTank.AddForce (getDirection(playerDps,playerTank));
		playerTank.AddForce (getDirection(playerHeal,playerTank));
		playerHeal.AddForce (getDirection(playerTank,playerHeal));


	}
	void FollowHeal(){

		playerDps.AddForce (getDirection(playerHeal,playerDps));
		playerTank.AddForce (getDirection(playerHeal,playerTank));
		playerTank.AddForce (getDirection(playerDps,playerTank));
		playerDps.AddForce (getDirection(playerTank,playerDps));

	}
	void FollowTank(){

		/*playerHeal.AddForce (getDirection(playerTank,playerHeal));
		playerDps.AddForce (getDirection(playerTank,playerDps));
		playerDps.AddForce (getDirection(playerHeal,playerDps));
		playerHeal.AddForce (getDirection(playerDps,playerHeal));*/
		
	}

	Vector3 getDirection(Rigidbody target, Rigidbody other){

		K = Vector3.Distance (target.position,other.position) / 2 ;
		var x = (target.position - other.position).normalized / (K * K) ;
		var y = -(target.position - other.position).normalized / (K * K * K);
		return (x + y) * 10;
	}

}
