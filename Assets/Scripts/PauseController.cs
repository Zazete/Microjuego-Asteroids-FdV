using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseText;
    public GameObject resumeButton;
    public GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseToggle();
        }
    }

    public void PauseToggle() {
        if(isPaused) {
            ResumeGame();
        } else {
            PauseGame();
        }
    } 

    private void PauseGame() {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
        pauseText.SetActive(true);
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }

    private void ResumeGame()  {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
        pauseText.SetActive(false);
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }
}
