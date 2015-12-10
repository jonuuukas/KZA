using UnityEngine;
using System.Collections;

public class HealerSkills : MonoBehaviour {
    public int singleHealPower = 30;
    public int massHealPower = 15;
    public int singleHealManaCost = 10;
    public int massHealManaCost = 20;
    public float singleHealCooldown = 4.0f;
    public float massHealCooldown = 10.0f;
    public bool isSingleHealOnCooldown;
    public bool isMassHealOnCooldown;

    private float singleHealCooldownPlaceholder;
    private float massHealCooldownPlaceholder;
	// Use this for initialization
	void Start () {
        isSingleHealOnCooldown = false;
        isMassHealOnCooldown = false;
        singleHealCooldownPlaceholder = 0.0f;
        massHealCooldownPlaceholder = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerController.currentPlayer.name == "PlayerHealer")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    CastSingleHeal(hit.transform.gameObject);
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                CastMassHeal();
            } 
        }

        if (isSingleHealOnCooldown == true)
        {
            singleHealCooldownPlaceholder -= Time.deltaTime;
            if (singleHealCooldownPlaceholder < 0)
            {
                isSingleHealOnCooldown = false;
            }
        }

        if (isMassHealOnCooldown == true)
        {
            massHealCooldownPlaceholder -= Time.deltaTime;
            if (massHealCooldownPlaceholder < 0)
            {
                isMassHealOnCooldown = false;
            }
        } 
    }

    public void CastSingleHeal(GameObject target)
    {
        if (isSingleHealOnCooldown == false)
        {
            if (HealerHealth.currentManaPoints >= singleHealManaCost)
            {               
                switch (target.name)
                {
                    case "PlayerHealer":
                        HealerHealth.currentHealthPoints += singleHealPower;
                        break;
                    case "PlayerTank":
                        TankHealth.currentHealthPoints += singleHealPower;
                        break;
                    case "PlayerDPS":
                        DPSHealth.currentHealthPoints += singleHealPower;
                        break;
                    default:
                        break;
                }
                Debug.Log(target);
                HealerHealth.currentManaPoints -= singleHealManaCost;
                isSingleHealOnCooldown = true;
                singleHealCooldownPlaceholder = singleHealCooldown;
                // Something is broken with mouse click target 
                
            }
        }         
    }

    public void CastMassHeal()
    {
        if (isMassHealOnCooldown == false)
        {
            if (HealerHealth.currentManaPoints >= massHealManaCost)
            {
                HealerHealth.currentHealthPoints += massHealPower;
                TankHealth.currentHealthPoints += massHealPower;
                DPSHealth.currentHealthPoints += massHealPower;

                HealerHealth.currentManaPoints -= massHealManaCost;
                isMassHealOnCooldown = true;
                massHealCooldownPlaceholder = massHealCooldown;
            }
        }
    }
}
