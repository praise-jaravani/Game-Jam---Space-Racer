using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 20.0f;
    private float horizontalInput;
    public float zRange = 20;
    public GameObject projectilePrefab;
    private Vector3 bulletOffset = new Vector3(-2,0,0);
    public HealthBar healthBar;
    public AudioClip shootSound;
    private AudioSource playerAudio;

    public GameManager gameManager;

    void Start()
    {
       playerAudio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (healthBar.isGameOver == false && gameManager.hasGameStarted == true)
        {
            // Default forward motion
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        }

        // Keep player in bounds
        if (transform.position.z < -zRange) // If the players position goes less than -10 (e.g, -11)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange); // The player will be brought back to -10, but at whatever y or z position they are already at.
        }
        if (transform.position.z > zRange) // If the players position goes less than -10 (e.g, -11)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange); // The player will be brought back to -10, but at whatever y or z position they are already at.
        }

        // Get the horizontal input (left and right arrow keys or A and D keys)
        horizontalInput = Input.GetAxis("Horizontal");

        if (healthBar.isGameOver == false && gameManager.hasGameStarted == true)
        {
        // Rotate the player based on horizontal input
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.hasGameStarted == true && healthBar.isGameOver == false)
       {
            playerAudio.PlayOneShot(shootSound, 1.0f);
            Instantiate(projectilePrefab, (transform.position + bulletOffset), projectilePrefab.transform.rotation);
       }
    }
}
