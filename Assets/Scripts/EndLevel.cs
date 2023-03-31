using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{

    public GameObject endLevel;
    //public int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        endLevel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy.Length == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            endLevel.SetActive(true);

        }
    }
}
