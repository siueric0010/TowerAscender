using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    // Start is called before the first frame update
    private Vector3 projDirection;
    private Vector3 playerPos;
    private float playerDamageTaken = 3.5f;
    public float speed = 4.0f;
    void Start() {
        playerPos = GameObject.Find("Player").transform.position;
        Vector3 currentXZ = transform.position;
        currentXZ.y = playerPos.y; // to make sure they're on the same y plane.
        projDirection = playerPos - currentXZ;
        Debug.Log("Projection Dir:" + projDirection);
        Debug.Log("playerPos Dir:" + playerPos);
        Debug.Log("currentXZ Dir:" + currentXZ);
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Translation Dir:" + projDirection);
        Debug.Log("Translation Dir Normalized:" + projDirection.normalized);
        transform.Translate(projDirection.normalized * speed * Time.fixedDeltaTime, Space.World);

        if (Vector3.Distance(playerPos, this.gameObject.transform.position) > 50.0f) {
            Destroy(this.gameObject);
        }
    }

    //Upon collision with the Enemy, reduce enemy HP
    private void OnTriggerEnter(Collider other) {
        if (other.name.Equals("Player")) {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(playerDamageTaken);
            Destroy(this.gameObject);
        }
    }
}
