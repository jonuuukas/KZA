using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject spawnObject;
	// Use this for initialization
	void Start () {
		Instantiate (spawnObject, transform.position,transform.rotation);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
