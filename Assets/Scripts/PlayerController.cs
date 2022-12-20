using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject playerProjectile;
    public float speed = 5.0f;
    public static float health = 100.0f;
    private float cooldownReset;
    private float fireRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        cooldownReset = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate() {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));

        if(Input.GetButton("Fire1") && Time.time > cooldownReset) {
            Debug.Log("Fire");

            cooldownReset = Time.time + fireRate;
            Instantiate(playerProjectile, transform.position, transform.rotation);
        }
    }
}
