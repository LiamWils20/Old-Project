using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeleeZombie : MonoBehaviour
{
    //The box's current health point total
    public GameObject fireBall;
    public TMP_Text health;
    public static float healthD = 10;
    private float dist;

    public void Damage(int dmg)
    {
        healthD = healthD - 1;
        if (healthD <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
    }
    void Update()
    {
        health.text = healthD.ToString();

    }
}

