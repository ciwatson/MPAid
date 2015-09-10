using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    public static class mathLib
    {

        public static int RndInt(int lowerBound, int upperBound)
        {
            Random rnd = new Random();
            return rnd.Next(lowerBound, upperBound + 1);
        }
    }
}
