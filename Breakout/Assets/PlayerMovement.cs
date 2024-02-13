using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed; 


    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }*/
        float y = transform.position.y;
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        Vector2 tempPosition = new Vector2(x, y);
        transform.position = tempPosition;
    }
}
