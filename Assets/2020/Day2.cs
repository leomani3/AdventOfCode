using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Day2 : MonoBehaviour
{
    private void Awake()
    {
        Resolve();
    }

    private void Resolve()
    {
        int min = 0, max = 0, count = 0;
        char rule = ' ';
        string candidate="";
        
        string[] lines = File.ReadAllLines("Assets/2020/day2.txt");
        
        //traitement du fichier d'input
        foreach (string line in lines)
        {
            string[] subStrings = line.Split(':');

            candidate = subStrings[1];
            rule = subStrings[0][subStrings[0].Length - 1];

            subStrings[0].Remove(subStrings[0].Length - 1);
            subStrings[0].Remove(subStrings[0].Length - 1);

            string[] subStrings2 =  subStrings[0].Split(' ')[0].Split('-');

            min = int.Parse(subStrings2[0]);
            max = int.Parse(subStrings2[1]);
            
            //résolution du problème
            if (candidate[min] == rule ^ candidate[max] == rule)
            {
                count++;
            }
        }
        print(count);
    }
}