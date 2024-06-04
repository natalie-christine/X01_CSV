using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace A01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\nscho\\Documents\\A01.csv";

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("There is no file");
                return;
            }

            List<string> contentList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        contentList.Add(line);
                    }
                }

                List<string> outputList = new List<string>();

                int max = contentList.Count;
                for (int i = 0; i < max; i++)
                {
                    string[] contents = contentList[i].Split('|');
                    if (contents.Length > 0)
                    {
                        string input = contents[0];
                        DateTime date;
                        if (DateTime.TryParseExact(input, new string[] { "yyyy-MM-dd", "MM/dd/yyyy", "dd.MM.yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            Data data = new Data(input, date);
                            contents[0] = data.Date.ToString("dd.MM.yyyy");
                        }

                        string newLine = string.Join("|", contents);
                        outputList.Add(newLine);
                    }
                }

                string outputPath = "C:\\Users\\nscho\\Documents\\A04_output.txt";

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (string outputLine in outputList)
                    {
                        writer.WriteLine(outputLine);
                    }
                }

                Console.WriteLine("Completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}
