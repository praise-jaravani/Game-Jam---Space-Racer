using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverButton;
    public bool hasGameStarted = false;
    public GameObject menuScreen;
    public GameObject infoScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.isGameOver == true){
            gameOverText.gameObject.SetActive(true);
            gameOverButton.SetActive(true);
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(){
        hasGameStarted = true;
        menuScreen.gameObject.SetActive(false);
        infoScreen.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        gameOverButton.SetActive(false);

    }
}
