using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPlayerCollision : MonoBehaviour
{
    public HealthBar healthBar;
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Collision detected between {gameObject.tag} and {other.gameObject.tag}");
        
        if (other.CompareTag("Asteroid_1") || other.CompareTag("Asteroid_2") || other.CompareTag("Asteroid_3")){
            Debug.Log($"Collision detected between {gameObject.tag} and {other.gameObject.tag}");

            explosionParticle.Play();
            playerAudio.PlayOneShot(explosionSound, 1.0f);
            healthBar.TakeDamage(10);
            Destroy(other.gameObject);

            StartCoroutine(StopAnimationAfterDelay(1f));

        }

        IEnumerator StopAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        explosionParticle.Stop();
    }

    }
}
