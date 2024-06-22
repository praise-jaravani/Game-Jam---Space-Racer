using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAsteroidCollision : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Collision detected between {gameObject.tag} and {other.gameObject.tag}");
        
        if (other.CompareTag("Asteroid_1") || other.CompareTag("Asteroid_2") || other.CompareTag("Asteroid_3"))
        {
            explosionParticle.Play();
            Destroy(other.gameObject);
            StartCoroutine(DestroyAfterDelay(gameObject, 0.2f)); // Start the coroutine with a 1-second delay
        }
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        Destroy(obj); // Destroy the asteroid object
    }
}
