using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Text HealthText;
    Player healthTracker;


    // healthValue = FindObjectOfType<DamageDealer>().GetDamage();

    void Start()
    {
        HealthText = GetComponent<Text>();
        healthTracker = FindObjectOfType<Player>();
    }

    void Update()
    {
        HealthText.text = healthTracker.GetHealth().ToString();
    }

}
