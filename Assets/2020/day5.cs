using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class day5 : MonoBehaviour
{
    private void Awake()
    {
        Resolve();
        
    }

    public void Resolve()
    {
        string[] lines = File.ReadAllLines("Assets/2020/day5.txt");

        int currentHighestID = 0;

        foreach (string line in lines)
        {
            int upperRow = 127;
            int lowerRow = 0;
            int finalRow = 0;

            int upperColumn = 7;
            int lowerColumn = 0;
            int finalColumn = 0;

            int seatID = 0;
            
            string seatRow = line.Substring(0, 7);
            string seatColumn = line.Substring(7, 3);

            for (int i = 0; i < seatRow.Length; i++)
            {
                if (i == seatRow.Length - 1)
                {
                    if (seatRow[i] == 'F')
                        finalRow = lowerRow;
                    else
                        finalRow = upperRow;
                }
                else
                {
                    if (seatRow[i] == 'F')
                        upperRow = lowerRow + (upperRow - lowerRow) / 2;
                    else
                        lowerRow += (upperRow - lowerRow) / 2 + 1;
                }
            }
            
            
            for (int i = 0; i < seatColumn.Length; i++)
            {
                if (i == seatColumn.Length - 1)
                {
                    if (seatColumn[i] == 'L')
                        finalColumn = lowerColumn;
                    else
                        finalColumn = upperColumn;
                }
                else
                {
                    if (seatColumn[i] == 'L')
                        upperColumn = lowerColumn + (upperColumn - lowerColumn) / 2;
                    else
                        lowerColumn += (upperColumn - lowerColumn) / 2 + 1;
                }
            }

            seatID = finalRow * 8 + finalColumn;
            //print(finalRow);
            //print(finalColumn);
            //print(seatID);

            if (seatID > currentHighestID)
            {
                currentHighestID = seatID;
            }
        }
        
        print(currentHighestID);
    }
}