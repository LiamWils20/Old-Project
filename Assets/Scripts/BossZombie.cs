using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossZombie : MonoBehaviour
{
    //The box's current health point total
    public Transform player;
    public TMP_Text health;
    public float healthD = 100;
    private float dist;
    public int DamageToPlayer;

    

    public float delay = 1000f;


    void Start()
    {
        dist = Vector3.Distance(player.position, transform.position);  
    }

    void Update()
    {
        health.text = healthD.ToString();
    }

    // Function for deducting health and Destroying GameObject
    public void Damage(int dmg)
    {
        int magicDamage = Random.Range(0, 10);
        healthD = healthD - magicDamage;
        if (healthD <= 0)
        {
            Destroy(this.gameObject);
            player.GetComponent<Coin>().BossDefeated(DamageToPlayer);
        }
    }
    public void ElectricalDamage(int dmg)
    {
        int elecDamage = Random.Range(10, 20);
        healthD = healthD - elecDamage;
        if (healthD <= 0)
        {
            Destroy(this.gameObject);
            player.GetComponent<Coin>().BossDefeated(DamageToPlayer);
        }
    }


    // Function for Regeneration
    public void Regenerate()
    {
        for (int i = 10000; i < 100; i++)
        {
            healthD = healthD + 5;
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(DealDamage());
        }
    }

    IEnumerator DealDamage()
    {
        yield return new WaitForSeconds(2);
        {
            player.GetComponent<Player>().Damage(DamageToPlayer);
        }
        StopCoroutine(DealDamage());
    }
}

