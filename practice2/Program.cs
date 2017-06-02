using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;// 3 200
                //100 150 350 ??? 
                //1 идти по массиву и если малоимущий, то списать с ближайшего не малоимущего, вывести ~ n*n, если будет работать
                //1*можно помогать только одному, соответсвенно, надо начинать с наиболее богатых и приравнивать их к среденему - поэтому 1 не будет работать

namespace practice2
{
    class Worker
    {
        public Int64 Num; //номер рабочего
        public Int64 Pay; //з/п
        public string HelpInfo;//Строка для ответа
        public Worker (Int64 pay, Int64 num)
        {
            Num = num;
            Pay = pay;
        }
        
        public class NumSort : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                if (((Worker)obj1).Num >= ((Worker)obj2).Num)
                    return 1;
                else
                    return -1;
            }
        }
        public class PaySort : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                if (((Worker)obj1).Pay >= ((Worker)obj2).Pay)
                    return -1;
                else
                    return 1;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Int64 n, avr;
            Worker[] d;
            string temp;

            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");

            temp = input.ReadLine();
            n = int.Parse(temp.Split()[0]);
            avr = int.Parse(temp.Split()[1]);
            d = new Worker[n];

            Console.WriteLine(n);
            Console.WriteLine(avr);
            for (int i = 0; i < n; i++)
            {
                d[i] = new Worker(int.Parse(input.ReadLine()), i + 1);
                Console.WriteLine(d[i].Pay + "  " + d[i].Num);
            }

            Console.WriteLine("");
            Array.Sort(d, new Worker.PaySort());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(d[i].Pay + "  " + d[i].Num);
            }
            Console.WriteLine("");
            Array.Sort(d, new Worker.NumSort());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(d[i].Pay + "  " + d[i].Num);
            }
            //2+1* создать класс рабочего от номера и зарплаты. Отсортировать по з/п, смотреть, сколько надо.

            

        }
    }
}
