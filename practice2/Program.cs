using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace practice2
{
    class Worker
    {
        public int Num; //номер рабочего
        public int HelpPay; //передача
        public int Pay; //передача
        public int HelpNum = 0; //кому
        public Worker(int pay, int num)
        {
            Num = num;
            Pay = pay;
        }

        public class PaySort : IComparer
        {
            public int Compare(object obj1, object obj2)
            {

                if (((Worker)obj1).Pay > ((Worker)obj2).Pay)
                    return -1;
                if (((Worker)obj1).Pay < ((Worker)obj2).Pay)
                    return 1;
                return 0;
            }
        }
        public class PayNum : IComparer
        {
            public int Compare(object obj1, object obj2)
            {

                if (((Worker)obj1).Num < ((Worker)obj2).Num)
                    return -1;
                if (((Worker)obj1).Num > ((Worker)obj2).Num)
                    return 1;
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n, avr;
            Stack helpers = new Stack();
            Stack need = new Stack();

            string temp;

            StreamReader input = new StreamReader("INPUT.TXT");
            StreamWriter output = new StreamWriter("OUTPUT.TXT");

            temp = input.ReadLine();
            n = int.Parse(temp.Split()[0]);
            avr = int.Parse(temp.Split()[1]);
            Worker[] d = new Worker[n];

            for (int i = 0; i < n; i++)
            {
                int a;
                a = avr - int.Parse(input.ReadLine());
                d[i] = new Worker(a, i + 1);
                if (a > 0)
                    helpers.Push(d[i]);
                if (a < 0)
                    need.Push(d[i]);
            }





            while (helpers.Count > 0 && need.Count > 0)
            { 
                Worker helper = (Worker)helpers.Pop();
                Worker needhlp = (Worker)need.Pop();
                needhlp.Pay += helper.Pay;
                helper.HelpPay = helper.Pay;
                helper.Pay = 0;
                helper.HelpNum = needhlp.Num;
                if (needhlp.Pay > 0)
                    helpers.Push(needhlp);
                if (needhlp.Pay < 0)
                    need.Push(needhlp);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", d[i].HelpNum, d[i].HelpPay);
            }

            input.Close();
            output.Close();
        }
    }
}
