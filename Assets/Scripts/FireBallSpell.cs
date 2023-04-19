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

    public int manaMag = 15;
    public int manaShot = 0;
    public int mana = 15;
    public Text manaD;

    public int maxMana = 10;
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
                manaShot++;
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

    //Adding mana to max mana
    public void manaAdd()
    {
        maxMana = maxMana + 50;
    }

    IEnumerator AutoReload()
    {
        //manaD.text = mana.ToString("Reloading");
        yield return new WaitForSeconds(2);
        if (maxMana >= manaMag && mana <= 0)
        {
            maxMana = maxMana - manaMag;
            mana = mana + manaMag;
        }
        else if (maxMana <= manaMag && mana <= 0)
        {
            mana = maxMana;
            maxMana = 0;
        }
    }
    IEnumerator ManualReload()
    {
        reloadingText.SetActive(true);
        yield return new WaitForSeconds(2);
        // Reload if Mana is 1
        if (maxMana >= 14 && mana <= manaMag)
        {
            maxMana = maxMana - manaShot;
            mana = manaMag;
            manaShot = 0;
        }
    }
    IEnumerator Reloaded()
    {
        yield return new WaitForSeconds(2);
        {
            reloadingText.SetActive(false);
        }
    }
}

