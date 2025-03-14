using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parallaxFactor;
    
    private float length;
    private float startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float reposition = cameraTransform.position.x * (1 - parallaxFactor);
        if (reposition > startPosition + length)
        {
            startPosition += length;
        }
        
        float distance = cameraTransform.position.x * parallaxFactor;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
    }
}
