using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundOffset = 50;
    private float lowerBoundOffset = -40;
    private float topBound;
    private float lowerBound;
    // Start is called before the first frame update
    void Start()
    {
        topBound = transform.position.x + topBoundOffset;
        lowerBound = transform.position.x + lowerBoundOffset;
    }

    // Update is called once per frame
    void Update()
    {
      if (transform.position.x > topBound){
            Destroy(gameObject);
        } else if (transform.position.x < lowerBound) {
            Destroy(gameObject);
        }  
    }
}
