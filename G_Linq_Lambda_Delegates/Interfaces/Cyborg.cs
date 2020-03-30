using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Interfaces
{
    class Cyborg : IPerson, ICar
    {
        int IPerson.Move(int distance)
        {
            return distance / 25;
        }

        int ICar.Move(int distance)
        {
            return distance / 100;
        }
    }
}
