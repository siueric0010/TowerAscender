using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(origin, out hitInfo)) {
            if(hitInfo.collider != null) {

            }
        }
    }
}
