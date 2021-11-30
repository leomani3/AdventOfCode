using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    private void Awake()
    {
       Resolve();
    }

    private void Resolve()
    {
        int[] numbers = File.ReadAllLines("Assets/2020/day1.txt").Select(s => int.Parse(s)).ToArray();
        
        foreach (int i in numbers)
        {
            foreach (int j in numbers)
            {
                foreach (int k in numbers)
                {       
                    if (i + j + k == 2020)
                    {
                        print(i * j * k);
                    }
                }
            }
        }
    }
}