using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;

namespace A01
{
    public class Program
    {
        public static void Main(string[] args)
        {

            String formatter = "dd.mm.yyyy"; 

            String Path = "C:\\Users\\nscho\\Documents\\A01.csv";

            if (string.IsNullOrEmpty(Path))
            {
                Console.WriteLine("There is no file");
                return;
            }

            List<String> ContentList = new List<String>();
            
       
        try
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                 string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        ContentList.Add(line);
                    }
                }

                List<string> outputList = new List<string>();

                int max = ContentList.Count - 2;
                for (int i = 1; i < max; i++)
                {
                    string[] contents = ContentList[i].Split('|');
                    contents[0] = input; 

                    DayTime ParseExtract(input, formatter, IFormatProvider? provider);      
                    

                    Console.WriteLine(contents[0]);
                    Console.WriteLine(contents[1]);

                    string newLine = string.Empty;
                    foreach (string content in contents)
                    {
                        newLine += content.Trim('|');
                    }
                    newLine = newLine.TrimEnd('|');
                    outputList.Add(newLine);
                }

                string outputPath = "C:\\Users\\nscho\\Documents\\A04_output.txt";

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (string outputLine in outputList)
                    {
                        writer.WriteLine(outputLine);
                    }
                }

                Console.WriteLine("completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

            
