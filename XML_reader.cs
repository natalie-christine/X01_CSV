using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Reflection.Metadata;

namespace A01_CSV
{
    internal class XML_reader
    {

      
        public void XMLReader()

        {
  
            string xmlFilePath = "C:\\Users\\nscho\\Documents\\A01\\XML_Export.xml";
            string outputFilePath = "C:\\Users\\nscho\\Documents\\A01\\XML_Import.txt";


            if (string.IsNullOrEmpty(xmlFilePath) || string.IsNullOrEmpty(outputFilePath))
            {
                Console.WriteLine("Invalid file path.");
                return;
            }

            if (!File.Exists(xmlFilePath))
            {
                Console.WriteLine("XML file does not exist.");
                return;
            }

            try
            {
                XDocument XMLFile = XDocument.Load(xmlFilePath);
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (XElement element in XMLFile.Descendants("Root").Elements())
                    {
                        writer.WriteLine(ElementToText(element));
                    }
                }

                Console.WriteLine($"Successfully saved to {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private string ElementToText(XElement element)
        {
            switch (element.Name.LocalName)
            {
                case "Date":
                    return string.Join(";", element.Elements().Select(e => e.Value)) + ";";
                //    $"Date: {element.Element("Input-Date")?.Value}, CheckValue: {element.Element("CheckValue")?.Value}, Datatyp: {element.Element("Datatyp")?.Value}";
                case "Decimal":
                    return string.Join(";", element.Elements().Select(e => e.Value))+ ";";
                //    $"Decimal: {element.Element("Value")?.Value}, CheckValue: {element.Element("CheckValue")?.Value}, Datatyp: {element.Element("Datatyp")?.Value}";
                case "EmptyElement":
                    return "";
                        //"Empty Element";
                default:
                    return "Unknown Element";
            }
        }
    }
}
