using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensures the camera follows the players movements
public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        // Update the position
        transform.position = Player.transform.position + offset;
    }
}
