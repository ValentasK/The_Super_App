using System.Collections.Generic;


namespace ConsoleApp_For_Katas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ConsonantCount("string");
        }


        public static int ConsonantCount(string str)
        {

            //Consonants are all letters used to write English excluding the vowels a, e, i, o, u.

            // [TestCase("h^$&^#$&^elLo world", ExpectedResult = 7)]

            string aaa = "helLo world";    // 7
            int count = 0;

            var g = aaa.ToLower();
            var v = g.ToLower().Except(new char[] { 'a', 'e', 'i', 'o', 'u' }).Where(x => (int)x > 96 && (int)x < 123).ToList();
            var vv = aaa.ToLower().Where(x => x > 96 && x < 123 && !"aeiou".Contains(x)).Count();

            return 5;
        }
    }
}