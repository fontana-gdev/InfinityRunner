using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{

    [SerializeField] private float horizontalForce;
    [SerializeField] private float verticalForce;
    [SerializeField] private int damage;

    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(-horizontalForce, verticalForce), ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    public int Damage => damage;
    
}
