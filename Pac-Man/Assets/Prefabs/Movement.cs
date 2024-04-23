using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float speed; // speed = 5
    public Vector2 initialDirection; // x = 1, y = 0 [1,0]
    public LayerMask obstacleLayer; // Pacman

    protected Rigidbody2D rb; // GetComponent
    protected Vector2 direction; // x, y
    protected Vector2 nextDirection; // x, y
    // Start is called before the first frame update
    void Start()
    {
       direction = initialDirection;
        rb = GetComponent<Rigidbody2D>();
        nextDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;// getting a reference to the rigidbody
        Vector2 translation = direction * speed * Time.fixedDeltaTime; // the actual movement for the gameobject

        rb.MovePosition(position + translation); // this code does the actual movement in the game
    }
    private bool Occupied(Vector2 newDirection)// Checking if we want to go is occupied( blocked)English translation.
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, newDirection, 1.5f, obstacleLayer);//raycast shoots an invisible line sensing if anything is there if true, player can continue moving
        return hit.collider != null; 
    } 
}
  


    
