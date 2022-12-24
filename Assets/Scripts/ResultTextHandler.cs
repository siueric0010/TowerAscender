using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultTextHandler : MonoBehaviour {
    private TMPro.TextMeshProUGUI VictoryText;
    private TMPro.TextMeshProUGUI FailureText;
    // Start is called before the first frame update
    void Start()
    {
        TMPro.TextMeshProUGUI[] components = GetComponentsInChildren<TMPro.TextMeshProUGUI>(true);
        for (int i = 0; i < components.Length; i++) {
            if(components[i].name.Equals("VictoryText")) {
                VictoryText = components[i];
            } else if (components[i].name.Equals("FailureText")) {
                FailureText = components[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.health <= 0.0f) {
            VictoryText.enabled = false;
            FailureText.enabled = true;
        } else {
            VictoryText.enabled = true;
            FailureText.enabled = false;
        }
    }
    public void ReturnToMainMenu() {
        PlayerController.health = 100.0f;
        PlayerController.floorsCleared = 0;
        GameObject backGroundObject = GameObject.Find("BackgroundMusic");
        if(backGroundObject != null) {
            Destroy(backGroundObject);
        }
        SceneManager.LoadScene(0);
    }
}
