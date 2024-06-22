using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    private float spawnRangeZ = 30;
    private float spawnPosY = 2;
    private float startDelay = 0;
    private float dependentX;
    private float dependentXOffset = -50;
    public HealthBar healthBar;

    public GameManager gameManager;

    // Variable to change as game gets more difficult
    private float spawnInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        dependentX = transform.position.x + dependentXOffset;
        InvokeRepeating("SpawnRandomAsteroid", startDelay, spawnInterval);
        StartCoroutine(IncreaseDifficulty());
    }

    // Update is called once per frame
    void Update()
    {
        dependentX = transform.position.x + dependentXOffset;
    }

    void SpawnRandomAsteroid() 
    {
        // Random position
        Vector3 spawnPos = new Vector3( dependentX, spawnPosY, Random.Range(-spawnRangeZ, spawnRangeZ));

        // Random asteroid selection
        int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
        
        if (healthBar.isGameOver == false && gameManager.hasGameStarted == true){
            Instantiate(asteroidPrefabs[asteroidIndex], spawnPos, asteroidPrefabs[asteroidIndex].transform.rotation);
        }    
    }

    IEnumerator IncreaseDifficulty()
    {
        while (spawnInterval > 0.1f)
        {
            yield return new WaitForSeconds(30f); // Increase difficulty every 30 seconds
            spawnInterval = Mathf.Max(0.1f, spawnInterval - 0.1f); 
            
            foreach (GameObject asteroid in asteroidPrefabs)
            {
                asteroid.GetComponent<AsteroidBackward>().speed += 0.1f; 
            }
            
            CancelInvoke("SpawnRandomAsteroid");
            InvokeRepeating("SpawnRandomAsteroid", startDelay, spawnInterval);
        }
    }

}
