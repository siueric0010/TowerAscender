using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNumberHandler : MonoBehaviour {
    private TMPro.TextMeshProUGUI TMProText;
    private const float MAX_HEALTH = 100.0f;

    // Start is called before the first frame update
    void Start() {
        TMProText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        TMProText.text = Mathf.CeilToInt(PlayerController.health) + "/" + MAX_HEALTH;
    }
}
