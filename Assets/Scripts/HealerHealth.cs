using UnityEngine;
using System.Collections;

public class HealerHealth : MonoBehaviour {
    public static int currentHealthPoitns;
    public static int maxHealthPoints = 100;
    public static int currentManaPoints;
    public static int maxManaPoints = 100;
    // Use this for initialization
    void Start () {
        currentManaPoints = maxHealthPoints;
        currentHealthPoitns = maxHealthPoints;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealthPoitns > maxHealthPoints)
        {
            currentHealthPoitns = maxHealthPoints;
        }
        if (currentManaPoints > maxManaPoints)
        {
            currentManaPoints = maxManaPoints;
        }
    }
}
