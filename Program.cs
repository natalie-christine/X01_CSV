using A01_CSV;
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


           CSV_reader cSV_Reader = new CSV_reader();
           PrepairForXML prepairForXML = new PrepairForXML(); 
            XML_reader xml_reader = new XML_reader();
            xml_reader.XMLReader();
        }
    }
}
