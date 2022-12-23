using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyController : EnemyController
{
    private AudioSource audioSrc;
    private ParticleSystem partSystem;
    private SpriteRenderer spriteRend;
    private Canvas canvas; 
    private float damage = 10.0f;
    new void Start() {
        base.Start();
        speed = 4.5f;
        MinDist = 1.0f;
        MaxDist = 10.0f;
        AttackDist = 1.5f;
        health = 100.0f;
        maxHealth = health;
        partSystem = GetComponentInChildren<ParticleSystem>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        canvas = GetComponentInChildren<Canvas>();
        audioSrc = GetComponent<AudioSource>();
    }
    public override void Attack() {
        PlayerController.health -= damage;
        if (partSystem != null) {
            partSystem.Play();
            if(audioSrc != null) {
                audioSrc.Play();
            }
            spriteRend.enabled = false;
            StartCoroutine(stopParticlesAndDestroy());
            damage = 0.0f; // since the controller is technically still alive, just let it do 0 damage.
        }
        // Destroy(this.gameObject);
    }

    public override void TakeDamage() {
        base.TakeDamage();
        health -= 10.0f;
        // Debug.Log("Enemy Damage Taken -- health: " + health);
        if(health <= 0.01f) {
            Destroy(gameObject);
        }
    }

    IEnumerator stopParticlesAndDestroy() {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
