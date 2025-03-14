using UnityEngine;

public class FlyingEnemy : Enemy
{

    [SerializeField] private float speed;
    
    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }
}
