using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public HealthBar healthBar;
    public TextMeshProUGUI distanceText;
    public GameManager gameManager;
    private float distance = 0f;
    private float playerSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.isGameOver == false && gameManager.hasGameStarted == true)
        {
            distance += Time.deltaTime * playerSpeed;
            distanceText.text = "Distance: " + Mathf.FloorToInt(distance).ToString() + " km";
        }
    }
}
