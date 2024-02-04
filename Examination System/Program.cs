using System.Diagnostics;

namespace Examination_System;

internal class Program
{
    static void Main(string[] args)
    {
        Subject Sub1 = new Subject();

        Sub1.CreateExam();
        Console.Clear();
        Console.WriteLine("Do You Want To Strat The Exam ( Y || N ): ");

        if (char.Parse(Console.ReadLine().ToUpper()) == 'Y')
        {
            Console.Clear();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Sub1.EXAM_OF_SUBJECT.Show_Exam();
            sw.Stop();

            Console.WriteLine($"The Elapsed Time =  {sw.Elapsed.Minutes} Minutes : {sw.Elapsed.Seconds} Seconds");
        }
        else
        {

            Console.WriteLine("Thanks for your time ");
        }
    }
}
