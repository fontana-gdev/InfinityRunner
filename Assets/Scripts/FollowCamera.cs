using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] float camSpeed;
    
    [Range(1, 16)]
    [SerializeField] int lookAheadPosX;
    
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCamPos = new Vector3(player.position.x + lookAheadPosX, 0, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPos, camSpeed * Time.deltaTime);
    }
}
