using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //gameManager.StartGame();
        Debug.Log("Start Game Button Clicked");
    }
}
