using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() {
        Cursor.visible = true;
    }
    public void StartGame() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1
        SceneManager.LoadScene(1);
        PlayerController.health = 100.0f;
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
