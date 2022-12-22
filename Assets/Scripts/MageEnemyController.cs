using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyController : EnemyController
{
    public GameObject enemyMageProjectile;
    private float cooldownReset;
    private float fireRate = 0.75f;
    new void Start() {
        base.Start();
        speed = 2.5f;
        MinDist = 5.0f;
        MaxDist = 10.0f;
        AttackDist = 8.0f;
        health = 75.0f;
        maxHealth = health;
        cooldownReset = Time.time + Random.Range(0, fireRate); // enemies will fire at random rates compared to each other.
}
    public override void Attack() {
        // Shoots an EnemyProjectile
        if (Time.time > cooldownReset) {
            cooldownReset = Time.time + fireRate;
            Instantiate(enemyMageProjectile, transform.position, transform.rotation);
        }
    }

    public override void TakeDamage() {
        health -= 10.0f;
        Debug.Log("Enemy Damage Taken -- health: " + health);
        if(health <= 0.01f) {
            Destroy(gameObject);
        }
    }
}
