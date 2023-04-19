using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyShooter : MonoBehaviour
{
    public GameObject fireBall;
    
    public float launchVelocity = 900f;
    public float weaponDamage = 1;
    private object hit;
    public int DamageToPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Damage();
        }
    }

    public void Fire()
    {
        GameObject ball = Instantiate(fireBall, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }

    IEnumerator RingOfFire()
    {
        yield return new WaitForSeconds(5);
        {
            Fire();
        }
    }
}

