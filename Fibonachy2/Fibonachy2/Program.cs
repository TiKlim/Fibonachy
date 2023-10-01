using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachy2
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача №452: Систсема счисления Фибоначчи");
            Console.WriteLine("Пожалуйста, впишите входное число А: ");
            string A = Console.ReadLine(); //Получеам входные данные А
            Console.WriteLine("Пожалуйста, впишите входное число В: ");
            string B = Console.ReadLine(); //Получаем входные данные В

            if (B.CompareTo(A) > 0) //Сравниваем входное число В с входным числом А
            {
                string alt = A;
                A = B;
                B = alt;
            }
            if (A == "0" && B == "0")
            {
                Console.WriteLine(0);
                return;
            }

            char[] AArray = A.ToCharArray();
            Array.Reverse(AArray);
            A = new string(AArray);

            char[] BArray = B.ToCharArray();
            Array.Reverse(BArray);
            B = new string(BArray);



            List<int> spisok = new List<int>(new int[260]); //Создаём список под индекс в значение "260", т.к. для проводимых далее проверок значение индекса в "255" будет мало 
            for (int i = 0; i < A.Length; i++) //i - n-ный разряд входного числа А (думал назвать n, но остановился на варианте с i) 
            {
                if (A[i] == '1')
                {
                    spisok[i]++;
                }
            }
            for (int i = 0; i < B.Length; i++) //Тоже самое для входного числа В
            {
                if (B[i] == '1')
                {
                    spisok[i]++;
                }
            }

            while(true) //Проверка выходных данных 
            {
                for (int i = 0; i < 255; i++)
                {
                    if (spisok[i] > 1) //Условие на случай переполнения разряда; Проще говоря, если вразряде число больше 1
                    {
                        if (i == 0) //Если разряд i является нулевым, то ...
                        {
                            spisok[1]++; //... первый разряд +1;
                            spisok[0] -= 2; //нулевой разряд -2.
                        }
                        else //Иначе, если разряд i - первый разряд
                        {
                            if (i == 1)
                            {
                                spisok[2]++;
                                spisok[0]++;
                                spisok[1] -= 2;
                            }
                            else //Иначе, если разряд i > 1 (короче, в прочих разрядах)
                            {
                                spisok[i + 1]++;
                                spisok[i - 2]++;
                                spisok[i] -= 2;
                            }
                        }
                    }
                    if (spisok[i] > 0 && spisok[i + 1] > 0)
                    {
                        spisok[i]--;
                        spisok[i + 1]--;
                        spisok[i + 2]++;
                    }
                }

                int poln = 1; //Переполнение разряда
                for (int i = 0; i < 255; i++)
                {
                    poln = poln | spisok[i];
                }

                if (poln > 1)
                {
                    continue;
                }

                bool twins = true; //Проверяем наличие двух единиц рядом 
                for (int i = 0; i < 255; i++)
                {
                    if (spisok[i] + spisok[i + 1] > 1)
                    {
                        twins = false; //Находим - не допускаем 
                        break;
                    }
                }
                if (twins)
                {
                    break;
                }
            }

            int index = 255; //"Длина записи чисел A, B и их суммы A+B в системе счисления Фибоначчи не превышает 255 знаков" - из условия
            while (spisok[index] == 0)
            {
                index--;
            }

            for (; index >= 0; index--)
            {
                Console.WriteLine("");
                //Console.WriteLine("Ответ: ");
                Console.WriteLine(spisok[index]); //Выводим
            }
            Console.WriteLine("");
            Console.WriteLine("Ответ готов.");
            Console.ReadLine(); //Иначе не выводит :( //Там нужно на ENTER понажимать, чтобы ответ в столбик выстраился. Не успел разобраться с этим, простите(
        }
    }
}
