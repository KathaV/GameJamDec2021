using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private const int mainMenuIndex = 0;
    public static bool isPaused = false;
    public GameObject pauseUI;

    void Start(){
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log("Update is run");
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Escape button is pressed");
            if(isPaused){
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void ResumeGame(){
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame(){
        isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void ExitGame() {
        SceneManager.LoadScene(mainMenuIndex);
        ResumeGame();
    }
}