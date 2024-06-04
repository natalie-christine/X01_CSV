
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace A01_Umformung_von_Datums__und_Zahlenwerten
{
    public class Program
    {

        Console.WriteLine("Hello, World!");

       String Path = "C:\\Users\nscho\\Documents\\A01.csv"; 

        if(Path == "")
        {
            Console.WriteLine("There is no file"); 
        }else {
           
    }

         List <String> PathList = new List <String>() {
       
         using (StreamReader r = new StreamReader())
         {
          int Counter = 1;
          string line;

         int maxi = PathList.Count - 2;
        for (int x1 = 1; x1 < maxi; x1++)
    {
        string[] contents = PathList[x1].Split("|");
        string newline = String.Empty;
        foreach (string content in contents)
        {
            newline += content.Trim("\"") + "|";
        }
        File.AppendLine(PathList, newline);
    }
}
         
     
            
