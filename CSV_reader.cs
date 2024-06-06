using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_CSV
{
    public class CSV_reader

    {
        public CSV_reader()
        {

            string path = "C:\\Users\\nscho\\Documents\\InputFile.txt";

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

                int DateValuesLines = 23;
                int max = contentList.Count;
                for (int i = 0; i < DateValuesLines; i++)
                {
                    string[] contents = contentList[i].Split('|');
                    if (contents.Length > 0)
                    {
                        string input = contents[0];
                        DateTime date;
                        if (DateTime.TryParseExact(input, new string[] { "yyyy-MM-dd", "MM/dd/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "MM-dd-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            contents[0] = date.ToString("dd.MM.yyyy");
                            Console.WriteLine(contents[0]);
                        }

                        string newLine = string.Join("|", contents);
                        outputList.Add(newLine);
                    }
                }

                for (int i = DateValuesLines; i < max; i++)
                {
                    string[] contents = contentList[i].Split('|');
                    if (contents.Length > 0)
                    {
                        string input = contents[0].Trim();
                        decimal parsedValue;

                        input = input.Replace(",", "").Replace(".", ",");
                        if (decimal.TryParse(input, NumberStyles.Any, new CultureInfo("de-DE"), out parsedValue))
                        {

                            contents[0] = parsedValue.ToString("#,##0.######", new CultureInfo("de-DE")); // "F4", "D" 
                            string newLine = string.Join("|", contents);
                            outputList.Add(newLine);
                            Console.WriteLine(contents[0]);
                        }
                        else
                        {
                            Console.WriteLine($"Try Parse Error: {input}");
                        }
                    }
                }

                string outputPath = "C:\\Users\\nscho\\Documents\\A18_output.txt";

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
