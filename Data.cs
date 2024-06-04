using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A01
{
    internal class Data
    {

        public Data(String Input, DateTime Date) 
        {
            this.Input = Input;
            this.Date = Date; 

        }
        
        public String Input { get; private set; }
        public DateTime Date { get; private set; }


    }
}
