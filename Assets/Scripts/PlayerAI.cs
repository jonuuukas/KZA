using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerAI : MonoBehaviour {
	public Rigidbody playerDps;
	public Rigidbody playerHeal;
	public Rigidbody playerTank;

    public GameObject healer;
    public GameObject dps;
    public GameObject tank;

    private bool isEnemyInTanksRange;
    private GameObject tanksTarget;

	Rigidbody target;
	float K;
	public static bool onChange = false;

	// Use this for initialization
	void Start () {
        healer = GameObject.Find("PlayerHealer");
        tank = GameObject.Find("PlayerTank");
        dps = GameObject.Find("PlayerDPS");

        isEnemyInTanksRange = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (PlayerController.currentPlayer.name == "PlayerDPS")
        {
            if (isEnemyInTanksRange)
            {
                FollowDPSWithoutTank();               
            }
            else
            {
                FollowDPS();
            }
            TankAI();
            HealerAI();           
        }
		if (PlayerController.currentPlayer.name == "PlayerHealer")
        {
            if (isEnemyInTanksRange)
            {
                FollowHealWithoutTank();             
            }
            else
            {
                FollowHeal();
            }
            TankAI();
            DPSAI();
        }
        
		if (PlayerController.currentPlayer.name == "PlayerTank")
        {
            FollowTank();
            HealerAI();
            DPSAI();
        }
			
		if (onChange == true)
        {
            Change();
        }			
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
		playerTank.AddForce (getDirection(playerDps,playerTank)*2);
		playerDps.AddForce (getDirection(playerTank,playerDps)*2);

	}
    void FollowDPSWithoutTank()
    {

        playerHeal.AddForce(getDirection(playerDps, playerHeal));
        playerHeal.AddForce(getDirection(playerDps, playerHeal) * 2);

    }
    void FollowHealWithoutTank()
    {

        playerDps.AddForce(getDirection(playerHeal, playerDps));
        playerDps.AddForce(getDirection(playerTank, playerDps) * 2);

    }
    void FollowTank(){

		playerHeal.AddForce (getDirection(playerTank,playerHeal));
		playerDps.AddForce (getDirection(playerTank,playerDps));
		playerDps.AddForce (getDirection(playerHeal,playerDps)*2);
		playerHeal.AddForce (getDirection(playerDps,playerHeal)*2);

	}

	Vector3 getDirection(Rigidbody target, Rigidbody other){

		K = Vector3.Distance (target.position,other.position) / 8;
		var x = K * (target.position - other.position).normalized / (K * K) ;
		var y = -K * (target.position - other.position).normalized / (K * K * K);
		return (x + y) * 10;
	}

	void Change(){
		playerDps.velocity = Vector3.zero;
		playerHeal.velocity = Vector3.zero;
		playerTank.velocity = Vector3.zero;
		onChange = false;
	}

    void TankAI()
    {
        if (tank.GetComponent<TankSkills>().EnemiesInRange.Count > 2)
        {
            tank.GetComponent<TankSkills>().MassTaunt();
        }
        if (tank.GetComponent<TankSkills>().EnemiesInRange.Count > 0)
        {
            isEnemyInTanksRange = true;
            tanksTarget = tank.GetComponent<TankSkills>().EnemiesInRange.OrderBy(e => Vector3.Distance(tank.transform.position, e.transform.position)).First();

            if (tanksTarget != null)
            {
                if (Vector3.Distance(tank.transform.position, tanksTarget.transform.position) > 2.8f)
                {
                    tank.GetComponent<TankSkills>().SingleAttack(tanksTarget);
                    playerTank.AddForce((tanksTarget.transform.position - tank.transform.position));                    
                }
            }
            else
            {
                if (tank.GetComponent<TankSkills>().EnemiesInRange.Count > 0)
                {
                    tanksTarget = tank.GetComponent<TankSkills>().EnemiesInRange.OrderBy(e => Vector3.Distance(tank.transform.position, e.transform.position)).First();
                }
                else
                {
                    isEnemyInTanksRange = false;
                }               
            }
        }
        else
        {
            isEnemyInTanksRange = false;
        }
        //if (TankHealth.currentHealthPoints < 15)
        //{
        //    isEnemyInTanksRange = false;
        //}
    }

    void DPSAI()
    {
        if (tank.GetComponent<TankSkills>().EnemiesInRange.Count > 2)
        {
            dps.GetComponent<DPSSkills>().MassAttack(tank.transform.position);
        }
        if (tank.GetComponent<TankSkills>().EnemiesInRange.Count > 0)
        {
            if (tank.GetComponent<TankSkills>().tanksTarget != null)
            {
                dps.GetComponent<DPSSkills>().Shoot(tank.GetComponent<TankSkills>().tanksTarget);
            }          
        }
    }

    void HealerAI()
    {
        if ((HealerHealth.currentHealthPoints < 80) && (TankHealth.currentHealthPoints < 80) && (DPSHealth.currentHealthPoints < 80))
        {
            if (!healer.GetComponent<HealerSkills>().isMassHealOnCooldown)
            {
                if (HealerHealth.currentManaPoints > healer.GetComponent<HealerSkills>().massHealManaCost)
                {
                    healer.GetComponent<HealerSkills>().CastMassHeal();
                }
            }
        }
        if (HealerHealth.currentHealthPoints < 75)
        {
            if (!healer.GetComponent<HealerSkills>().isSingleHealOnCooldown)
            {
                if (HealerHealth.currentManaPoints > healer.GetComponent<HealerSkills>().singleHealManaCost)
                {
                    healer.GetComponent<HealerSkills>().CastSingleHeal(healer);
                }
            }
        }
        if (TankHealth.currentHealthPoints < 75)
        {
            if (!healer.GetComponent<HealerSkills>().isSingleHealOnCooldown)
            {
                if (HealerHealth.currentManaPoints > healer.GetComponent<HealerSkills>().singleHealManaCost)
                {
                    healer.GetComponent<HealerSkills>().CastSingleHeal(tank);
                }
            }
        }
        if (DPSHealth.currentHealthPoints < 75)
        {
            if (!healer.GetComponent<HealerSkills>().isSingleHealOnCooldown)
            {
                if (HealerHealth.currentManaPoints > healer.GetComponent<HealerSkills>().singleHealManaCost)
                {
                    healer.GetComponent<HealerSkills>().CastSingleHeal(dps);
                }
            }
        }
    }
}
