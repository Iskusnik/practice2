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
        public int Pay; //з/п
        public string HelpInfo;//Строка для ответа
        public Worker (int pay, int num)
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
                d[i] = new Worker(int.Parse(input.ReadLine()), i + 1);
            

            
            //2+1* создать класс рабочего от номера и зарплаты. Отсортировать по з/п, смотреть, сколько надо.
            //3 200
            //10       100     100
            //300      300     150
            //290??    200     350
            //O! Будем помогать следующему по величине зарплаты, приводя данную з.п к среднему
            //time error
            Array.Sort(d, new Worker.PaySort());
            
            for (int i = 0; i < n; i++)
            {
                if (d[i].Pay == avr)
                    break;
                if (d[i].Pay > avr){
                    for (int j = i + 1; j < n; j++)
                        if (d[j].Pay != avr)
                        {
                            d[j].HelpInfo = (d[i].Num).ToString() + " " + (d[i].Pay - avr).ToString();
                            d[j].Pay += d[i].Pay - avr;
                            d[i].Pay = avr;
                            break;
                        }
                }
            }
            Array.Sort(d, new Worker.NumSort());

           /* for (int i = 0; i < n; i++)
            {
                if (d[i].HelpInfo == null)
                    d[i].HelpInfo = "0 0";
                Console.WriteLine(d[i].HelpInfo);
            }*/
            for (int i = 0; i < n; i++)
            {
                if (d[i].HelpInfo == null)
                    d[i].HelpInfo = "0 0";
                output.WriteLine(d[i].HelpInfo);
            }
            input.Close();
            output.Close();
        }
    }
}
