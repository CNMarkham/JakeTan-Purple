using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    private RaycastHit2D hit;
    public float jumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * horizontal * moveSpeed * Time.deltaTime);


        Jump();
    }


    private void Jump()
    {
        hit - Physics2D.CircleCast(rb.position, 0.25t, Vector2.down, 0.375t, LayerMask.GetMask("Default"));
    }
}
