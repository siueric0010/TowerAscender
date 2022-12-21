using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float MinDist;
    public float MaxDist;
    public float AttackDist;
    public float health;
    public float maxHealth;
    bool seen;

    // Start is called before the first frame update
    protected void Start() {
        seen = false;
    }

    // Update is called once per frame
    void Update() {

    }
    void FixedUpdate() {
        Transform playerTransform = GameObject.Find("Player").transform;
        Vector3 playerPos = playerTransform.position;
        transform.LookAt(Camera.main.transform);
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos);
        if (distanceToPlayer >= MinDist && (distanceToPlayer <= MaxDist || seen)) {
            Vector3 normalizedDirection = (playerPos - transform.position).normalized;
            transform.Translate(normalizedDirection * speed * Time.deltaTime, Space.World);
            // transform.position += transform.forward * speed * Time.deltaTime;
            seen = true;
        }

        if (distanceToPlayer <= AttackDist) {
            Attack();
        }
    }

    public virtual void Attack() {

    }

    public virtual void TakeDamage() {
    }
}
