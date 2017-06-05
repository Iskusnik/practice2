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
            Worker[] d;
            string temp;

            StreamReader input = new StreamReader("INPUT.TXT");
            StreamWriter output = new StreamWriter("OUTPUT.TXT");

            temp = input.ReadLine();
            n = int.Parse(temp.Split()[0]);
            avr = int.Parse(temp.Split()[1]);
            d = new Worker[n];

            for (int i = 0; i < n; i++)
                d[i] = new Worker(avr - int.Parse(input.ReadLine()), i + 1);





            for (int i = 0; i < n; i++)
            {

                if (d[i].Pay > 0)
                    for (int j = 0; j < n; j++)
                        if (d[j].Pay < 0)
                        {
                            d[j].Pay += d[i].Pay;
                            d[i].HelpPay = d[i].Pay;
                            d[i].Pay = 0;
                            d[i].HelpNum = d[j].Num;
                            while (d[j].Pay > 0)
                                for (int k = 0; k < n; k++)
                                    if (d[k].Pay < 0)
                                    {
                                        d[k].Pay += d[j].Pay;
                                        d[j].HelpPay = d[j].Pay;
                                        d[j].Pay = 0;
                                        d[j].HelpNum = d[k].Num;
                                        j = k;
                                    }
                            break;
                        }
                /*  if (d[i].Pay < 0)
                      for (int j = 0; j < n; j++)
                          if (d[j].Pay > 0)
                          {
                              d[i].Pay += d[j].Pay;
                              d[j].HelpPay = d[j].Pay;
                              d[j].Pay = 0;
                              d[j].HelpNum = d[i].Num;
                              break;
                          }*/
            }

            Array.Sort(d, new Worker.PayNum());
            for (int i = 0; i < n; i++)
            {
                output.WriteLine("{0} {1}", d[i].HelpNum, d[i].HelpPay);
            }

            input.Close();
            output.Close();
        }
    }
}