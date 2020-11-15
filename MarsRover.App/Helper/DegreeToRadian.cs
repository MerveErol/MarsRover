using System;

namespace MarsRover.App.Helper
{
   public static class DegreeToRadian
    {
        public static double  Get(int degree)
        {
            return (Math.PI / 180) * degree;
        }
    }
}
