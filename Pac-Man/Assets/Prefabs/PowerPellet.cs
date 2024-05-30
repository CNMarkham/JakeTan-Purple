using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    protected override void Eat()
    {
        base.Eat();
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost"); // this line finds all ghost objects in the game
        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Ghost>().Frighten();
        }
    }

}
