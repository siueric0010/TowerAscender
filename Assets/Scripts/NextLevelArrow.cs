using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelArrow : MonoBehaviour
{

    public GameObject NextLevelObject;

    private void Start() {
        NextLevelObject = GameObject.Find("NextLevel-Cylinder");
    }
    void Update() {
        PositionArrow();
    }

    void PositionArrow() {
        Vector3 worldSpacePosition = NextLevelObject.transform.position;
        worldSpacePosition.y = gameObject.transform.position.y; // make their y's equal
        Vector3 difference = worldSpacePosition - gameObject.transform.position;

        float angle = Mathf.Atan2(difference.z, difference.x);

        // transform.LookAt(Camera.main.transform.position);
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angle);

    }
}
