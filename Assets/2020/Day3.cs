using System;
using System.IO;
using Unity.Mathematics;
using UnityEngine;

public class Day3 : MonoBehaviour
{
    private void Awake()
    {
        print(Resolve(1, 1) * Resolve(3, 1) * Resolve(5, 1) * Resolve(7, 1) * Resolve(1, 2));
    }

    private Int64 Resolve(int right, int down)
    {
        int x = 0, y = 0;
        Int64 count = 0;
        

        string[] lines = File.ReadAllLines("Assets/2020/day3.txt");
        while (y <= lines.Length - 1)
        {
            if (lines[y][x % lines[y].Length] == '#')
                count++;

            x += right;
            y += down;
        }

        return count;
    }
}