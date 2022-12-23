using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    public AudioClip[] audioClips;

    public GameObject playerProjectile;
    public float speed = 5.0f;
    public static float health = 100.0f;
    public static int floorsCleared = 0;

    private AudioSource fireAudioSource;
    private ParticleSystem particleSystem;
    private Animator animator;
    private SpriteRenderer spriteRend;
    private Rigidbody rb;
    private float cooldownReset;
    private float fireRate = 0.23f;

    private Vector3 userInput;


    // Start is called before the first frame update
    void Start()
    {
        cooldownReset = Time.time;
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        fireAudioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        // userInput = new Vector3(horizontalAxis, 0, verticalAxis) * speed * Time.fixedDeltaTime;
        userInput = new Vector3(horizontalAxis, 0, verticalAxis) * speed;
    }
    void FixedUpdate() {
        rb.velocity = (userInput);
        // transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * horizontalAxis);
        // transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * verticalAxis);

        if(Input.GetButton("Fire1") && Time.time > cooldownReset) {
            cooldownReset = Time.time + fireRate;
            Instantiate(playerProjectile, transform.position, transform.rotation);
            particleSystem.Play();
            fireAudioSource.PlayOneShot(audioClips[0]);
            StartCoroutine(stopParticleSystem());
        }

        // Flip X if the horizontal movement is to the left.
        spriteRend.flipX = userInput.x < 0.0f;

        if(Vector3.Dot(userInput, userInput) > 0.01f) {
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        fireAudioSource.PlayOneShot(audioClips[1]);

        // Only way to lose the game is to lose all HP.
        if (health <= 0.0f) {
            // end game
            health = 0.0f;
            SceneManager.LoadScene("Ending");
            // Debug.Log("Game Over");
        }
    }

    IEnumerator stopParticleSystem() {
        yield return new WaitForSeconds(0.2f);
        particleSystem.Stop();
    }
}
