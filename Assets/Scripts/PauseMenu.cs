using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(PauseGame){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause(){
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LosdMenu(){
        SceneManager.LoadScene("Scene2");
        Time.timeScale = 1f;
    }
}
