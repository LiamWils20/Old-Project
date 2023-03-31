using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //public int coins;
    public GameObject coinVisual;
    public Text coinScore;
    public Text coinEndText;
    //Keeps track of total coin count in scene 
    public static int CoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinScore.text = CoinCount.ToString();
        coinEndText.text = CoinCount.ToString();

        transform.Rotate(0, 100*Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Coin.CoinCount++;
            Destroy(gameObject, 0.5f);
        }

    }
    public void BossDefeated(int dmg)
    {
        CoinCount += 100;
    }

}
