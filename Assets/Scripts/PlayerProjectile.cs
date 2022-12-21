using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 projDirection;
    private Vector3 playerPos;
    public float speed = 5.0f;
    void Start()
    {
        Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(origin, out hitInfo)) {
            if (hitInfo.collider != null) {
                playerPos = GameObject.Find("Player").transform.position;
                Vector3 hitPos = hitInfo.point;
                hitPos.y = playerPos.y; // To make sure projectile is on the same plane as the player and doesn't clip through.
                projDirection = hitInfo.point - playerPos;
            } else {
                Destroy(this.gameObject);
            }
        } else {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(projDirection.normalized * speed * Time.fixedDeltaTime);

        if(Vector3.Distance(playerPos, this.gameObject.transform.position) > 50.0f) {
            Destroy(this.gameObject);
        }
    }

    //Upon collision with the Enemy, reduce enemy HP
    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Enemy")) {
            other.gameObject.GetComponent<EnemyController>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
