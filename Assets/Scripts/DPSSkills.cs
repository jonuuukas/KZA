using UnityEngine;
using System.Collections;

public class DPSSkills : MonoBehaviour {

	public static bool passive = true;
	private float singleAttackCooldownPlaceholder;
	private bool isSingleAttackOnCooldown;
	private float massAttackCooldownPlaceholder;
	private bool isMassAttackOnCooldown;

	private float distance;
	public float projSpeed = 600f;
	public float singleAttackCooldown = 0.5f;
	public float massAttackCooldown = 2f;


	public static int attackDamage = 10;

	public Rigidbody projectile;
	public GameObject projectileObject;
	public GameObject massAttack;


	GameObject target;
	GameObject clone;
	Ray ray;
	RaycastHit hit;

	void Start () {
		passive = true;
		isSingleAttackOnCooldown = false;
		singleAttackCooldownPlaceholder = 0.0f;
		isMassAttackOnCooldown = false;
		massAttackCooldownPlaceholder = 0.0f;
	}

	void Update () {
		if (PlayerController.currentPlayer.name == "PlayerDPS")
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.GetMouseButtonDown(0))
            {
				if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == ("Enemy") && getDistance() <= 5 && !EnemyHealth.isDead && !isSingleAttackOnCooldown)
                {
					target = hit.transform.gameObject;
                    Shoot();
                }
            }
		
				if (Input.GetMouseButtonDown (1)) {
				if (Physics.Raycast(ray, out hit) && getDistance() <= 5 && !isMassAttackOnCooldown)
				{
					MassAttack ();
				}
				}
		if (isSingleAttackOnCooldown == true)
		{
			singleAttackCooldownPlaceholder -= Time.deltaTime;
			if (singleAttackCooldownPlaceholder < 0)
			{
				isSingleAttackOnCooldown = false;
			}
		}
			if (isMassAttackOnCooldown == true)
			{
				massAttackCooldownPlaceholder -= Time.deltaTime;
				if (massAttackCooldownPlaceholder < 0)
				{
					isMassAttackOnCooldown = false;
				}
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
		var targetHealth = target.GetComponent<EnemyHealth>();
			targetHealth.healthPoints -= attackDamage;
			isSingleAttackOnCooldown = true;
			singleAttackCooldownPlaceholder = singleAttackCooldown;
			clone = Instantiate(projectileObject, getPosition(hit), transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce (-(clone.transform.position-hit.collider.transform.position) * projSpeed);
			Destroy (clone, 0.2f);
	}
	void MassAttack(){
		Instantiate (massAttack, hit.point + new Vector3(0,10,0), transform.rotation);
		isMassAttackOnCooldown = true;
		massAttackCooldownPlaceholder = massAttackCooldown;
	}
}
