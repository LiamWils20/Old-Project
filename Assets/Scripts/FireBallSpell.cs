using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBallSpell : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject reloadingText;
    public GameObject enemyHead;
   // public AudioSource audioFire;

    public float launchVelocity = 900f;
    public float weaponDamage = 1;
    private object hit;
    public int DamageToEnemy;

    public int mana = 15;
    public Text manaD;

    public int maxMana = 300;
    public Text maxManaD;

    // Start is called before the first frame update
    void Start()
    {
        reloadingText.SetActive(false);
        //audioFire = GetComponent<AudioSource>();
        //audioFire.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Destroy());
        if (Input.GetButtonDown("Fire1"))
        {
            if (mana > 0)
            {
                mana = mana - 1;
                Fire();
                //audioFire.Play(0);
                //StartCoroutine(Destroy());
                //StopCoroutine(Destroy());

            }

            if (maxMana >= 0 && mana <= 0)
            {
                //AutoReload();
                reloadingText.SetActive(true);
                StartCoroutine(AutoReload());
                StartCoroutine(Reloaded());
            }

        }
        if (Input.GetButtonDown("Reload"))
        {
            // Displays Cooling Down on Screen
            // Reloads / Cool Downs
            StartCoroutine(ManualReload());

            // Removes Cooling Down Txt from screen.
            StartCoroutine(Reloaded());
        }
        
        manaD.text = mana.ToString();
        maxManaD.text = maxMana.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        //Code Below for Head Shots, to make the game more realistic with zombies only
        //needing headshots for destruction. 

        //enemyHead.GetComponent<BossZombie>().HeadDamage(DamageToEnemy);
        //Destroy(gameObject);

        if (other.tag == "Enemy")
        {
            other.GetComponent<BossZombie>().Damage(DamageToEnemy);
            Destroy(gameObject);
        }
    }

    public void Fire()
    {
        GameObject ball = Instantiate(fireBall, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }

    public void Reload()
    {
        //StartCoroutine(RReload());
    }

    //Adding mana to max mana
    public void manaAdd()
    {
        maxMana = maxMana + 50;
    }

    IEnumerator AutoReload()
    {
        //manaD.text = mana.ToString("Reloading");
        yield return new WaitForSeconds(2);
        if (maxMana >= 15 && mana == 0)
        {
            maxMana = maxMana - 15;
            mana = mana + 15;
        }
    }
    IEnumerator ManualReload()
    {
        reloadingText.SetActive(true);
        yield return new WaitForSeconds(2);
        // Reload if Mana is 1
        if (maxMana >= 14 && mana == 1)
        {
            maxMana = maxMana - 14;
            mana = mana + 14;
        }
        // Reload if Mana is 2
        if (maxMana >= 13 && mana == 2)
        {
            maxMana = maxMana - 13;
            mana = mana + 13;
        }
        // Reload if Mana is 3
        if (maxMana >= 14 && mana == 3)
        {
            maxMana = maxMana - 12;
            mana = mana + 12;
        }
        // Reload if Mana is 4
        if (maxMana >= 11 && mana == 4)
        {
            maxMana = maxMana - 11;
            mana = mana + 11;
        }
        // Reload if Mana is 5
        if (maxMana >= 10 && mana == 5)
        {
            maxMana = maxMana - 10;
            mana = mana + 10;
        }
        // Reload if Mana is 6
        if (maxMana >= 9 && mana == 6)
        {
            maxMana = maxMana - 9;
            mana = mana + 9;
        }
        // Reload if Mana is 7
        if (maxMana >= 8 && mana == 7)
        {
            maxMana = maxMana - 8;
            mana = mana + 8;
        }
        // Reload if Mana is 8
        if (maxMana >= 7 && mana == 8)
        {
            maxMana = maxMana - 7;
            mana = mana + 7;
        }
        // Reload if Mana is 9
        if (maxMana >= 6 && mana == 9)
        {
            maxMana = maxMana - 6;
            mana = mana + 6;
        }
        // Reload if Mana is 10
        if (maxMana >= 5 && mana == 10)
        {
            maxMana = maxMana - 5;
            mana = mana + 5;
        }
        // Reload if Mana is 11
        if (maxMana >= 4 && mana == 11)
        {
            maxMana = maxMana - 4;
            mana = mana + 4;
        }
        // Reload if Mana is 12
        if (maxMana >= 3 && mana == 12)
        {
            maxMana = maxMana - 3;
            mana = mana + 3;
        }
        // Reload if Mana is 13
        if (maxMana >= 2 && mana == 13)
        {
            maxMana = maxMana - 2;
            mana = mana + 2;
        }
        // Reload if Mana is 14
        if (maxMana >= 1 && mana == 14)
        {
            maxMana = maxMana - 1;
            mana = mana + 1;
        }
        // Removes Reloaded Txt from screen.
    }
    IEnumerator Reloaded()
    {
        yield return new WaitForSeconds(2);
        {
            reloadingText.SetActive(false);
        }
    }
}

