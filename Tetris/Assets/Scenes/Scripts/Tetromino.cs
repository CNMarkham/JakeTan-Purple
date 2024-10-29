using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    public static int width = 10;
    public static int height = 20;
    public Vector3 rotationPoint;
    public static Transform[,] grid = new Transform[width, height]; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0);
            if (!validMove())
            {
                transform.position += new Vector3(1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0);
            if (!validMove()) // validMove() == false
            {
                transform.position += new Vector3(-1, 0);
            }
        }
        float tempTime = fallTime;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempTime = tempTime / 10;
        }


        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;
            if (!validMove())
            {
                transform.position += new Vector3(0, 1);
                this.enabled = false;
                AddToGrid();
                CheckLines();
                FindObjectOfType<Spawner>().SpawnTetromino();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);
            if (!validMove())
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);
            }
        }

    }

    public bool validMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            if (x <= 0 || y <= 0 || x >= width || y >= height)
            {
                return false;
            }
            if (grid[x, y] != null)
            {
                return false;
            }
        }

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + rotationPoint, 0.1f);
    }

    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            grid[x, y] = child;
            
        }
    }
    public void CheckLines()
    {
        for (int i = height - 1; i >= 0; i--)
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
    }

    public bool HasLine(int i)
    {
        for(int j=0; j < width; j++)
        {
            if (grid[j,i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
}
    public void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
}
