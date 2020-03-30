using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Interfaces
{
    class LadaSedan : ICar
    {
        public int Move(int distance)
        {
            return distance / 40;
        }
    }
}
