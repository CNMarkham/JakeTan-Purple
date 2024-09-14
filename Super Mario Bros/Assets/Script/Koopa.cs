using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    private bool shelled;
    private bool shellMoving;
    public float shellSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        shelled = false;
        shellMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.transform.position.y > transform.position.y + 0.4f)//Checks if Mario is above Koopa sprites
        {
            if (shelled)//checking if above and not moving.
            {
                Launch();
            }
            else
            {
                GetComponent<Animator>().SetTrigger("shell");
                GetComponent<EnemyMovement>().speed = 0;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                shelled = true;//Just setting Koopas shell variable to true.
            }
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.velocity = new Vector2(playerRB.velocity.x, 10);
        }
        else if (shelled && !shellMoving)//When Koopa is not moving and is in his shell(walking)
        {
            Launch();//Launch function under this if statement.(Calling the Launch function).
        }
        else // Koopa is moving(this calls the hit function from PlayerBehaviior).
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().Hit();
        }
    }

    private void Launch()
    {

    }

}
    