using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_For_Katas
{
    internal class test
    {
        public void Test(string str)
        {
            var vv = str.ToLower().Where(x => x > 96 && x < 123 && !"aeiou".Contains(x)).Count();
        }
    }
}
