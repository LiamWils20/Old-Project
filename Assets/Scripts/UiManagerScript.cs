using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerScript : MonoBehaviour
{

    public Text coins, level;
    public Player myPlayer;
    public GameManager myGM;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Grab Coin from the Player, and put it in UI
        coins.text = "Coins: " + myPlayer.coinsCollected.ToString();

        // Grab level from Game Manager and put it in the UI
        level.text = "Level " + myGM.gameLevel.ToString();
    }
}
