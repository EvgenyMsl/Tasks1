using System;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.WriteLine(Program.arr_task2());
            Program.Task1v1();
        }

        //Ввести трехзначное число. Посчитать сумму цифр, вывести на экран
        static int Task1v1()//влоб
        {
            //со стрингой не используя массивы(если стринг не в счёт) и парс
            int answer = 0;
            bool isMinusDigit = false;
            String readIntString = new String("");

            Console.WriteLine("Введите число. Подтверждайте ввод клавишей Enter");
            while (readIntString != "0")
            {
                readIntString = Console.ReadLine();
                for (int i = 0; i < readIntString.Length; i++)
                {
                    if (readIntString[i] == '-')
                        isMinusDigit = true;
                    else
                    {
                        if (isMinusDigit)
                        {
                            if (readIntString.Length!=4)
                            {
                                Console.WriteLine("Неправильный ввод! Введите заново ");
                                answer = 0;
                                break;
                            }
                        }
                        else
                        {
                            if (readIntString.Length!=3)
                            {
                                Console.WriteLine("Неправильный ввод! Введите заново ");
                                answer = 0;
                                break;
                            }
                        }
                        if ((readIntString[i] - 48 >= 0 & readIntString[i] - 48 <= 9))
                        {
                            answer += readIntString[i] - 48;
                        }
                        else
                        {
                            answer = 0;
                            Console.WriteLine("Не число! Введите заново ");
                            break;
                        }
                    }
                }
                Console.WriteLine("Cумма чисел: " + answer);
            }
            return answer;
        }

        //Ввести трехзначное число. Посчитать сумму цифр, вывести на экран
        static void Task1v2()//по хитрому:)
        {
            //не используя массивы вообще. По факты маленький кейлоггер
            ConsoleKeyInfo key;
            int answer = 0;
            int numberOfDigits = 0;

            Console.WriteLine("Введите число. Подтверждайте ввод клавишей Enter");
            do
            {
                key = Console.ReadKey();
                char s = (char)((int)key.Key - 48);
                if ((s >= 0 & s <= 9))
                {
                    numberOfDigits++;
                    answer += s;
                }
                else
                {
                    //answer = 0;
                    //numberOfDigits = 0;  
                }
                if ((int)key.Key == 13)//enter
                {
                    if (numberOfDigits!=3)
                    {
                        numberOfDigits = 0;
                        Console.WriteLine();
                        Console.WriteLine("Неправильный ввод! Введите заново ");
                        answer = 0;
                    }
                    else
                    {
                        numberOfDigits = 0;
                        Console.WriteLine();
                        Console.WriteLine("Cумма чисел: "+answer);
                        answer = 0;
                    }
                }
                if (answer == 0 & s == 0)
                    break;
            }
            while (key.Key != ConsoleKey.Escape); // по нажатию на Escape завершаем цикл
        }

        //Ввести трехзначное число. Посчитать сумму цифр, вывести на экран
        static int Task1v3()
        {
            int answer = 0;//не сохраняя считанные позиции. с парсом
            int readInt = 0;
            String readString = new String("");
            

            Console.WriteLine("Введите число. Подтверждайте ввод клавишей Enter");
            
            while (readString != "0")
            {
                readString = Console.ReadLine();
                try
                {
                    readInt = int.Parse(readString);
                    if (readInt < 0)//нет смысла считать минус
                        readInt = 0 - readInt;
                    if ((readInt <= 1000) && (readInt >= -1000))
                    {
                        for (int i = 0; i < readString.Length; i++)
                        {
                            answer += readInt % 10;
                            readInt /= 10;
                        }
                        Console.WriteLine("Cумма чисел: " + answer);
                    }
                    else
                        Console.WriteLine("Число не трёхзначное! Введите заново ");

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Не число");
                }
            }
            return answer;
        }


        //Вводить числа, пока не будет введен ноль. Вывести число с максимальной суммой
        static int Task2()
        {
            int answer = 0;//не сохраняя считанные позиции. с парсом
            int maxAnswer = 0;
            int readInt = 0;
            String readIntString = new String("");
            
            Console.WriteLine("Введите число. Подтверждайте ввод клавишей Enter");
            while (readIntString != "0")
            { 
                readIntString = Console.ReadLine();
                try
                {
                    readInt = int.Parse(readIntString);
                    if (readInt < 0)//нет смысла считать минус
                        readInt = 0 - readInt;
                    for (int i = 0; i < readIntString.Length; i++)
                    {
                        answer += readInt % 10;
                        readInt /= 10;
                    }

                    if(answer>maxAnswer)
                        maxAnswer = answer; 
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Console.WriteLine(answer);
            return answer;
        }


        //Ввести n чисел (n задается пользователем). Посчитать сумму трех первых нечетных
        static int Task3v1()
        {
            int answer = 0;
            int N;

            try
            {
                Console.WriteLine("Введите количество чисел");
                
                N = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите строку с числами");
                string readString = Console.ReadLine();

                List<String> answerListOfString = readString.Split(" ").Take(N).Where(i=>int.Parse(i)%2==1).Take(3).ToList();//парсинг тут не означает вывод не в стринг
                for(int i=0;i< answerListOfString.Count;i++)
                {
                    answer += int.Parse(answerListOfString[i]);
                }
                Console.WriteLine(answer);
                Console.ReadLine();
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Во вводе есть не число");
            }
            return answer;
        }


        //Ввести n чисел (n задается пользователем). Посчитать сумму трех последних нечетных.
        static int Task4v1()
        { 
            int answer = 0;
            int N;

            try
            {
                Console.WriteLine("Введите количество чисел");
                N=int.Parse(Console.ReadLine());

                Console.WriteLine("Введите строку с числами");
                string readString = Console.ReadLine(); 

                List<String> answerListOfString = readString.Split(" ").Take(N).Where(i => int.Parse(i) % 2 == 1).Take(3).ToList();//парсинг тут нужен
                answerListOfString.Reverse();
                for (int i = 0; i < answerListOfString.Count; i++)
                {
                    answer += int.Parse(answerListOfString[i]);
                }

                Console.WriteLine("Cумма трех последних нечетных чисел: " + answer);
                Console.ReadLine();
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Некорректный ввод.");
            }
            return answer;
        }
         

        //Ввести n чисел (n задается пользователем). Посчитать сумму трех первых нечетных.
        static int Task3v2()
        { 
            int answersum = 0;
            int currentPositionOfDigit = 0;
            int previousPositionOfDigit = 0;
            int iterator=0;
            string answer="";
            string readString = "";

            try
            {

                Console.WriteLine("Введите строку с числами");
                readString = Console.ReadLine();

                for (int i=0;i<readString.Length;i++)
                {
                    if ((readString[i] == ' ')|i==readString.Length)
                    {
                        previousPositionOfDigit = currentPositionOfDigit;
                        currentPositionOfDigit = i;
                        
                        if(readString[currentPositionOfDigit-1]%2==1)
                        {
                           answer = readString.Substring(previousPositionOfDigit+1, currentPositionOfDigit - 1 - previousPositionOfDigit);
                           answersum += int.Parse(answer);
                            iterator++;
                            if (iterator == 3)
                                break;
                        }
                    }
                }
                if(answer.Length!=0)
                    Console.WriteLine("Сумма трёх первых нечётных чисел: " + answersum);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Неправильный ввод");
            }
            return answersum;
        }

        //Ввести n чисел (n задается пользователем). Посчитать сумму трех последних нечетных.
        static int Task4v2()
        {
            int answersum = 0;
            int currentPositionOfDigit = 0;
            int previousPositionOfDigit = 0;
            int prepreviousOddNumber = 0;
            int previousOddNumber = 0;
            int currentOddNumber = 0;
            int NumberOfDigits = 0;
            string digitString = "";

            try
            {
                
                Console.WriteLine("Введите число N-количество чисел на вход");
                int N = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите строку с числами");
                string readString = Console.ReadLine();

                for (int i = 0; i < readString.Length; i++)
                {
                    if ((readString[i] == ' ') | i == readString.Length)
                    {
                        previousPositionOfDigit = currentPositionOfDigit;
                        currentPositionOfDigit = i;
                        NumberOfDigits++;
                        if(NumberOfDigits>N)
                        {
                            Console.WriteLine("Чисел больше, чем заявлено в N. Будем считать последние ДО N");
                            break;
                        }
                        if (readString[currentPositionOfDigit - 1] % 2 == 1)
                        {
                            digitString = readString.Substring(previousPositionOfDigit + 1, currentPositionOfDigit - 1 - previousPositionOfDigit);
                            prepreviousOddNumber = previousOddNumber;
                            previousOddNumber = currentOddNumber;
                            currentOddNumber = int.Parse(digitString);
                        }
                    }
                }
                answersum = currentOddNumber + previousOddNumber + prepreviousOddNumber;

                Console.WriteLine("Сумма трёх последних нечётных чисел" + answersum);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Неправильный ввод");
            }
            return answersum;
        }

        //Посчитать сумму  6 + 10 + 14 + ..................., последнюю, которая еще не превышает 100. Сколько слагаемых?
        static int Task5(out int number, int answersum)
        {
            number = 2;
            answersum = 0;
            int n = 0;
            while (answersum <= 100)
            {
                
                number += 4;
                n++;
                answersum += number;
            }
            answersum -= number;
            n--;
            Console.WriteLine(n + " слагаемых и сумма " + answersum);
            return answersum;
        }

        //Посчитать сумму  6 + 10 + 14 + ................... + 46. Сколько слагаемых?
        static void Task6(out int n, out int answersum)
        {
            answersum = 0;
            n = 1;
            for(int i=6;i<=46;i+=4)
            {
                answersum += i;
                n++;
            } 
            Console.WriteLine(n + " слагаемых и сумма " + answersum);
        }


        //Ввести n целых чисел (n задается пользователем). Какая цифра встречается чаще других? Если таких цифр несколько
        //вывести ту из них, которая обозначает наибольшее число, а также сколько раз она встретилась.
        static void arr_task1()//через строку и линк
        {
            Console.WriteLine("Введите массив чисел, разделяя их пробелами.");
            string readString = System.Console.ReadLine();
            var sortedString = readString.Split(" ").Where(i=>i!="").OrderBy(i=>int.Parse(i)).GroupBy(i=>i).OrderBy(i=>i.Count()).ToList();
            Console.WriteLine(sortedString[sortedString.Count() - 1].Key+ "-самое большое число, встречаемое наибольшее количество раз: " + sortedString[sortedString.Count() - 1].Count());
        }


        //Ввести n целых чисел (n задается пользователем). Какая цифра встречается чаще других? Если таких цифр несколько
        //вывести ту из них, которая обозначает наибольшее число, а также сколько раз она встретилась.
        static void arr_task1v2()//через массив и линк
        {
            Console.WriteLine("Введите длину массива");
            string n=Console.ReadLine();
            try
            {
                int[] input = new int[int.Parse(n)];
                for (int i = 0; i < input.Length; i++)
                    input[i] = int.Parse(System.Console.ReadLine());
                Array.Sort(input);
                var groupedInput = input.GroupBy(i => i).OrderBy(i => i.Count()).ToArray();
                Console.WriteLine(groupedInput[groupedInput.Count() - 1].Key + "-самое большое число, встречаемое наибольшее количество раз: " + groupedInput[groupedInput.Count() - 1].Count());
            }
            catch(System.FormatException)
            {
                System.Console.WriteLine("Некорректный формат данных.");
            }
            catch(System.IndexOutOfRangeException)
            {
                System.Console.WriteLine("Ноль не может быть длиной массива.");
            }
        }

        //Ввести n целых чисел (n задается пользователем). Какая цифра встречается чаще других? Если таких цифр несколько
        //вывести ту из них, которая обозначает наибольшее число, а также сколько раз она встретилась.
        static void arr_task1v3()//чисто массив без линка
        {
            
            int maxCount = 0;
            int maxDigit = 0;
            int position = 0;

            Console.WriteLine("Введите длину массива");
            string n = Console.ReadLine();
            try
            {
                int[] input = new int[int.Parse(n)];
                int[] uniqueDigit = new int[int.Parse(n)];
                int[] countOfUniqueDigit = new int[int.Parse(n)];

                for (int i = 0; i < input.Length; i++)
                    input[i] = int.Parse(System.Console.ReadLine());

                //Array.Sort(input); //мы не ищем лёгких путей
                int temp;
                for (int i = 0; i < input.Length - 1; i++)
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[i] > input[j])
                        {
                            temp = input[i];
                            input[i] = input[j];
                            input[j] = temp;
                        }
                    }
                }

                uniqueDigit[0] = input[0];
                countOfUniqueDigit[0] = 1;

                if (input.Length != 1)
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        if (input[i] != input[i - 1])
                            uniqueDigit[++position] = input[i];
                        countOfUniqueDigit[position]++;
                        if (maxCount <= countOfUniqueDigit[position])
                        {
                            maxCount = countOfUniqueDigit[position];
                            maxDigit = uniqueDigit[position];
                        }
                    }
                }
                else
                {
                    maxCount = input[0];
                    maxDigit = input[0];
                }
                Console.WriteLine(maxDigit + "-самое большое число, встречаемое наибольшее количество раз: " + maxCount);
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Недопустимый формат");
                return;
            }
        }


        //Ввести массив целых чисел. Длина массива задается пользователем.
        //Определить, упорядочен ли он по возрастанию.
        //По убыванию?
        static string arr_task2()
        {
            bool isDescFlag = false;
            bool isAscFlag = false;
            string readString;

            Console.WriteLine("Введите массив чисел, разделяя их пробелами.");
            readString = System.Console.ReadLine();

            if (readString.Length == 0)
                return "Недопустимый ввод: нет элементов в массиве.";
            if (readString.Length == 1)
                return "Недопустимый ввод. Массив не сортирован ни по возрастанию, ни по убыванию.";

            try
            {
                var ascSortedString = readString.Split(" ").Where(i => i != "").OrderBy(i => int.Parse(i)).ToList();
                var readStringList = readString.Split(" ").Where(i => i != "").ToList();

                for (int i = 0; i < readStringList.Count; i++)
                {
                    if (ascSortedString[i] != readStringList[i])
                    {
                        isAscFlag = false;
                        break;
                    }
                    isAscFlag = true;
                }

                var descSortedString = readString.Split(" ").Where(i => i != "").OrderByDescending(i => int.Parse(i)).ToList();
                for (int i = 0; i < readStringList.Count; i++)
                {
                    if (descSortedString[i] != readStringList[i])
                    {
                        isDescFlag = false;
                        break;
                    }
                    isDescFlag = true;
                }

                string answer = "";
                if (isAscFlag)
                {
                    answer = "Cортирован по возрастанию";
                }
                else
                {
                    answer = "Не сортирован по возрастанию";
                    if (isDescFlag)
                    {
                        answer = "Cортирован по убыванию";
                    }
                    else
                    {
                        answer = "Не сортирован по убыванию";
                    }
                }
                return answer;
            }
            catch(System.FormatException)
            {
                return "Недопустимый ввод.";
            }
        }

        static void arr_task3()
        {
            
            int minNumPosition = 0;
            int maxNumPosition = 0;

            Console.WriteLine("Введите длину массива");
            string n = Console.ReadLine();
            
            try
            {
                int[] input = new int[int.Parse(n)];
                for (int i = 0; i < input.Length; i++)
                input[i] = int.Parse(System.Console.ReadLine());
            
                System.Console.WriteLine("min: " + input.Min());
                System.Console.WriteLine("max: " + input.Max());
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == input.Min())
                        minNumPosition = i;
                    if (input[i] == input.Max())
                        maxNumPosition = i;
                }

                int tmp = input[minNumPosition];
                input[minNumPosition] = input[maxNumPosition];
                input[maxNumPosition]=tmp;
                try
                {
                    System.Console.WriteLine("min odd: " + input.Where(i => i % 2 == 0).Min());
                    System.Console.WriteLine("min even: " + input.Where(i => i % 2 != 0).Min());
                }
                catch(System.InvalidOperationException ex)
                {
                    System.Console.WriteLine("Нет нужных значений для выборки: чётных или не чётных " + ex.Message);
                    return;
                }

                Console.WriteLine("Массив после преобразования: ");

                for (int i = 0; i < input.Length; i++)
                {
                    System.Console.Write(input[i] + " ");
                    return;
                }
            }
            catch(System.InvalidOperationException ex)
            {
               System.Console.WriteLine("Недопустимый для дальнейших действий ввод " + ex.Message);
               return;
            }
        }

    }
}
