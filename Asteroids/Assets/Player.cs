using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float lookSpeed;
    public float moveSpeed;
    public float naxSpeed;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
