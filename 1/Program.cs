using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<int> numbers = new MyClass<int>(new int[]{1,2,3,4,5});

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
