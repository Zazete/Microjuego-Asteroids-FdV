using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        PauseController pauseScript = pauseMenu.GetComponent<PauseController>();
        pauseScript.PauseToggle();
    }
}
