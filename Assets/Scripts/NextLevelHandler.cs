using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelHandler : MonoBehaviour
{
    private bool noEnemiesLeft = true;
    private Shader transGreen;
    private Shader transRed;
    private Material mat;
    private TMPro.TextMeshProUGUI fadeText;
    private int MIN_FLOORS_FOR_BOSS = 3;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        transGreen = Shader.Find("Shader Graphs/Transparent Green Shader");
        transRed = Shader.Find("Shader Graphs/Transparent Red Shader");
        GameObject temp = GameObject.Find("FadingText");
        if(temp != null) {
            fadeText = temp.GetComponent<TMPro.TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Debug.Log(enemies.Length);
        noEnemiesLeft = enemies.Length == 0;
        if(noEnemiesLeft) {
            mat.shader = transGreen;
        } else {
            mat.shader = transRed;
        }
    }

    //Upon collision with the player ,load the next scene
    private void OnTriggerEnter(Collider other) {
        // Debug.Log("Collision detected.");
        if (other.name.Equals("Player") && noEnemiesLeft) {
            // Debug.Log("Player entered. Next level...");
            PlayerController.floorsCleared++;

            if(PlayerController.floorsCleared >= MIN_FLOORS_FOR_BOSS) {
                // If we want to move to boss scene / victory scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            } else {
                // For starting floor, do +1
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                if (sceneIndex == 1) {
                    SceneManager.LoadScene(sceneIndex + 1);

                // For intermediate floor, just reload scene
                // randomly generated floor with enemies
                } else {
                    SceneManager.LoadScene(sceneIndex);
                }
            }

            
        } else if (other.name.Equals("Player") && !noEnemiesLeft) {
            // tell player to defeat all enemies before moving on
            StartCoroutine(FadeTextOnScreen("Eliminate all enemies to continue"));
        }
    }

    IEnumerator FadeTextOnScreen(string text) {
        if(fadeText != null) {
            fadeText.text = text;
            fadeText.color = new Color(1.0f, 0, 0, 1.0f);
            yield return new WaitForSeconds(0.5f);
            fadeText.color = new Color(1.0f, 0, 0, 0);
        }
    }
}
