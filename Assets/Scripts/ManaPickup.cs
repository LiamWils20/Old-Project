using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    public GameObject pickup;
    public GameObject player;
    public GameObject launchObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 75 * Time.deltaTime, 0);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            launchObject.GetComponent<FireBallSpell>().manaAdd();
            Destroy(pickup);
        }
    }
}
