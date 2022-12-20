using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    void Start() {
        Cursor.visible = false;
    }
    void Update() {
        transform.position = Input.mousePosition;
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
        }
    }
}
