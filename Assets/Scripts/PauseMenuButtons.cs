using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject button;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExecuteTrigger(string trigger)
    {
        if (button != null)
        {
            var animator = button.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);

            }

        }
    }

    //StartGame Link function. Linking StartGame to Category
    public void ResumeGame()
    {
        ExecuteTrigger("TrOpen");
        Time.timeScale = 1.0f;
        RGame();
    }
    public void RGame()
    {
        player.GetComponent<Player>().Resume();
    }

    public void MainMenu()
    {
        ExecuteTrigger("TrOpen");
        LoadMainMenu();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Options()
    {
        ExecuteTrigger("TrOpen");
        LoadOptions();
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("AboutUs");
    }

    public void ExitGame()
    {
        ExecuteTrigger("TrOpen");
        LoadExitGame();
    }
    public void LoadExitGame()
    {
        Application.Quit();
    }
}
