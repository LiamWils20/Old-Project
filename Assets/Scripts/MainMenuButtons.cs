using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject button;

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
    public void StartGame()
    {
        ExecuteTrigger("TrOpen");
        LoadGame();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Options()
    {
        ExecuteTrigger("TrOpen");
        LoadOptions();
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void AboutUs()
    {
        ExecuteTrigger("TrOpen");
        LoadOptions();
    }
    public void LoadAbout()
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
