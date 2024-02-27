using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
        Destroy(collision.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
