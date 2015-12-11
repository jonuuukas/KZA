using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TankSkills : MonoBehaviour {
    public float singleAttackCooldown = 0.5f;
    public float massTauntCooldown = 10.0f;
    public int attackDamage = 10;

    private float singleAttackCooldownPlaceholder;
    private float massTauntCooldownPlaceholder;
    private bool isSingleAttackOnCooldown;
    private bool isMassTauntOnCooldown;

    public List<GameObject> EnemiesInRange = new List<GameObject>();
    public GameObject tanksTarget;

    // Use this for initialization
    void Start ()
    {
        tanksTarget = null;
        isSingleAttackOnCooldown = false;
        isMassTauntOnCooldown = false;
        singleAttackCooldownPlaceholder = 0.0f;
        massTauntCooldownPlaceholder = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerController.currentPlayer.name == "PlayerTank")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    SingleAttack(hit.transform.gameObject);
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                MassTaunt();
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

        if (isMassTauntOnCooldown == true)
        {
            massTauntCooldownPlaceholder -= Time.deltaTime;
            if (massTauntCooldownPlaceholder < 0)
            {
                isMassTauntOnCooldown = false;
            }
        }

        if (EnemiesInRange.Count > 0)
        {
            foreach (var enemy in EnemiesInRange.ToList())
            {
                if (enemy == null)
                {
                    EnemiesInRange.Remove(enemy);
                }
            }
        }

        foreach (var enemy in EnemiesInRange.ToList())
        {
            if (enemy == null)
            {
                EnemiesInRange.Remove(enemy);
            }
        }
    }

    public void SingleAttack(GameObject target)
    {
        if (isSingleAttackOnCooldown == false)
        {
            if (target.tag == "Enemy")
            {
                var targetHealth = target.GetComponent<EnemyHealth>();
                if (targetHealth.healthPoints > 0)
                {
                    if ((Vector3.Distance(this.gameObject.transform.position, target.gameObject.transform.position)) < 3.8f)
                    {
                        targetHealth.healthPoints -= attackDamage;
                        // Can do something here about setting target of the enemy
                        tanksTarget = target;
                        isSingleAttackOnCooldown = true;
                        singleAttackCooldownPlaceholder = singleAttackCooldown;
                    }
                }
                else
                {
                    tanksTarget = null;
                }                           
            }           
        }
    }

    public void MassTaunt()
    {
        if (isMassTauntOnCooldown == false)
        {
            foreach (var enemy in EnemiesInRange)
            {
                var enemyBehavior = enemy.GetComponent<EnemyFollow>();
                enemyBehavior.hasTarget = true;
                enemyBehavior.target = this.gameObject.transform;
            }
            isMassTauntOnCooldown = true;
            massTauntCooldownPlaceholder = massTauntCooldown;
        }
    }

    public void OnTriggerEnter(Collider col)
    {        
        if (col.gameObject.tag == "Enemy")
        {
            var enemyInList = EnemiesInRange.Find(e => e == col.gameObject);
            if (enemyInList == null)
            {
                EnemiesInRange.Add(col.gameObject);
            }
        }
    }
    public void OnTriggerExit(Collider col)
    {       
        if (col.gameObject.tag == "Enemy")
        {
            foreach (var enemy in EnemiesInRange.ToList())
            {
                if (enemy == col.gameObject)
                {
                    EnemiesInRange.Remove(col.gameObject);

                }
            }
        }
    }
}
