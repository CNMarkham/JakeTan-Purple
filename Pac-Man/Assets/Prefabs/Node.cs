using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirecctions;

    // Start is called before the first frame update
    void Start()
    {
        availableDirecctions = new List<Vector2>();
    }
}
