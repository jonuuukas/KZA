using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {
	Transform target;
	NavMeshAgent navigator;
	SphereCollider trigger;
	bool hasTarget = false;
    Vector3 startPosition;
    float moveTimer;
    Vector3 nextPosition;
    float nextX;
    float nextZ;

	// Use this for initialization
	void Start () {
		trigger = GetComponent<SphereCollider> ();
		navigator = GetComponent<NavMeshAgent> ();
        startPosition = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        moveTimer += Time.deltaTime;
		if (hasTarget) {
			navigator.destination = target.position;
		}
        if (!hasTarget && moveTimer >= 5.0f) {
            navigator.destination = NextPosition();
            moveTimer = 0;
        }
        
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && hasTarget == false)
        {
            target = col.gameObject.transform;
            hasTarget = true;
        }   
    }

    void OnTriggerExit(Collider col)
    { 
        if (col.gameObject.tag == "Player" && hasTarget == true)
        {
            target = null;
            hasTarget = false;
        }
    }

    Vector3 NextPosition(){
        nextX = (Random.value - 0.5f) * 10;
        nextZ = (Random.value - 0.5f) * 10;
        nextPosition = new Vector3(startPosition.x + nextX, startPosition.y, startPosition.z + nextZ);

        return nextPosition;
    }
}
