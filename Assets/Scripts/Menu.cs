using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    public GameObject panel; 
    public string game; 
    public void LoadScene ()
    {
        SceneManager.LoadScene(game);
    }

    public void Quit ()
    {
        Application.Quit();
    }

    public void OpenOptions() {
        panel.SetActive(true);
    }

    public void CloseOptions() {
        panel.SetActive(false);
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void UnpauseGame() {
        Time.timeScale = 1;
    }
}
