using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

namespace G_Linq_Lambda_Delegates.Classes
{
     public  class Linq_And_Lyambda_Expressions
    {
        public string Name { get; set; } 
        public int Energy { get; set; }

        public override string ToString()
        {
            return $"{Name} Энергетическая ценность: ({Energy} ккал)";
        }
    }


}
