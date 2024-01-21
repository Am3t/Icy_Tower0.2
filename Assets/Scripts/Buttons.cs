using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject menu;
    public GameObject settingsmenu;
    // Start is called before the first frame update
    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void Settings(){
        menu.SetActive(false);
        settingsmenu.SetActive(true);
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("Scene2");
    }
    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
