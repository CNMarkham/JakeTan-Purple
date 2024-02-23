using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    void Update()

    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
