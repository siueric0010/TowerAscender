using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate() {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
    }
}
