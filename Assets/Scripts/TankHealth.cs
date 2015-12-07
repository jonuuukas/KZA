using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour {
    public static int currentHealthPoints;
    public static int maxHealthPoints = 100;
    // Use this for initialization
    void Start () {
        currentHealthPoints = maxHealthPoints;      
    }

    // Update is called once per frame
    void Update () {
        if (currentHealthPoints > maxHealthPoints)
        {
            currentHealthPoints = maxHealthPoints;
        }
    }
}
