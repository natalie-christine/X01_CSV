using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace A01_CSV
{
	internal class PrepairForXML
	{

		public PrepairForXML()
		{


			string path = "C:\\Users\\nscho\\Documents\\A01\\CSV_Export.txt";

			if (string.IsNullOrEmpty(path))
			{
				Console.WriteLine("There is no file");
				return;
			}

			List<string> contentList = new List<string>();
			

			string[] source = File.ReadAllLines("C:\\Users\\nscho\\Documents\\A01\\CSV_Export.txt");
		

			foreach (string line in source)
			{
				contentList.Add(line.Trim());
			}
			int DateValuesLines = 21;

			int max = contentList.Count;
			XElement root = new XElement("Root");
			

			for (int i = 0; i < max; i++)

			{
				string[] fields = contentList[i].Split('|');
		

                if (fields.Length == 3)
				{

					if (i < DateValuesLines)
					{
						XElement inputElement = new XElement("Date",

						new XElement("Input-Date", fields[0]),
						new XElement("CheckValue", fields[1]),
						new XElement("Datatyp", fields[2])

					   );
						root.Add(inputElement);
					
						Console.WriteLine(inputElement.ToString());

					}

					else
					{
						XElement inputElement = new XElement("Decimal",

						new XElement("Value", fields[0]),
						new XElement("CheckValue", fields[1]),
						new XElement("Datatyp", fields[2])

						);
						root.Add(inputElement);
						Console.WriteLine(inputElement.ToString());
					}

				}

				else
				{

					XElement empty = new XElement("EmptyElement");
					root.Add(empty);
			
					Console.WriteLine(empty.ToString());

				}


			}

            string outputPath = "C:\\Users\\nscho\\Documents\\A01\\XML_Export.xml";
            File.WriteAllText(outputPath, root.ToString());

            Console.WriteLine(root.ToString());
			Console.ReadLine();

        }
	}
}
