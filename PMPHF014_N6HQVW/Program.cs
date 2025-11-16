using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PMPHF014_N6HQVW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double output = 0; //Létrehozom és 0-ás értéket adok az output változónak
            int depth = 0;

            double temp = 0;
            int sameDepthCounter = 1;
            

            List<string> rows = new List<string>();
            List<int> depths = new List<int>();

            using StreamReader sr = new StreamReader(path: @"../../../src/input.txt", encoding: System.Text.Encoding.UTF8);
            int numberOfRows = int.Parse(sr.ReadLine());
            while (!sr.EndOfStream)
            {
                rows.Add(sr.ReadLine());
            }

            if (numberOfRows > 2) //Ellenrőzöm, hogy több mint két sor van. Ha nem, akkor az output értékét egyből 1-re állítom
            {
                for (int i = 0; i < numberOfRows; i++) //Végig iterálok a rows listán, és megadom, hogy melyik sor, mennyire lenne behúzva a kódban
                {
                    if (rows[i] != "begin" && rows[i] != "end")
                    {
                        if ((rows[i] == "if" && rows[i-1] == "if") || (rows[i] == "if" && rows[i - 1] == "else"))
                        {
                            depth++;
                        }
                        else if ((rows[i] == "else" && rows[i - 1] == "endif") || (rows[i] == "endif" && rows[i - 1] == "endif"))
                        {
                            depth--;
                        }
                        depths.Add(depth);
                        Console.WriteLine(depth + " - " + rows[i]);
                    }
                }
                Console.WriteLine();


                for (int i = 0; i < depths.Count(); i++) //Végig itrálok a depths listán
                {
                    if (sameDepthCounter >= 3 && depths[i] == depths[i-1])
                    {
                        sameDepthCounter++;
                    }
                    if (i < depths.Count - 1 && depths[i] == depths[i+1])
                    {
                        sameDepthCounter++;
                        temp += 1;
                        i++;
                        if (i < depths.Count-1 && depths[i] == depths[i+1])
                        {
                            sameDepthCounter++;
                            temp += 1;
                            i++;
                        }
                        Console.WriteLine(temp);
                    }
                    if (sameDepthCounter % 3 == 0)
                    {
                        temp = Math.Pow(2, sameDepthCounter / 3);
                    }
                    else
                    {
                        output += temp;
                        temp = 0;
                        sameDepthCounter = 1;
                    }
                    if (i >= numberOfRows-4)
                    {
                        output += temp;
                    }
                    Console.WriteLine("Output: " + output);
                }
            }
            else
            {
                output = 1;
            }

            Console.WriteLine($"-----\nOutput: {output}");

            using StreamWriter sw = new StreamWriter(path: @"../../../src/output.txt", append: false, encoding: System.Text.Encoding.UTF8);
            sw.Write(output);
        }
    }
}
