using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 n, avr;
            Int64[] d;
            string temp;

            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");

            temp = input.ReadLine();
            n = int.Parse(temp.Split()[0]);
            avr = int.Parse(temp.Split()[1]);
            d = new Int64[n];

            Console.WriteLine(n);
            Console.WriteLine(avr);
            for (int i = 0; i < n; i++)
            {
                d[i] = int.Parse(input.ReadLine());
                Console.WriteLine(d[i]);
            }
            //1 идти по массиву и если малоимущий, то списать с ближайшего не малоимущего, вывести ~ n*n, если будет работать
            //2 создать класс рабочего от номера и зарплаты. Отсортировать по з/п, смотреть, сколько надо.
        }
    }
}
