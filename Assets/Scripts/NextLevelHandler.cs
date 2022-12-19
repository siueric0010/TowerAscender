using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Upon collision with the player ,load the next scene
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision detected.");
        if (other.name.Equals("Player")) {
            Debug.Log("Player entered. Next level...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
