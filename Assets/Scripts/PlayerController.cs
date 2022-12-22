using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject playerProjectile;
    public float speed = 5.0f;
    public static float health = 100.0f;

    private Animator animator;
    private SpriteRenderer spriteRend;
    private float cooldownReset;
    private float fireRate = 0.23f;

    // Start is called before the first frame update
    void Start()
    {
        cooldownReset = Time.time;
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
    }
    void FixedUpdate() {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * horizontalAxis);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * verticalAxis);

        if(Input.GetButton("Fire1") && Time.time > cooldownReset) {
            cooldownReset = Time.time + fireRate;
            Instantiate(playerProjectile, transform.position, transform.rotation);
        }

        // Flip X if the horizontal movement is to the left.
        spriteRend.flipX = horizontalAxis < 0.0f;

        if(Mathf.Abs(horizontalAxis) + Mathf.Abs(verticalAxis) > 0.01f) {
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;

        // Only way to lose the game is to lose all HP.
        if (health <= 0.0f) {
            // end game
            health = 0.0f;
            Debug.Log("Game Over");
        }
    }
}
