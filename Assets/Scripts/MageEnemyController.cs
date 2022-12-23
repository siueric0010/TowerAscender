using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemyController : EnemyController
{
    public GameObject enemyMageProjectile;

    private ParticleSystem partSystem;
    private SpriteRenderer spriteRend;
    private float cooldownReset;
    private float fireRate = 0.75f;
    private bool dead;
    new void Start() {
        base.Start();
        speed = 4.5f;
        MinDist = 5.0f;
        MaxDist = 10.0f;
        AttackDist = 8.0f;
        health = 75.0f;
        maxHealth = health;
        cooldownReset = Time.time + Random.Range(0, fireRate); // enemies will fire at random rates compared to each other.
        partSystem = GetComponentInChildren<ParticleSystem>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        dead = false;
    }
    public override void Attack() {
        // Shoots an EnemyProjectile
        if (Time.time > cooldownReset && !dead) {
            cooldownReset = Time.time + fireRate;
            Instantiate(enemyMageProjectile, transform.position, transform.rotation);
        }
    }

    public override void TakeDamage() {
        base.TakeDamage();
        health -= 10.0f;
        // Debug.Log("Enemy Damage Taken -- health: " + health);
        if(health <= 0.01f) {
            if (partSystem != null) {
                partSystem.Play();
            }
            spriteRend.enabled = false;
            StartCoroutine(stopParticlesAndDestroy());
            dead = true; // since the controller is technically still alive
        }
    }
    IEnumerator stopParticlesAndDestroy() {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}

