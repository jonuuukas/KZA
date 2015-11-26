﻿using UnityEngine;
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
	void FixedUpdate () {
		if (PlayerController.currentPlayer.name == "PlayerDPS")
			FollowDPS ();
		if (PlayerController.currentPlayer.name == "PlayerHealer")
			FollowHeal ();
		if (PlayerController.currentPlayer.name == "PlayerTank")
			FollowTank();
	}
	void FollowDPS(){

		playerHeal.AddForce (getDirection(playerDps,playerHeal));
		playerTank.AddForce (getDirection(playerDps,playerTank));
		playerTank.AddForce (getDirection(playerHeal,playerTank)*2);
		playerHeal.AddForce (getDirection(playerTank,playerHeal)*2);


	}
	void FollowHeal(){


		playerDps.AddForce (getDirection(playerHeal,playerDps));
		playerTank.AddForce (getDirection(playerHeal,playerTank));
		playerTank.AddForce (getDirection(playerDps,playerTank));
		playerDps.AddForce (getDirection(playerTank,playerDps));

	}
	void FollowTank(){

		playerHeal.AddForce (getDirection(playerTank,playerHeal));
		playerDps.AddForce (getDirection(playerTank,playerDps));
		playerDps.AddForce (getDirection(playerHeal,playerDps));
		playerHeal.AddForce (getDirection(playerDps,playerHeal));

	}

	Vector3 getDirection(Rigidbody target, Rigidbody other){

		K = Vector3.Distance (target.position,other.position) / 3;
		var x = K * (target.position - other.position).normalized / (K * K) ;
		var y = -K * (target.position - other.position).normalized / (K * K * K);
		return (x + y) * 10;
	}

}
