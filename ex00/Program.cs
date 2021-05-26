using System;

namespace ex00
{
    class MainClass
    {
        public static void Main(string[] args)
        {
           
                Double sum = Double.Parse(args[0]);
                Double rate = Double.Parse(args[1]);
                Int32 term = Int32.Parse(args[2]);
                Int32 selectedMonth = Int32.Parse(args[3]);
                Double payment = Double.Parse(args[4]);
          
               Double rateInManth = rate / 12 / 100;
            Double anuitPayment = (sum * rateInManth * Math.Pow((1 + rateInManth), term)) / (Math.Pow((1 + rateInManth), term) - 1);
            DateTime date = new DateTime();
            date = DateTime.Now;
            Double sumOD = sum;
            int month = date.Month - 1;
            Double rateSum = 0;
            Double rateManth;
            Double oD;
            for (int i = 0; i < term; i++)
            {
                rateManth = sumOD * rate * System.DateTime.DaysInMonth(2021, (month + i) % 12 + 1) / (100 * 365);
                oD = anuitPayment - rateManth;
                sumOD -= oD;

            }
            Console.WriteLine();
            sumOD = sum;
            Double anuitPayment2 = anuitPayment;
            Console.WriteLine("График при уменьшении платежа\n");
            Console.WriteLine(" | {0,10} | {1,12} | {2,12} | {3,12} | {4,12} |", "Дата", "Платеж", "ОД", "Проценты", "Ост долга");
            Console.WriteLine("{0,46}", "---------------------------------------------------------------------------");
            Console.WriteLine(" | {0,10} | {1,12:N2} | {2,12:N2} | {3,12:N2} | {4,12:N2} |", "", anuitPayment2, sumOD, anuitPayment * term - sumOD, sumOD);
            for (int i = 0; i < term; i++)
            {
                rateManth = sumOD * rate * System.DateTime.DaysInMonth(2021, (month + i) % 12 + 1) / (100 * 365);
                oD = anuitPayment2 - rateManth;
                sumOD -= oD;
                if (i == selectedMonth - 1)
                {
                    sumOD -= payment;
                    anuitPayment2 = (sumOD * (rateInManth) * Math.Pow((1 + rateInManth), (term - selectedMonth))) /
                    (Math.Pow((1 + rateInManth), (term - selectedMonth)) - 1);


                }

                Console.WriteLine(" | {4:d} | {3,12:N2} | {0,12:N2} | {1,12:N2} | {2,12:N2} |", oD, rateManth, sumOD, anuitPayment2, date.AddMonths(i + 1));
                rateSum += rateManth;

            }

            Console.WriteLine("\n  Переплата при уменьшении платежа: {0:N2}  р.", rateSum);
            Console.WriteLine("\n");
            Double rateSum1 = rateSum;
            sumOD = sum;
            rateSum = 0;
            Console.WriteLine("График при уменьшении срока\n");
            Console.WriteLine(" | {0,10} | {1,12} | {2,12} | {3,12} | {4,12} |", "Дата", "Платеж", "ОД", "Проценты", "Ост долга");
            Console.WriteLine("{0,46}", "---------------------------------------------------------------------------");
            Console.WriteLine(" | {0,10} | {1,12:N2} | {2,12:N2} | {3,12:N2} | {4,12:N2} |", "", anuitPayment, sumOD, anuitPayment * term - sumOD, sumOD);
            for (int i = 0; i < term; i++)
            {
                rateManth = sumOD * rate * System.DateTime.DaysInMonth(2021, (month + i) % 12 + 1) / (100 * 365);
                oD = anuitPayment - rateManth;
                sumOD -= oD;
                if (i == selectedMonth - 1)
                {
                    sumOD -= payment;
                    int numberManth = (int)Math.Log((anuitPayment / (anuitPayment - rateInManth * sumOD)), 1 + rateInManth);
                    term = i + numberManth + 1;
                }
                Console.WriteLine(" | {4:d} | {3,12:N2} | {0,12:N2} | {1,12:N2} | {2,12:N2} |", oD, rateManth, sumOD, anuitPayment, date.AddMonths(i + 1));
                rateSum += rateManth;
            }
            Console.WriteLine("\n  Переплата при уменьшении срока: {0:N2}р.\n", rateSum);
            if (rateSum < rateSum1)
            {
                Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа\n");
                Console.WriteLine("Переплата при уменьшении платежа: {0:N2}p.", rateSum1);
                Console.WriteLine("Переплата при уменьшении срока: {0:N2}p.\n", rateSum); 
                Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа на {0:N2}p.", (rateSum1 - rateSum));

            }
            else if (rateSum > rateSum1)
            {
                Console.WriteLine("Уменьшение  платежа выгоднее уменьшения срока\n");
                Console.WriteLine("Переплата при уменьшении платежа: {0:N2}p.\n", rateSum1);
                Console.WriteLine("Переплата при уменьшении срока: {0:N2}p.\n", rateSum);
                Console.WriteLine("Уменьшение  платежа выгоднее уменьшения срока на {0:N2}p.",(rateSum - rateSum1));
                   
            }
            else
                Console.WriteLine("Уменьшение платежа равно уменьшению срока\n" +
                    "Переплата при уменьшении платежа: {0:N2}p.\n" +
                    "Переплата при уменьшении срока: {1:N2}p.\n",
                    rateSum1, rateSum);

        }
    }
}
