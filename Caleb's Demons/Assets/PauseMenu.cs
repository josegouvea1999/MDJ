using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseUI;


    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale=1f;
        paused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale=0f;
        paused = true;
    }
  


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void clickExit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void retMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
