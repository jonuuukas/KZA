using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour {
    public float attackInterval = 2.0f;
    public float elapsedTime = 0.0f;
    public int damage = 7;
    private int multiplierByClass;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time > elapsedTime)
            {
                attack(collision.gameObject);
                elapsedTime = Time.time + attackInterval;
            }
        }
    }

    void attack(GameObject player)
    {       
        switch (player.name)
        {
            case "PlayerDPS":
                multiplierByClass = 2;
                DPSHealth.currentHealthPoints -= damage * multiplierByClass;
                break;
            case "PlayerHealer":
                multiplierByClass = 3;
                HealerHealth.currentHealthPoitns -= damage * multiplierByClass;
                break;
            case "PlayerTank":
                multiplierByClass = 1;
                TankHealth.currentHealthPoints -= damage * multiplierByClass;
                break;
            default:
                break;
        }
    }
}
