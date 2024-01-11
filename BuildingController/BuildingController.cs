using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingController
{
    class BuildingController
    {
        public bool IsTriangle(int a, int b, int c)
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }
        public string ClassifyTriangle(int a, int b, int c)
        {
            if (!IsTriangle(a, b, c))
            {
                return "not a triangle";
            }
            if (a == b && b == c)
            {
                return "equilateral";
            }
            if (a == b || a == c || b == c)
            {
                return "isosceles";
            }
            return "scalene";
        }
    }
}
