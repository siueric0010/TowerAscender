using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarHandler : MonoBehaviour {
    private Image image;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start() {
        image = GetComponent<Image>();
        enemyController = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update() {
        image.fillAmount = enemyController.health / enemyController.maxHealth;
        // Debug.Log("Enemy Controller HP: " + enemyController.health);
        // Debug.Log("Enemy Controller Max HP: " + enemyController.maxHealth);
        // Debug.Log("Image Fill Amt: " + image.fillAmount);
    }
}
