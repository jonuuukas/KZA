using UnityEngine;
using System.Collections;

public class HealerHealth : MonoBehaviour {
    public static int currentHealthPoints;
    public static int maxHealthPoints = 100;
    public static int currentManaPoints;
    public static int maxManaPoints = 100;
    // Use this for initialization
    void Start () {
        currentManaPoints = maxHealthPoints;
        currentHealthPoints = maxHealthPoints;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealthPoints > maxHealthPoints)
        {
            currentHealthPoints = maxHealthPoints;
        }
        if (currentManaPoints > maxManaPoints)
        {
            currentManaPoints = maxManaPoints;
        }
    }
}
