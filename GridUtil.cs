using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridUtil
{
    
    public static List<Vector2> GetGridNeighbors(Vector2 origin, int gridWidth, int gridHeight)
    
    
    List<Vector2> neighbors = new List<Vector2>();
        for (int xx = -1; xx <= 1; xx++) 
        {
            for (int yy = -1; yy <= 1; yy++) 
            {
                if (xx == 0 && yy == 0)
                {
                    continue; // You are not neighbor to yourself
                }
                // uncomment if you dont want to include corners
                
                // if (Mathf.Abs(xx) + Mathf.Abs(yy) > 1) 
                // {
                //     continue;
                // }
                if (isOnMap(x + xx, y + yy)) {
                    neighbors.Add(new Vector2(x + xx, y + yy));
                }
            }
            return neighbors;
        }
    

    bool isOnMap(int x, int y) 
    {
        return x >= 0 && y >= 0 && x < gridParent.width && y < gridParent.height;
    }
}