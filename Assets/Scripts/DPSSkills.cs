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
	public float singleAttackCooldown = 1.5f;
	public float massAttackCooldown = 5.0f;


	public static int attackDamage = 10;

	public Rigidbody projectile;
	public GameObject projectileObject;
	public GameObject massAttack;


	GameObject target;
	GameObject clone;

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
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Shoot(hit.transform.gameObject);
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    MassAttack(hit.point);
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

	public void Shoot(GameObject target)
    {
        if (isSingleAttackOnCooldown == false)
        {
            if (target.tag == "Enemy")
            {
                var targetHealth = target.GetComponent<EnemyHealth>();
                if (targetHealth.healthPoints > 0)
                {
                    if ((Vector3.Distance(this.gameObject.transform.position, target.gameObject.transform.position)) < 30.0f)
                    {

                        targetHealth.healthPoints -= attackDamage;
                        // Can do something here about setting target of the enemy
                        isSingleAttackOnCooldown = true;
                        singleAttackCooldownPlaceholder = singleAttackCooldown;

                        //clone = Instantiate(projectileObject, getPosition(hit), transform.rotation) as GameObject;
                        //clone.GetComponent<Rigidbody>().AddForce(-(clone.transform.position - hit.collider.transform.position) * projSpeed);
                        //Destroy(clone, 0.2f);
                        Debug.Log("Single shoot " + singleAttackCooldownPlaceholder);
                    }
                }              
            }
        }
	}
	public void MassAttack(Vector3 target)
    {
        if (isMassAttackOnCooldown == false)
        {
            if (getDistance() <= 5)
            {
                Instantiate(massAttack, target + new Vector3(0, 10, 15), transform.rotation);
                isMassAttackOnCooldown = true;
                massAttackCooldownPlaceholder = massAttackCooldown;
                Debug.Log("Mass shoot " + massAttackCooldownPlaceholder);
            }
        }		
	}
}
