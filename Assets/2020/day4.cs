using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class day4 : MonoBehaviour
{
    private void Awake()
    {
        Resolve();
    }
    
    private void Resolve()
    {
        List<string> checkUpList = new List<string>{"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
        
        int index = 0;
        int count = 0;
        string[] lines = File.ReadAllLines("Assets/2020/day4.txt");

        while (index < lines.Length)
        {
            //mise en forme des keys & values
            int nbValidated = 0;
            List<string> keys = new List<string>();
            List<string> values = new List<string>();
            while (index < lines.Length && lines[index].Length != 0)
            {
                string[] subString = lines[index].Split(' ');
                foreach (string keyValuePair in subString)
                {
                    string[] keyValue = keyValuePair.Split(':');
                    keys.Add(keyValue[0]);
                    values.Add(keyValue[1]);
                }
                index++;
            }
            
            //traitement des keys & values
            for (int i = 0; i < keys.Count; i++)
            {
                switch (keys[i])
                {
                    case "byr" :
                        if (int.Parse(values[i]) >= 1920 && int.Parse(values[i]) <= 2002) nbValidated++;
                        break;
                    case "iyr" :
                        if (int.Parse(values[i]) >= 2010 && int.Parse(values[i]) <= 2020) nbValidated++;
                        break;
                    case "eyr" :
                        if (int.Parse(values[i]) >= 2020 && int.Parse(values[i]) <= 2030) nbValidated++;
                        break;
                    case "hgt" :
                        string heightString = values[i];

                        if (heightString.Contains("cm"))
                        {
                            heightString = heightString.Remove(heightString.IndexOf('c'));
                            if (int.Parse(heightString) >= 150 && int.Parse(heightString) <= 193) nbValidated++;
                        }
                        else if (heightString.Contains("in"))
                        {
                            heightString = heightString.Remove(heightString.IndexOf('i'));
                            if (int.Parse(heightString) >= 59 && int.Parse(heightString) <= 76) nbValidated++;
                        }
                        break;
                    case "hcl" :
                        string hairColorString = values[i];
                        if (hairColorString.Contains('#'))
                        {
                            hairColorString = hairColorString.Substring(1);
                            if (hairColorString.Length == 6)
                            {
                                bool valid = true;
                                foreach (char c in hairColorString)
                                {
                                    if ((c>= 'a' && c <= 'f') || (char.GetNumericValue(c) >= 0 && char.GetNumericValue(c) <= 9))
                                    {
                                    }
                                    else
                                    {
                                        valid = false;
                                    }
                                }

                                if (valid) nbValidated++;
                            }
                        }
                        break;
                    case "ecl" :
                        if (values[i] == "amb" || values[i] == "blu" || values[i] == "brn" || values[i] == "gry" || values[i] == "grn" || values[i] == "hzl" || values[i] == "oth")
                        {
                            nbValidated++;
                        }
                        break;
                    case "pid" :
                        if (values[i].Length == 9) nbValidated++;
                            break;
                }
            }
            
            if (nbValidated == 7) count++;
            index++;
        }

        print(count);
    }
}