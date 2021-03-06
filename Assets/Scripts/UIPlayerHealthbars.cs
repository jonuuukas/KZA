﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlayerHealthbars : MonoBehaviour {
    private Image tankHealthBar;
    private Image dpsHealthBar;
    private Image healerHealthBar;
    private Image healerManaBar;

    // Use this for initialization
    void Start () {
        tankHealthBar = transform.FindChild("TankBars").FindChild("TankHealthBG").FindChild("TankHealth").GetComponent<Image>();
        dpsHealthBar = transform.FindChild("DPSBars").FindChild("DPSHealthBG").FindChild("DPSHealth").GetComponent<Image>();
        healerHealthBar = transform.FindChild("HealerBars").FindChild("HealerHealthBG").FindChild("HealerHealth").GetComponent<Image>();
        healerManaBar = transform.FindChild("HealerBars").FindChild("HealerManaBG").FindChild("HealerMana").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        tankHealthBar.fillAmount = (float)TankHealth.currentHealthPoints / (float)TankHealth.maxHealthPoints;
        dpsHealthBar.fillAmount = (float)DPSHealth.currentHealthPoints / (float)DPSHealth.maxHealthPoints;
        healerHealthBar.fillAmount = (float)HealerHealth.currentHealthPoints / (float)HealerHealth.maxHealthPoints;
        healerManaBar.fillAmount = (float)HealerHealth.currentManaPoints / (float)HealerHealth.maxManaPoints;
    }
}
