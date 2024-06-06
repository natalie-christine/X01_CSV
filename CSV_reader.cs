using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace A01_CSV
{
    public class CSV_reader
    {
        public CSV_reader()
        {
            string path = "C:\\Users\\nscho\\Documents\\InputFile.txt";

            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Console.WriteLine("File does not exist");
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

                int DateValuesLines = 21; // Anzahl der Datumszeilen
                int max = contentList.Count;

                // Prozessiere die Datumszeilen
                for (int i = 0; i < DateValuesLines; i++)
                {
                    string[] contents = contentList[i].Split('|');
                    if (contents.Length == 3)
                    {
                        string input = contents[0];
                        DateTime date;
                        if (DateTime.TryParseExact(input, new string[] { "yyyy-MM-dd", "MM/dd/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "MM-dd-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            contents[0] = date.ToString("dd.MM.yyyy");
                        }

                        string newLine = string.Join("|", contents);
                        outputList.Add(newLine);
                        Console.WriteLine(contents[0]);
                    }
                }

                for (int i = DateValuesLines; i < max; i++)
                {
                    string[] contents = contentList[i].Split('|');
                    if (contents.Length == 3)
                    {
                        string input = contents[0].Trim();
                        decimal parsedValue;

                        if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out parsedValue))
                        {
                            // Standardformatierung
                            string format = "#,##0.######";
                            CultureInfo culture = new CultureInfo("de-DE");

                 
                            switch (i )
                            {
                                case 24:
                                    format = "#,##0.00"; // 1.000,00
                                    break;
                                case 25:
                                    format = "0.00"; // 3,50
                                    break;
                                case 26:
                                    format = "0.000"; // 0,004
                                    break;
                                case 28:
                                    format = "#,##0.00"; // 5.000,00
                                    break;
                            }

                            contents[0] = parsedValue.ToString(format, culture);

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

                string outputPath = "C:\\Users\\nscho\\Documents\\A20_output.txt";

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
