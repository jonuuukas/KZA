using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	Transform cameraPos;	// Use this for initialization
	void Start () {
		cameraPos = GetComponent<Transform> ();
		cameraPos.position = PlayerController.currentPlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		cameraPos.position = PlayerController.currentPlayer.transform.position + new Vector3(0,20,-23);
	}
}
