using UnityEngine;
using System.Collections;

public class HealerHealth : MonoBehaviour {
    public static int healthPoints;
    public static int maxHealthPoints = 100;
    public static int manaPoints;
    public static int maxManaPoints = 100;
    // Use this for initialization
    void Start () {
        manaPoints = maxHealthPoints;
        healthPoints = maxHealthPoints;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
