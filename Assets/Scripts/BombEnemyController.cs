using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyController : EnemyController
{

    new void Start() {
        base.Start();
        speed = 2.5f;
        MinDist = 1.0f;
        MaxDist = 10.0f;
        AttackDist = 1.5f;
        health = 100.0f;
        maxHealth = health;
    }
    public override void Attack() {
        PlayerController.health -= 33.3f;
        Debug.Log("Health: " + PlayerController.health);
        Destroy(this.gameObject);
    }

    public override void TakeDamage() {
        health -= 10.0f;
        Debug.Log("Enemy Damage Taken -- health: " + health);
        if(health <= 0.01f) {
            Destroy(gameObject);
        }
    }
}
