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
            int openIf = 0;
            int output = 0;
            List<string> rows = new List<string>();

            using StreamReader sr = new StreamReader(path: @"../../../src/input.txt", encoding: System.Text.Encoding.UTF8);
            int numberOfRows = int.Parse(sr.ReadLine());
            while (!sr.EndOfStream)
            {
                rows.Add(sr.ReadLine());
            }

            if (numberOfRows > 2)
            {
                for (int i = 0; i < numberOfRows; i++)
                {
                    if (rows[i] == "if" && rows[i + 1] == "else")
                    {
                        output++;
                    }
                    if (rows[i] == "if" && rows[i + 1] != "else")
                    {
                        openIf++;
                    }
                    if (rows[i] == "else" && rows[i + 1] == "endif")
                    {
                        output++;
                    }
                    if(rows[i] == "else" && rows[i + 1] != "endif")
                    {
                        openIf++;
                    }
                    if (openIf > 0 && (rows[i] == "endif" && rows[i+1] == "endif"))
                    {
                        openIf--;
                    }
                }
            }
            else
            {
                output = 1;
            }
            Console.WriteLine(openIf);
            Console.WriteLine(output);
            output += openIf;

            using StreamWriter sw = new StreamWriter(path: @"../../../src/output.txt", append: false, encoding: System.Text.Encoding.UTF8);
            sw.Write(output);
        }
    }
}
