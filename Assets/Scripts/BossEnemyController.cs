using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : EnemyController
{
    [SerializeField]
    public EnemyProjectile[] projectiles;

    private ParticleSystem partSystem;
    private SpriteRenderer spriteRend;
    private Canvas canvas;
    private float damage = 10.0f;
    private float cooldownReset;
    private float fireRate = 1.0f;


    new void Start() {
        base.Start();
        speed = 2.5f;
        MinDist = 1.0f;
        MaxDist = 20.0f;
        AttackDist = 10.5f;
        health = 500.0f;
        maxHealth = health;
        cooldownReset = Time.time;
        partSystem = GetComponentInChildren<ParticleSystem>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        canvas = GetComponentInChildren<Canvas>();
    }
    public override void Attack() {
        // Do some sick boss attack with multiple projectiles?
        if (Time.time > cooldownReset && projectiles.Length > 0) {
                cooldownReset = Time.time + fireRate;
                int randomIndex = (int)Mathf.Floor(Random.Range(0, projectiles.Length));
                Instantiate(projectiles[randomIndex], transform.position, transform.rotation);
        }
    }

    public override void TakeDamage() {
        base.TakeDamage();
        health -= 10.0f;
        if (health <= 0.01f) {
            partSystem.Play();
            StartCoroutine(stopParticlesAndDestroy());
            damage = 0.0f;
        }
    }

    IEnumerator stopParticlesAndDestroy() {
        speed = 0.0f;
        spriteRend.enabled = false;
        canvas.enabled = false;
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
