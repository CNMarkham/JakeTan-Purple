using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;
    private bool frightened;

    private void Awake()
    {
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
        frightened = false;
        Invoke("LeaveHome", homeDuration);
    }

    protected override void ChildUpdate()
    {

    } 
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if(atHome && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SetDirection(-direction);
        }
        if (collision.gameObject.CompareTag("Pacman"))
        {
            if (frightened)
            {

            }
            else
            {

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Node node = collider.GetComponent<Node>();
        if (node != null)
        {
            int index = Random.Range(0, node.availableDirections.Count);
            if (node.availableDirections[index] == -direction) // this is to check if the direction we picked is the one we came from
            {
                index += 1;
                if (index == node.availableDirections.Count) // this is to make sure we dont go out of range in the list
                {
                    index = 0;
                }
            }
            SetDirection(node.availableDirections[index]);
        }
    }
    private void LeaveHome()
    {
        transform.position = new Vector3(0, 3f, -1f);
        direction = new Vector2(-1, 0);
        atHome = false;
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);


    }
    public void Frighten()
    {
        if (!atHome)
        {
            frightened = true;
            body.SetActive(false);
            eyes.SetActive(false);
            blue.SetActive(true);
            white.SetActive(false);
            Invoke("Flash", 4f);
        }
    }
    private void Flash()
    {
        body.SetActive(false);
        eyes.SetActive(false);
        blue.SetActive(false);
        white.SetActive(true);
        Invoke("Reset", 4f);
    }
    private void Reset()
    {
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
    }
}