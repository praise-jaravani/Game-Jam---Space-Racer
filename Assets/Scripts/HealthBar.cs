using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isGameOver = false;
    public TextMeshProUGUI healthPercentageText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthPercentage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver == false && gameManager.hasGameStarted == true)
        {
            currentHealth -= damage;
            healthSlider.value = currentHealth;
            UpdateHealthPercentage();

            if (currentHealth <= 0)
            {
                // Implement game over logic here
                Debug.Log("Game Over");
                isGameOver = true;
                
            }
        }
    }

    void UpdateHealthPercentage()
    {
        healthPercentageText.text = currentHealth.ToString() + "%";
    }
}
